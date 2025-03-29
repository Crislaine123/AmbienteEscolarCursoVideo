using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AmbienteEscolarCursoVideo.Models
{
    public class AlunoModel
    {
        public int Id { get; set; }
        public int Matricula { get; set; }
        [Required(ErrorMessage = "O Campo Nome é Obrigatório")]
        public string Nome { get; set; }
        public string? Email { get; set; }
        [Required(ErrorMessage = "O Campo Data De Nascimento é Obrigatório")]
        public DateTime? DataNascimento { get; set; }
        public int TurmaId { get; set; }
        [JsonIgnore]
        public TurmaModel? Turma { get; set; }
    }
}
