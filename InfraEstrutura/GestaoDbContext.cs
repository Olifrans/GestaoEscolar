using Core;
using Microsoft.EntityFrameworkCore;


namespace InfraEstrutura
{
    public class GestaoDbContext : DbContext
    {
        public GestaoDbContext(DbContextOptions<GestaoDbContext> options)
        : base(options)
        {
        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Escola> Escolas { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Curso> Cursos { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurações adicionais de modelo, se necessário
            modelBuilder.Entity<Aluno>()
                .HasOne(a => a.Escola)
                .WithMany(e => e.Alunos)
                .HasForeignKey(a => a.EscolaId);

            modelBuilder.Entity<Professor>()
                .HasOne(p => p.Escola)
                .WithMany(e => e.Professores)
                .HasForeignKey(p => p.EscolaId);

            modelBuilder.Entity<Curso>()
                .HasOne(c => c.Professor)
                .WithMany(p => p.Cursos)
                .HasForeignKey(c => c.ProfessorId);

            modelBuilder.Entity<Aluno>()
                .HasMany(a => a.Cursos)
                .WithMany(c => c.Alunos)
                .UsingEntity(j => j.ToTable("AlunoCurso"));
        }

    }
}
