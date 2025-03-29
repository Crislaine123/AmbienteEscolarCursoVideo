using AmbienteEscolarCursoVideo.Models;

namespace AmbienteEscolarCursoVideo.Services.Aluno
{
    public interface IAlunoInterface
    {
        List<AlunoModel> BuscarAlunosPorTurma(int idTurma);
        List<AlunoModel> BuscarAlunos();
        AlunoModel CadastrarAluno(AlunoModel alunoModel);
        AlunoModel BuscarAlunoPorMatricula(int matricula);
            
    }
}
