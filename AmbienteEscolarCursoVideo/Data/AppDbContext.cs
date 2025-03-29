using AmbienteEscolarCursoVideo.Models;
using Microsoft.EntityFrameworkCore;

namespace AmbienteEscolarCursoVideo.Data
{
    public class AppDbContext : DbContext
    {


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<TurmaModel> Turmas {get; set;}
        public DbSet<ProfessorModel> Professores { get; set; }
        public DbSet<AlunoModel> Alunos { get; set; }
        public DbSet<MateriaModel> Materias { get; set; }
        public DbSet<HistoricoModel> Historicos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<MateriaModel>().HasData(
                    new MateriaModel { Id = 1 , Descricao= "Matemática"},
                    new MateriaModel { Id = 2, Descricao = "Português" },
                    new MateriaModel { Id = 3, Descricao = "História" },
                    new MateriaModel { Id = 4, Descricao = "Ciências" },
                    new MateriaModel { Id = 5, Descricao = "Química" },
                    new MateriaModel { Id = 6, Descricao = "Educação Física" },
                    new MateriaModel { Id = 7, Descricao = "Redação" }



                );


            base.OnModelCreating(modelBuilder);
        }

    }
}
