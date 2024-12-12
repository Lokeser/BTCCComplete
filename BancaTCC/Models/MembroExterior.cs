using System.ComponentModel.DataAnnotations;

namespace BancaTCC.Models
{
    public class MembroExterior
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Telefone é obrigatório.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O número de telefone deve conter exatamente 11 dígitos.")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O Email fornecido não é válido.")]
        public string Email { get; set; }

        // Relação com Banca (um membro externo pode participar de várias bancas)
        public List<Banca> Bancas { get; set; } = new List<Banca>();

        public int? BancaId { get; set; }
    }
}
