using System.ComponentModel.DataAnnotations;

namespace BancaTCC.Models
{
    public class Trabalho
    {
        public long? Id { get; set; }
        public string TrabalhoTema { get; set; }
        public string TrabalhoArea { get; set; }
        public string TrabalhoLink { get; set; }
        public string TrabalhoGitLink { get; set; }

    }
}
