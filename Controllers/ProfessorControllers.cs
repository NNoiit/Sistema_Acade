using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sistemaAcad.Data;
using sistemaAcad.Models;

namespace sistemaAcad.Controllers
{
   public class ProfessorController : Controller
    {
        private readonly DataSysContext _context;

        public ProfessorController(DataSysContext context){

            this._context = context;
        }

        public async Task<IActionResult> Index_Professor(){

            return View(await _context.professor.OrderBy(x =>x.Nome).AsNoTracking().ToListAsync());
        }

        [HttpGet]

        public async Task<IActionResult> Cadastrar(int? id){

            if(id.HasValue){

                var professor = await _context.professor.FindAsync(id);

                if(professor == null){
                    
                    return NotFound();
                }
                return View(professor);
            }

            return View(new ProfessorModels());
        }

        [HttpPost]

        public async Task<IActionResult> Cadastrar(int? id, [FromForm] ProfessorModels professor){

            if(ModelState.IsValid){

                if(id.HasValue){
                    if(ProfessorExistente(id.Value)){

                        _context.Update(professor);
                        if(await _context.SaveChangesAsync() > 0){

                            TempData["mensagem"] = MensagemModels.Serializar("Professor alterado!");
                        }else{
                            TempData["mensagem"] = MensagemModels.Serializar("Erro ao alterar Professor!");
                        }
                    } else {

                        TempData["mensagem"] = MensagemModels.Serializar("Erro, Professor não encontrado!");
                    }
                } else {
                    _context.Add(professor);
                    if(await _context.SaveChangesAsync() >0 ){

                       TempData["mensagem"] = MensagemModels.Serializar("Professor cadastrada!"); 
                    } else{

                        TempData["mensagem"] = MensagemModels.Serializar("Erro ao cadastrar professor!");
                    }
                }

                return RedirectToAction("Index_Professor");

            } else{

                return View(professor);
            }
        }

        [HttpGet]

        public async Task<IActionResult> Excluir(int? id){
            if(!id.HasValue){

                TempData["mensagem"] = MensagemModels.Serializar("Professor não foi informado!");

                return RedirectToAction("Index_Professor");
            }
            var professor = await _context.professor.FindAsync(id);
            if(professor == null){

                TempData["mensagem"] = MensagemModels.Serializar("Professor não encontrado!");

                return RedirectToAction("Index_Professor");
            }

            return View(professor);
        }


        [HttpPost]

        public async Task<IActionResult> Excluir(int id){
            var professor = await _context.professor.FindAsync(id);
            if(professor != null){
                _context.professor.Remove(professor);
                if(await _context.SaveChangesAsync() > 0){
                
                    TempData["mensagem"] = MensagemModels.Serializar("Professor excluido!");
                }else{
                    TempData["mensagem"] = MensagemModels.Serializar("Erro a o excluir Professor");

                }
                return RedirectToAction("Index_Professor");
            }else{
                TempData["mensagem"] = MensagemModels.Serializar("Erro a o excluir Professor!", TipoMensagem.Erro);

                return RedirectToAction("Index_Professor");
            }
        }

        private bool ProfessorExistente(int id){

            return _context.professor.Any(x =>x.IdProfessor == id);
        }

    }
}