using AmbienteEscolarCursoVideo.Dto.Professor;
using AmbienteEscolarCursoVideo.Services.Materia;
using AmbienteEscolarCursoVideo.Services.Professor;
using AmbienteEscolarCursoVideo.Services.Turma;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AmbienteEscolarCursoVideo.Controllers
{
    public class ProfessorController : Controller
    {
        private readonly IProfessorInterface _professorInterface;
        private readonly ITurmaInterface _turmaInterface;
        private readonly IMateriaInterface _materiaInterface;

        public ProfessorController(IProfessorInterface professorInterface, 
                                    ITurmaInterface turmaInterface,
                                    IMateriaInterface materiaInterface)
        {
            _professorInterface = professorInterface;
            _turmaInterface = turmaInterface;
            _materiaInterface = materiaInterface;
        }

        [HttpGet]
        public IActionResult ListarProfessor()
        {
            var professores = _professorInterface.BuscarProfessores();
            return View(professores);
        }

        [HttpGet("{id}")]
        public IActionResult DetalhesProfessor(int id)
        {
            var professores = _professorInterface.ObterProfessorComTurmasEAlunos(id);
            return View(professores);
        }

        [HttpGet]
        [Route("/Professor/ProfessoresDaTurma/{idTurma}")]
        public IActionResult ProfessoresDaTurma(int idTurma)
        {
            var professores = _professorInterface.BuscarProfessoresPorTurma(idTurma);
            return Json(new {dados =  professores});
        }

        [HttpGet]
        public IActionResult CadastrarProfessor()
        {
            BuscarTurmas();
            BuscarMaterias();
            return View();
        }

        [HttpPost]
        public IActionResult CadastrarProfessor(ProfessorCriacaoDto professorCriacaoDto)
        {

            if (ModelState.IsValid) {

                var professorModel = _professorInterface.CadastrarProfessor(professorCriacaoDto);

                if (professorModel == null) {
                    TempData["MensagemErro"] = "Ocorreu um erro na operação!";
                    BuscarTurmas();
                    BuscarMaterias();
                    return View(professorCriacaoDto);
                }

                TempData["MensagemSucesso"] = "Professor Cadastrado com sucesso!";

                return RedirectToAction("ListarProfessor");
            }
            else
            {
                TempData["MensagemErro"] = "Campos obrigatórios NÃO foram preenchidos!";
                BuscarTurmas();
                BuscarMaterias();
                return View(professorCriacaoDto);
            }



            return View();
        }



        private void BuscarTurmas()
        {
            var turmas = _turmaInterface.BuscarTurmas();
            var listaTurma = new SelectList(turmas, "Id", "Descricao");

            ViewBag.Turmas = listaTurma;
        }

        private void BuscarMaterias()
        {
            var materias = _materiaInterface.BuscarMaterias();
            var listaMaterias = new SelectList(materias, "Id", "Descricao");

            ViewBag.Materias = listaMaterias;
        }
    }
}
