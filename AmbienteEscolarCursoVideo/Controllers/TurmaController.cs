using AmbienteEscolarCursoVideo.Models;
using AmbienteEscolarCursoVideo.Services.Turma;
using Microsoft.AspNetCore.Mvc;

namespace AmbienteEscolarCursoVideo.Controllers
{
    public class TurmaController : Controller
    {
        private readonly ITurmaInterface _turmaInterface;
        public TurmaController(ITurmaInterface turmaInterface)
        {
            _turmaInterface = turmaInterface;
        }

        [HttpGet]
        public IActionResult ListarTurmas()
        {
            var turmas = _turmaInterface.BuscarTurmas();
            return View(turmas);
        }



        [HttpGet]
        public IActionResult CadastrarTurma()
        {
            return View();
        }


        [HttpPost]
        public IActionResult CadastrarTurma(TurmaModel turmaModel)
        {
            if (ModelState.IsValid)
            {
                var turma = _turmaInterface.CadastrarTurma(turmaModel);

                if(turma == null)
                {
                    TempData["MensagemErro"] = "Nome de turma repetido ou Problema no servidor!";
                    return View(turmaModel);
                }

                TempData["MensagemSucesso"] = "Cadastro de Turma realizado com sucesso!";
                return RedirectToAction("ListarTurmas");
            }
            else
            {
                TempData["MensagemErro"] = "Campos obrigatórios NÃO foram preenchidos!";
                return View(turmaModel);
            }
        }
    }
}
