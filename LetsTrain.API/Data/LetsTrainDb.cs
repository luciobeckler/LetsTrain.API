using LetsTrain.API.Models;
using LetsTrain.API.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace LetsTrain.API.Data
{
    public class LetsTrainDb : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public LetsTrainDb(DbContextOptions options) : base(options){}
            public DbSet<Aula> Aulas { get; set; }
            public DbSet<Treino> Treinos { get; set; }
            public DbSet<Exercicio> Exercicios { get; set; }
            public DbSet<Professor> Professores { get; set; }
            public DbSet<Aluno> Alunos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //1-1 Aluno-User
            builder.Entity<Aluno>()
                .HasOne(a => a.User)                 
                .WithOne(u => u.Aluno)              
                .HasForeignKey<Aluno>(a => a.UserId);

            //n-n Aula-Aluno
            builder.Entity<Aula>()
                .HasMany(a => a.Alunos)
                .WithMany(a => a.Aulas)
                .UsingEntity(j => j.ToTable("AlunoAula"));
        }
    }
}
