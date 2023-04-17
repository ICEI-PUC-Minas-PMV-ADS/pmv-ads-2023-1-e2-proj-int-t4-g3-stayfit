using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StayFit.Models;
using StayFit.Repositories.Interfaces;

namespace StayFit.Controllers.Instructor
{
    public class TreinosController : Controller
    {
        private readonly IExercicioRepository _exercicioRepository;
        private readonly ITreinoRepository _treinoRepository;

        public TreinosController(IExercicioRepository exercicioRepository, ITreinoRepository treinoRepository) { 
            _exercicioRepository = exercicioRepository;
            _treinoRepository = treinoRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            ViewBag.Exercicios = _exercicioRepository.Exercicios.Select(e => new SelectListItem() { Text = e.Name, Value = e.ExercicioId.ToString() });
                return View("Instrutor/Treino/Create");
        }

        [HttpPost]
        public IActionResult Create(Treino Treino)
        {
            if(ModelState.IsValid)
            {
                if(_treinoRepository.Create(Treino))
                { 
                    return RedirectToAction(nameof(Index));
                }
                 else
                  {
                     return RedirectToAction("Teste");
                  }
              }
                return View("Passou");
        }
    }
}
