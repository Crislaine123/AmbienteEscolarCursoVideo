using AmbienteEscolarCursoVideo.Dto.Professor;
using AmbienteEscolarCursoVideo.Models;

namespace AmbienteEscolarCursoVideo.Services.Professor
{
    public interface IProfessorInterface
    {
        List<ProfessorModel> BuscarProfessores();
        ProfessorModel ObterProfessorComTurmasEAlunos(int id);
        ProfessorModel CadastrarProfessor(ProfessorCriacaoDto professorCriacaoDto);
        List<ProfessorModel> BuscarProfessoresPorTurma(int idTurma);
    }
}
