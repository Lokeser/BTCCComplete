using System.ComponentModel;

namespace BancaTCC.Models
{
    public class Banca
    {
        public int Id { get; set; }

        [DisplayName("Dia da Banca")]
        public DateTime Data { get; set; }

        [DisplayName("Horário de Ínicio")]
        public TimeSpan HoraInicio { get; set; }

        [DisplayName("Horário de Término")]
        public TimeSpan HoraFim { get; set; }
        public string Resultado { get; set; }

        [DisplayName("Observações")]
        public string? Observacoes { get; set; }

        // Relação com Trabalhos
        public List<Trabalho> Trabalhos { get; set; } = new List<Trabalho>();

        public int? TrabalhoId { get; set; }

        // Relação com Comentarios
        public List<Comentario> Comentarios { get; set; } = new List<Comentario>();

        // Relação com Membros Externos
        public List<MembroExterior> MembroExteriores { get; set; } = new List<MembroExterior>();

        [DisplayName("Convidado(s)")]
        public int? MembroExteriorId { get; set; }

        // Relação com Professores
        public List<Professor> Professores { get; set; } = new List<Professor>();
        [DisplayName("Professores")]
        public int? ProfessorId { get; set; }
    }
}
