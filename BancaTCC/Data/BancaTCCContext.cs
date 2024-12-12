using BancaTCC.Models;
using Microsoft.EntityFrameworkCore;

namespace BancaTCC.Data
{
    public class BancaTCCContext : DbContext
    {
        public BancaTCCContext(DbContextOptions<BancaTCCContext> options)
            : base(options)
        {
        }

        public DbSet<Professor> Professores { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Trabalho> Trabalhos { get; set; }
        public DbSet<Banca> Bancas { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<MembroExterior> MembrosExternos { get; set; }
        public DbSet<Orientador> OrientadoresIndicados { get; set; }
        public DbSet<Comentario> Comentarios { get; set; } // Adicionando DbSet para Comentarios

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração do relacionamento entre Autor e Curso
            modelBuilder.Entity<Autor>()
                .HasOne(a => a.Curso)
                .WithMany(c => c.Autores)
                .HasForeignKey(a => a.CursoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuração do relacionamento entre Autor e Trabalho
            modelBuilder.Entity<Trabalho>()
                .HasOne(t => t.Autor)
                .WithMany(a => a.Trabalhos)
                .HasForeignKey(t => t.AutorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relacionamento entre Trabalho e Banca
            modelBuilder.Entity<Trabalho>()
                .HasOne(t => t.Banca)
                .WithMany(b => b.Trabalhos)
                .HasForeignKey(t => t.BancaId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relacionamento entre Curso e Professor (muitos para muitos)
            modelBuilder.Entity<Curso>()
                .HasMany(c => c.Professores)
                .WithMany(p => p.Cursos)
                .UsingEntity(j => j.ToTable("CursoProfessor"));

            // Relacionamento entre Professor e Banca (muitos para muitos)
            modelBuilder.Entity<Banca>()
                .HasMany(b => b.Professores)
                .WithMany(p => p.Bancas)
                .UsingEntity(j => j.ToTable("BancaProfessor"));

            // Relacionamento entre Orientador e Professor (um para um)
            modelBuilder.Entity<Orientador>()
                .HasOne(o => o.Professor)
                .WithOne()
                .HasForeignKey<Orientador>(o => o.ProfessorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relacionamento entre Orientador e Trabalho (um para muitos)
            modelBuilder.Entity<Orientador>()
                .HasMany(o => o.Trabalhos)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);

            // Relacionamento entre Comentarios, Banca e Professor
            modelBuilder.Entity<Comentario>()
                .HasOne(c => c.Banca)
                .WithMany(b => b.Comentarios)
                .HasForeignKey(c => c.BancaId)
                .OnDelete(DeleteBehavior.Cascade); // Comentários serão removidos ao excluir a Banca

            modelBuilder.Entity<Comentario>()
                .HasOne(c => c.Professor)
                .WithMany(p => p.Comentarios)
                .HasForeignKey(c => c.ProfessorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
