using AmbienteEscolarCursoVideo.Models;

namespace AmbienteEscolarCursoVideo.Services.Historico
{
    public interface IHistoricoInterface
    {
        List<HistoricoModel> GerarHistorico(int idAluno);
        List<HistoricoModel> BuscarNotas();
        HistoricoModel AtualizarNota(int idHistorico, string campo, string valor);
        HistoricoModel RemoverNota(int idHistorico);
        HistoricoModel SalvarNotas(HistoricoModel historico, int matricula, int materiaId);
    }
}
