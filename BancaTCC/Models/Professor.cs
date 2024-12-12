using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BancaTCC.Models
{
    public class Professor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; }

        [DisplayName("Matrícula")]
        [Required(ErrorMessage = "O campo Matricula é obrigatório.")]
        public string Matricula { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O Email fornecido não é válido.")]
        public string Email { get; set; }

        // Relação com Curso (um professor pode lecionar em vários cursos)
        public List<Curso> Cursos { get; set; } = new List<Curso>();

        public int? CursoId { get; set; }

        // Relação com Banca (um professor pode participar de várias bancas)
        public List<Banca> Bancas { get; set; } = new List<Banca>();

        public List<Comentario> Comentarios { get; set; } = new List<Comentario>(); // Lista de comentários

        public int? BancaId { get; set; }
    }
}
