using Microsoft.AspNetCore.Mvc;
using StayFit.Models;
using StayFit.Repositories.Interfaces;

namespace StayFit.Controllers.Instructor
{
    public class InstrutorController : Controller
    {
        private readonly IAvalicaoFisicaRepository _avalicaoFisicaRepository;

        public InstrutorController(IAvalicaoFisicaRepository avalicaoFisicaRepository)
        {
            _avalicaoFisicaRepository = avalicaoFisicaRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult av()
        {
            return Json(new Avaliacao());
        }

        public ViewResult Avaliar()
        {
           // Avaliacao avaliacao = new Avaliacao();
          //  _avalicaoFisicaRepository.Create(avaliacao);
            return View("~/Views/Admin/Instrutor/Avaliacao/Avaliacao.cshtml");
        }

        [HttpPost]
        public IActionResult UpdateAnamnese([FromBody] Avaliacao avaliacao)
        {
            System.Diagnostics.Debug.WriteLine("============>>> " + avaliacao.Peso);
            Avaliacao av =new Avaliacao();
            if(ModelState.IsValid) {
                av = _avalicaoFisicaRepository.UpdateAnamnese(avaliacao);
            }
            else
            {
                return Json(3);
            }
            if (av == null)
            {
                  return Json(0);
            }

            return Json(1);
        }
    }
}
