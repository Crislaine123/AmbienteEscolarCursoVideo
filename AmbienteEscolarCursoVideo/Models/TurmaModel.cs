using System.ComponentModel.DataAnnotations;

namespace AmbienteEscolarCursoVideo.Models
{
    public class TurmaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "A descrição é obrigátoria!")]
        public string Descricao { get; set; }
        public string Modalidade { get; set; }
        public string Turno { get; set; }
        public List<ProfessorModel>? Professores { get; set; }
        public List<AlunoModel>? Alunos { get; set; }
    }
}
