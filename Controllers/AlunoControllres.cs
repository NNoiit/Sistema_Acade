using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using sistemaAcad.Data;
using sistemaAcad.Models;

namespace sistemaAcad.Controllers
{
   public class AlunoController : Controller
    {
        private readonly DataSysContext _context;

        public AlunoController(DataSysContext context){

            this._context = context;
        }

        public async Task<IActionResult> Index_Aluno(){

            return View(await _context.Aluno.OrderBy(x => x.Nome).Include(x => x.Turma).AsNoTracking().ToListAsync());
        }

        //Cadastro---------------------------
        [HttpGet]
        public async Task<IActionResult> Cadastrar(int? id){

            //pegando as turmas no banco para select
            var turma = _context.turma.OrderBy(x => x.Nome).AsNoTracking().ToList();
            var turmaSelectList = new SelectList(turma, nameof(TurmaModels.IdTurma), nameof(TurmaModels.Nome));
            ViewBag.Turma = turmaSelectList;
            //-----------------------------------

            if(id.HasValue){

                var aluno = await _context.Aluno.FindAsync(id);

                if(aluno == null){
                    
                    return NotFound();
                }
                return View(aluno);
            }

            return View(new AlunoModels());
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(int? id, [FromForm] AlunoModels aluno){

            if(ModelState.IsValid){

                if(id.HasValue){
                    if(AlunoExistente(id.Value)){

                        _context.Update(aluno);
                        if(await _context.SaveChangesAsync() > 0){

                            TempData["mensagem"] = MensagemModels.Serializar("Aluno alterado!");
                        }else{
                            TempData["mensagem"] = MensagemModels.Serializar("Erro ao alterrar Aluno!");
                        }
                    } else {

                        TempData["mensagem"] = MensagemModels.Serializar("Erro, Aluno não encontrado!");
                    }
                } else {
                    _context.Add(aluno);
                    if(await _context.SaveChangesAsync() >0 ){

                       TempData["mensagem"] = MensagemModels.Serializar("Aluno cadastrado!"); 
                    } else{

                        TempData["mensagem"] = MensagemModels.Serializar("Erro ao cadastrar aluno!");
                    }
                }

                return RedirectToAction("Index_Aluno");

            } else{

                return View(aluno);
            }
        }

        //Excluir -------------------------------------------
        [HttpGet]
        public async Task<IActionResult> Excluir(int? id){
            if(!id.HasValue){

                TempData["mensagem"] = MensagemModels.Serializar("Aluno não foi informado!");

                return RedirectToAction("Index_Aluno");
            }
            var aluno = await _context.Aluno.FindAsync(id);
            if(aluno == null){

                TempData["mensagem"] = MensagemModels.Serializar("Aluno não encontrado!");

                return RedirectToAction("Index_Aluno");
            }

            return View(aluno);
        }

        
        [HttpPost]

        public async Task<IActionResult> Excluir(int id){
            var aluno = await _context.Aluno.FindAsync(id);
            if(aluno != null){
                _context.Aluno.Remove(aluno);
                if(await _context.SaveChangesAsync() > 0){
                
                    TempData["mensagem"] = MensagemModels.Serializar("Aluno excluido!");
                }else{
                    TempData["mensagem"] = MensagemModels.Serializar("Erro a o excluir Aluno");

                }
                return RedirectToAction("Index_Aluno");
            }else{
                TempData["mensagem"] = MensagemModels.Serializar("Erro a o excluir Aluno!", TipoMensagem.Erro);

                return RedirectToAction("Index_Aluno");
            }
        }

        //-------------------------------------------------

        [HttpGet]
        public async Task<IActionResult> Detalhar(int? id){

            //Dados da turma para select
            var turma = _context.turma.OrderBy(x => x.Nome).AsNoTracking().ToList();
            var turmaSelectList = new SelectList(turma, nameof(TurmaModels.IdTurma), nameof(TurmaModels.Nome));
            ViewBag.Turma = turmaSelectList;
            
            //Dados do aluno
                var aluno = await _context.Aluno.FindAsync(id);


                return View(aluno);
        
        }

        [HttpPost]
        public async Task<IActionResult> Detalhar(int? id, [FromForm] AlunoModels aluno){

            if(ModelState.IsValid){

                if(id.HasValue){
                    if(AlunoExistente(id.Value)){

                        _context.Update(aluno);
                        if(await _context.SaveChangesAsync() > 0){

                            TempData["mensagem"] = MensagemModels.Serializar("Aluno alterado!");
                        }else{
                            TempData["mensagem"] = MensagemModels.Serializar("Erro ao alterrar Aluno!");
                        }
                    } else {

                        TempData["mensagem"] = MensagemModels.Serializar("Erro, Aluno não encontrado!");
                    }
                } else {
                    _context.Add(aluno);
                    if(await _context.SaveChangesAsync() >0 ){

                       TempData["mensagem"] = MensagemModels.Serializar("Aluno cadastrado!"); 
                    } else{

                        TempData["mensagem"] = MensagemModels.Serializar("Erro ao cadastrar aluno!");
                    }
                }

                return RedirectToAction("Index_Aluno");

            } else{

                return View(aluno);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Notas(int? id){

            //Dados da turma para select
            var turma = _context.turma.OrderBy(x => x.Nome).AsNoTracking().ToList();
            var turmaSelectList = new SelectList(turma, nameof(TurmaModels.IdTurma), nameof(TurmaModels.Nome));
            ViewBag.Turma = turmaSelectList;
            
            //Dados do aluno
                var nota = await _context.Aluno.FindAsync(id);


                return View(new NotaModels());
        }


        [HttpPost]
        public async Task<IActionResult> Notas(int? id, [FromForm] NotaModels notap){

            if(ModelState.IsValid){

                if(id.HasValue){

                        _context.Update(notap);
                        if(await _context.SaveChangesAsync() > 0){

                            TempData["mensagem"] = MensagemModels.Serializar("Aluno alterado!");
                        }else{
                            TempData["mensagem"] = MensagemModels.Serializar("Erro ao alterrar Aluno!");
                        }
                    
                } else {
                    _context.Add(notap);
                    if(await _context.SaveChangesAsync() >0 ){

                       TempData["mensagem"] = MensagemModels.Serializar("Aluno cadastrado!"); 
                    } else{

                        TempData["mensagem"] = MensagemModels.Serializar("Erro ao cadastrar aluno!");
                    }
                }

                return RedirectToAction("Detalhar");

            } else{

                return View(notap);
            }
        }

        private bool AlunoExistente(int id){

            return _context.Aluno.Any(x =>x.IdAluno == id);
        }

    }
}