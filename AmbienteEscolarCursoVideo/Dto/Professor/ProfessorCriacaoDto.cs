using System.ComponentModel.DataAnnotations;

namespace AmbienteEscolarCursoVideo.Dto.Professor
{
    public class ProfessorCriacaoDto
    {
        [Required(ErrorMessage = "Campo Nome é Obrigatório")]
        public string Nome { get; set; }
            
        [Required(ErrorMessage = "Campo Email é Obrigatório")]
        public string Email { get; set; }
            
        [Required(ErrorMessage = "Campo Data da Contratação é Obrigatório")]
        public DateTime? DataContratacao { get; set; }
            
        [Required(ErrorMessage = "Selecione uma matéria")]
        public int? MateriaId { get; set; }
            
        [Required(ErrorMessage = "Selecione ao menos uma turma")]
        public List<int?> TurmasId { get; set; }

    }
}
