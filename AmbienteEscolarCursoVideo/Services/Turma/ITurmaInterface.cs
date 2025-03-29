using AmbienteEscolarCursoVideo.Models;

namespace AmbienteEscolarCursoVideo.Services.Turma
{
    public interface ITurmaInterface
    {
        List<TurmaModel> BuscarTurmas();
        TurmaModel CadastrarTurma(TurmaModel turmaModel);

    }
}
