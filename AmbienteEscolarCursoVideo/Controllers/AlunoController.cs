using AmbienteEscolarCursoVideo.Models;
using AmbienteEscolarCursoVideo.Services.Aluno;
using AmbienteEscolarCursoVideo.Services.Turma;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace AmbienteEscolarCursoVideo.Controllers
{
    public class AlunoController : Controller
    {
        private readonly IAlunoInterface _alunoInterface;
        private readonly ITurmaInterface _turmaInterface;

        public AlunoController(IAlunoInterface alunoInterface, ITurmaInterface turmaInterface)
        {
            _alunoInterface = alunoInterface;
            _turmaInterface = turmaInterface;
        }


        [HttpGet]
        public IActionResult ListarAlunos()
        {
            var alunos = _alunoInterface.BuscarAlunos();
            return View(alunos);
        }

        [HttpGet]
        public IActionResult CadastrarAluno()
        {
            BuscarTurmas();
            return View();
        }

        [HttpGet]
        [Route("/Aluno/BuscarAlunoPorMatricula")]
        public IActionResult BuscarAlunoPorMatricula(int matricula)
        {
            var aluno = _alunoInterface.BuscarAlunoPorMatricula(matricula);
            return Json(new {dados = aluno});
        }

        [HttpGet]
        [Route("/Aluno/AlunosDaTurma/{idTurma}")]
        public IActionResult AlunosDaTurma(int idTurma)
        {
            var alunos = _alunoInterface.BuscarAlunosPorTurma(idTurma);
            return Json(new {dados = alunos});
        }


        [HttpPost]
        public IActionResult CadastrarAluno(AlunoModel alunoModel)
        {
            if (ModelState.IsValid) {

                var aluno = _alunoInterface.CadastrarAluno(alunoModel);

                if (aluno == null) {
                    TempData["MensagemErro"] = "Ocorreu um erro na operação!";
                    BuscarTurmas();
                    return View(alunoModel);

                }

                TempData["MensagemSucesso"] = "Aluno Cadastrado com sucesso!";
                return RedirectToAction("ListarAlunos");

            }
            else
            {
                TempData["MensagemErro"] = "Campos obrigatórios NÃO foram preenchidos!";
                BuscarTurmas();
                return View(alunoModel);
            }
        }


        private void BuscarTurmas()
        {
            var turmas = _turmaInterface.BuscarTurmas();

            var listaTurma = new SelectList(turmas, "Id", "Descricao");

            ViewBag.Turmas = listaTurma;
        }
    }
}
