using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace sistemaAcad.Models
{
    public class AlunoModels
    {
        [Key]
        public int IdAluno{get; set;}

        [Required]
        public string Nome{get; set;}

        [Required]
        public string Email{get; set;}

        [ForeignKey("Nota")]
        public double MediaNota{get; set;}

        public NotaModels Nota{get; set;}

        [ForeignKey("Turma")]
        public int IdTurma{get; set;}

        public TurmaModels Turma{get; set;}


    }
}