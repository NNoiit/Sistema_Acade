using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using sistemaAcad.Data;
using sistemaAcad.Models;

namespace sistemaAcad.Controllers
{
    public class NotaControllers : Controller
    {

         private readonly DataSysContext _context;

        public NotaControllers(DataSysContext context){

            this._context = context;
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

            if(id.HasValue){
                if(NotaExistente(id.Value)){

                    _context.Update(notap);
                    if(await _context.SaveChangesAsync() > 0){

                        TempData["mensagem"] = MensagemModels.Serializar("Nota alterado!");
                    }else{
                        TempData["mensagem"] = MensagemModels.Serializar("Erro ao alterrar Nota!");
                    }
                } else {

                    TempData["mensagem"] = MensagemModels.Serializar("Erro, Nota não encontrado!");
                }
            } else {
                _context.Add(notap);
                if(await _context.SaveChangesAsync() >0 ){

                    TempData["mensagem"] = MensagemModels.Serializar("Nota postada!"); 
                } else{

                    TempData["mensagem"] = MensagemModels.Serializar("Erro ao postar!");
                }
            }

            return RedirectToAction("Detalhar");
        }


        public double CalculoNota(double nota){

            return nota;
        }

        private bool NotaExistente(int id){

            return _context.nota.Any(x =>x.IdNota == id);
        }

    }
}