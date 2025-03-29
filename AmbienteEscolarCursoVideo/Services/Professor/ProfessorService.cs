using AmbienteEscolarCursoVideo.Data;
using AmbienteEscolarCursoVideo.Dto.Professor;
using AmbienteEscolarCursoVideo.Models;
using Microsoft.EntityFrameworkCore;

namespace AmbienteEscolarCursoVideo.Services.Professor
{
    public class ProfessorService : IProfessorInterface
    {
        private readonly AppDbContext _context;

        public ProfessorService(AppDbContext context)
        {
            _context = context;
        }

        public List<ProfessorModel> BuscarProfessores()
        {
            try
            {

                var professores = _context.Professores.Include(t => t.Turmas).Include(m => m.Materia).ToList();

                return professores;
            }
            catch
            {
                return null;
            }
        }

        public List<ProfessorModel> BuscarProfessoresPorTurma(int idTurma)
        {
            try
            {

                    var professoresDaTurma = _context.Turmas
                            .Where(t => t.Id == idTurma)
                            .SelectMany(t => t.Professores)
                            .Include(m=> m.Materia)
                            .ToList();


                return professoresDaTurma;


            }
            catch
            {
                return null;
            }
        }

        public ProfessorModel CadastrarProfessor(ProfessorCriacaoDto professorCriacaoDto)
        {
            try{

                var turmasSelecionadas = _context.Turmas.Where(t => professorCriacaoDto.TurmasId.Contains(t.Id)).ToList();

                var professorModel = new ProfessorModel
                {
                    Nome = professorCriacaoDto.Nome,
                    Email = professorCriacaoDto.Email,
                    DataContratacao = professorCriacaoDto.DataContratacao,
                    MateriaId = professorCriacaoDto.MateriaId,
                    Turmas = turmasSelecionadas

                };

                _context.Professores.Add(professorModel);
                _context.SaveChanges();

                return professorModel;

            }
            catch
            {
                return null;
            }
        }

        public ProfessorModel ObterProfessorComTurmasEAlunos(int id)
        {
            try
            {

                var professorTurmasAlunos = _context.Professores
                                                .Where(p => p.Id == id)
                                                .Include(t => t.Turmas)
                                                .ThenInclude(a => a.Alunos)
                                                .FirstOrDefault();

                return professorTurmasAlunos;


            }
            catch
            {
                return null;
            }
        }
    }
}
