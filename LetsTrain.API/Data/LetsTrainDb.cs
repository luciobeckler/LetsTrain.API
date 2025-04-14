using LetsTrain.API.Models;
using Microsoft.EntityFrameworkCore;

namespace LetsTrain.API.Data
{
    public class LetsTrainDb : DbContext
    {
        public LetsTrainDb(DbContextOptions options) : base(options){}
            public DbSet<Aula> Aulas { get; set; }
            public DbSet<Treino> Treinos { get; set; }
            public DbSet<Exercicio> Exercicios { get; set; }
            public DbSet<Professor> Professores { get; set; }
            public DbSet<Aluno> Alunos { get; set; }
    }
}
