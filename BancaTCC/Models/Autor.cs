using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BancaTCC.Models
{
    public class Autor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O Nome deve ter no máximo 100 caracteres.")]
        public string? Nome { get; set; }

        [DisplayName("Matrícula")]
        [Required(ErrorMessage = "O campo Matrícula é obrigatório.")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Insira uma matricula válida")]
        public string? Matricula { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O Email fornecido não é válido.")]
        public string? Email { get; set; }

        // Relação com Curso (um autor estuda em um curso)
        [DisplayName("Curso")]
        public int CursoId { get; set; }
        public Curso? Curso { get; set; }

        // Relação com Trabalho (um autor pode ser associado a vários trabalhos)
        public List<Trabalho> Trabalhos { get; set; } = new List<Trabalho>();
    }
}
