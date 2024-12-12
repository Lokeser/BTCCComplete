using System.ComponentModel.DataAnnotations;

namespace BancaTCC.Models
{
    public class Comentario
    {
        public int Id { get; set; }

        [Required]
        public string Texto { get; set; }

        // Relacionamento com Banca
        public int BancaId { get; set; }
        public Banca? Banca { get; set; }

        // Relacionamento com Professor
        public int ProfessorId { get; set; }
        public Professor? Professor { get; set; }
    }
}
