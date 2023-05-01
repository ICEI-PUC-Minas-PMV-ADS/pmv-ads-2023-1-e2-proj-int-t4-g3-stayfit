using Microsoft.AspNetCore.Mvc;
using StayFit.Models;
using StayFit.Repositories;
using StayFit.Repositories.Interfaces;

namespace StayFit.Controllers.Instructor
{
    public class ExercicioController : Controller
    {
        private readonly IExercicioRepository _exercicioRepository;

        public ExercicioController(IExercicioRepository exercicioRepository)
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
            try
            {
                if (ModelState.IsValid)
                {
                    _exercicioRepository.Create(exercicio);
                    TempData["MsgSuccess"] = "Exercício cadastrado com sucesso!";
                    return RedirectToAction(nameof(Index));

                }

            }
            catch(System.Exception ex)
            {
                TempData["MsgSuccess"] = $"Não foi possivel cadastrar o exercício! {ex.Message}";
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/Admin/Instrutor/Exercicios/Create.cshtml", exercicio);
          }

        public ViewResult Detail(int ExercicioId)
        {
            Exercicio exercicio = _exercicioRepository.GetExercicio(ExercicioId);
            return View("~/Views/Admin/Instrutor/Exercicios/Detail.cshtml", exercicio);
        }
    }
}
