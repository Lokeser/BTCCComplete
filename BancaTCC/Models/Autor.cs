using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BancaTCC.Models
{
    public class Autor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O Nome deve ter no máximo 100 caracteres.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O campo Matrícula é obrigatório.")]
        [StringLength(20, ErrorMessage = "Insira uma matricula válida")]
        public string? Matricula { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O Email fornecido não é válido.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "O campo Curso é obrigatório.")]
        public int CursoId { get; set; }

        public Curso? Curso { get; set; }
    }
}

