using BancaRosen.Models;
using System.ComponentModel;

namespace BancaTCC.Models
{
    public class Orientador
    {
        public int Id { get; set; }

        [DisplayName("Ordem de Preferência (1-Ativo, 2-Pendente, 3-Indisponível)")]
        public int OrdemPreferencia { get; set; }
        public StatusOrientador? Status { get; set; } // Ativo, Convidado e  pendente

        // Relação com Professor (um orientador corresponde a um professor)
        public int ProfessorId { get; set; }
        public Professor? Professor { get; set; }

        // Relação com Trabalho (um orientador pode ser indicado para vários trabalhos)
        public List<Trabalho> Trabalhos { get; set; } = new List<Trabalho>();
    }
}
