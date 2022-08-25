using System.ComponentModel.DataAnnotations;

namespace sistemaAcad.Models
{
    
    public class TurmaModels
    {
        [Key]
        public int IdTurma{get; set;}

        [Required, MaxLength(128)]
        public string Nome{get; set;}
    }
}