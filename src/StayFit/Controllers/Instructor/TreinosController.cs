using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StayFit.Repositories.Interfaces;

namespace StayFit.Controllers.Instructor
{
    public class TreinosController : Controller
    {
        private readonly IExercicioRepository _exercicioRepository;
        public TreinosController(IExercicioRepository exercicioRepository) { 
            _exercicioRepository = exercicioRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {            
            ViewBag.Exercicios = new SelectList(_exercicioRepository.Exercicios, "ExercicioId", "Name"); 
            return View("Instrutor/Treino/Create");
        }
    }
}
