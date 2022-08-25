using System.ComponentModel.DataAnnotations;

namespace sistemaAcad.Models
{
    public class ProfessorModels
    {
        [Key]
        public int IdProfessor{get; set;}

        [Required]
        public string Nome{get; set;}

        [Required]
        public string Email{get; set;}

        public int IdMateria{get; set;}

        public string Materia{get; set;}
    }
}