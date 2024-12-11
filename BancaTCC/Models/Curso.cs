using System.ComponentModel.DataAnnotations;

namespace BancaTCC.Models
{
    public class Curso
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do curso é obrigatório.")]
        public string Nome { get; set; }

        // Validação para garantir que a área seja obrigatória
        [Required(ErrorMessage = "A área é obrigatória.")]
        public string Area { get; set; }

        [Required(ErrorMessage = "A carga horária é obrigatória.")]
        public int CargaHoraria { get; set; }
    }
}
