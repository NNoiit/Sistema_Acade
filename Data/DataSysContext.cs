using Microsoft.EntityFrameworkCore;
using sistemaAcad.Models;

namespace sistemaAcad.Data
{
        public class DataSysContext : DbContext
    {
        public DataSysContext(DbContextOptions<DataSysContext> options) : base(options){}
        
        public DbSet<TurmaModels> turma {get; set;}

        public DbSet<AlunoModels> Aluno {get; set;}

        public DbSet<ProfessorModels> professor {get; set;}

        public DbSet<NotaModels> nota {get; set;}

    }
}