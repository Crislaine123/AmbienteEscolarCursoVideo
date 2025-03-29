using System.Text.Json.Serialization;

namespace AmbienteEscolarCursoVideo.Models
{
    public class ProfessorModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime? DataContratacao { get; set; }
        public int? MateriaId { get; set; }

        public MateriaModel Materia { get; set; }

        [JsonIgnore]
        public List<TurmaModel> Turmas { get; set; }

    }
}
