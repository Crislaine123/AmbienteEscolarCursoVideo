using AmbienteEscolarCursoVideo.Data;
using AmbienteEscolarCursoVideo.Models;
using Microsoft.EntityFrameworkCore;

namespace AmbienteEscolarCursoVideo.Services.Turma
{
    public class TurmaService : ITurmaInterface
    {

        private readonly AppDbContext _context;
        public TurmaService(AppDbContext context)
        {
            _context = context;
        }


        public List<TurmaModel> BuscarTurmas()
        {
            try
            {
                var turmas = _context.Turmas.Include( a => a.Alunos).Include(p => p.Professores).ToList();               
                return turmas;
            }
            catch
            {
                return null;
            }
        }

        public TurmaModel CadastrarTurma(TurmaModel turmaModel)
        {
            try
            {
                if (!VerificaNomeTurma(turmaModel)) 
                {
                    return null;               
                }


                _context.Turmas.Add(turmaModel);
                _context.SaveChanges();

                return turmaModel;

            }
            catch
            {
                return null;
            }
        }


        private bool VerificaNomeTurma(TurmaModel turmaModel)
        {
            var turma = _context.Turmas.FirstOrDefault(turma => turma.Descricao == turmaModel.Descricao);

            if (turma == null) 
            {
                return true;
            }

            return false;

        }

    }
}
