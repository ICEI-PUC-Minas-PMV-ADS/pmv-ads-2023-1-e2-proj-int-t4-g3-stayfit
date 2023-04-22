using Microsoft.AspNetCore.Mvc;
using StayFit.Models;
using StayFit.Repositories;
using StayFit.Repositories.Interfaces;

namespace StayFit.Controllers.Instructor
{
    public class ExerciciosController : Controller
    {
        private readonly IExercicioRepository _exercicioRepository;

        public ExerciciosController(IExercicioRepository exercicioRepository)
        {
            _exercicioRepository = exercicioRepository;
        }
        public IActionResult Index()
        {
            IEnumerable<Exercicio> exercicios = _exercicioRepository.Exercicios;
            return View("~/Views/Admin/Instrutor/Exercicios/Index.cshtml", exercicios);
        }


        public IActionResult Create()
        {
            return View("~/Views/Admin/Instrutor/Exercicios/Create.cshtml");
        }

        [HttpPost]
        public IActionResult Create(Exercicio exercicio)
        {
            if(ModelState.IsValid)
            {
                if(_exercicioRepository.Create(exercicio))
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return RedirectToAction("Teste");
                }
            }

            return View();
        }
    }
}
