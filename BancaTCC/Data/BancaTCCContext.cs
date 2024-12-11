using BancaTCC.Models;
using Microsoft.EntityFrameworkCore;

namespace BancaTCC.Data
{
    public class BancaTCCContext:DbContext
    {
        public BancaTCCContext(DbContextOptions<BancaTCCContext> options):base(options) { }

        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Trabalho> Trabalhos { get; set; }
        public DbSet<Banca> Bancas { get; set; }
        public DbSet<MembroExterior> MembrosExternos { get; set; }
        public DbSet<Orientador> OrientadoresIndicados { get; set; }
    }
}
