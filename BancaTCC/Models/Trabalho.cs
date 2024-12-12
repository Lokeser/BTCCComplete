using System.ComponentModel;

namespace BancaTCC.Models
{
    public class Trabalho
    {
        public int Id { get; set; }

        [DisplayName("Nome do Trabalho")]
        public string TrabalhoTema { get; set; }

        [DisplayName("Area do Trabalho")]
        public string TrabalhoArea { get; set; }

        [DisplayName("Link do Documento")]
        public string TrabalhoLink { get; set; }

        [DisplayName("Link do Github")]
        public string TrabalhoGitLink { get; set; }

        // Relação com Autor (um trabalho tem um autor principal)
        public int AutorId { get; set; }
        public Autor? Autor { get; set; }

        // Relação com Banca (um trabalho é associado a uma única banca)
        public int? BancaId { get; set; }
        public Banca? Banca { get; set; }
    }
}
