using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sistemaAcad.Data;
using sistemaAcad.Models;

namespace sistemaAcad.Controllers
{
   public class TurmaController : Controller
    {
        private readonly DataSysContext _context;

        public TurmaController(DataSysContext context){

            this._context = context;
        }

        public async Task<IActionResult> Index(){

            return View(await _context.turma.OrderBy(x =>x.Nome).AsNoTracking().ToListAsync());
        }

        [HttpGet]

        public async Task<IActionResult> Cadastrar(int? id){

            if(id.HasValue){

                var turma = await _context.turma.FindAsync(id);

                if(turma == null){
                    
                    return NotFound();
                }
                return View(turma);
            }

            return View(new TurmaModels());
        }

        [HttpPost]

        public async Task<IActionResult> Cadastrar(int? id, [FromForm] TurmaModels turma){

            if(ModelState.IsValid){

                if(id.HasValue){
                    if(TurmaExistente(id.Value)){

                        _context.Update(turma);
                        if(await _context.SaveChangesAsync() > 0){

                            TempData["mensagem"] = MensagemModels.Serializar("Turma alterada!");
                        }else{
                            TempData["mensagem"] = MensagemModels.Serializar("Erro ao alterrar Turma!");
                        }
                    } else {

                        TempData["mensagem"] = MensagemModels.Serializar("Erro, Turma não encontrada!");
                    }
                } else {
                    _context.Add(turma);
                    if(await _context.SaveChangesAsync() >0 ){

                       TempData["mensagem"] = MensagemModels.Serializar("Turma cadastrada!"); 
                    } else{

                        TempData["mensagem"] = MensagemModels.Serializar("Erro ao cadastrar turma!");
                    }
                }

                return RedirectToAction("Index");

            } else{

                return View(turma);
            }
        }

        [HttpGet]

        public async Task<IActionResult> Excluir(int? id){
            if(!id.HasValue){

                TempData["mensagem"] = MensagemModels.Serializar("Turma não foi informada!");

                return RedirectToAction("Index");
            }
            var turma = await _context.turma.FindAsync(id);
            if(turma == null){

                TempData["mensagem"] = MensagemModels.Serializar("Turma não encontrada!");

                return RedirectToAction("Index");
            }

            return View(turma);
        }


        [HttpPost]

        public async Task<IActionResult> Excluir(int id){
            var turma = await _context.turma.FindAsync(id);
            if(turma != null){
                _context.turma.Remove(turma);
                if(await _context.SaveChangesAsync() > 0){
                
                    TempData["mensagem"] = MensagemModels.Serializar("Turma excluida!");
                }else{
                    TempData["mensagem"] = MensagemModels.Serializar("Erro a o excluir Turma");

                }
                return RedirectToAction("Index");
            }else{
                TempData["mensagem"] = MensagemModels.Serializar("Erro a o excluir Turma!", TipoMensagem.Erro);

                return RedirectToAction("Index");
            }
        }

        private bool TurmaExistente(int id){

            return _context.turma.Any(x =>x.IdTurma == id);
        }

    }
}