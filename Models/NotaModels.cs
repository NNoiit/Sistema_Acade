using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sistemaAcad.Models
{
    public class NotaModels
    {
        [Key]
        public double IdNota{get; set;}
        public double Nota1{get; set;}

        public double Nota2{get; set;}

        public double Nota3{get; set;}

        public double Peso1{get; set;}

        public double Peso2{get; set;}

        public double Peso3{get; set;}

    }
}