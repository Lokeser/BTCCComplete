using BancaTCC.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public class Curso
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome do curso é obrigatório.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "A área do curso é obrigatória.")]
    public string? Area { get; set; }

    [DisplayName("Carga Horária")]
    [Required(ErrorMessage = "A carga horária é obrigatória.")]
    [Range(1, int.MaxValue, ErrorMessage = "A carga horária deve ser maior que zero.")]
    public int CargaHoraria { get; set; }

    public List<Autor> Autores { get; set; } = new List<Autor>();
    public List<Professor> Professores { get; set; } = new List<Professor>();

    public int? AutorId { get; set; }

    public int? ProfessorId { get; set; }
}
