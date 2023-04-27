using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StayFit.Models;
using StayFit.Repositories.Interfaces;
using System.Text.Json.Nodes;

namespace StayFit.Controllers.Instructor
{
    public class TreinoController : Controller
    {
        private readonly IExercicioRepository _exercicioRepository;
        private readonly ITreinoRepository _treinoRepository;
        private readonly IFichaRepository _fichaRepository;
        public TreinoController(IExercicioRepository exercicioRepository, ITreinoRepository treinoRepository, IFichaRepository fichaRepository) { 
            _exercicioRepository = exercicioRepository;
            _treinoRepository = treinoRepository;
            _fichaRepository = fichaRepository; 
        }
        public IActionResult Index()
        {
            return View("~/Views/Admin/Instrutor/Treino/Index.cshtml");
        }

        public IActionResult Create(int FichaId)
        {
            ViewBag.FichaId = FichaId;
            ViewBag.Exercicios = _exercicioRepository.Exercicios.Select(e => new SelectListItem() { Text = e.Name, Value = e.ExercicioId.ToString() });
                return View("~/Views/Admin/Instrutor/Treino/Create.cshtml");
        }

        [HttpPost]
        public IActionResult Create(Treino treino)
        {
            if(ModelState.IsValid)
            {
                if(_treinoRepository.Create(treino))
                { 
                    return Json(treino);
                }
                 else
                  {
                     return RedirectToAction("Teste");
                  }
              }
                return View("Passou");
        }

       
        [HttpPost]
        public JsonResult UpdateTreinos([FromBody] List<Treino> treinos)
        {
             int fichaid = treinos[0].FichaId;
              System.Diagnostics.Debug.WriteLine("============= Teste " + fichaid);

            if (fichaid != 0 || fichaid != null)
            {
                Ficha ficha = _fichaRepository.UpdateTreinosFicha(treinos,fichaid);
            }
            else
            {
                return Json(1111);
            }
            /*  if (_treinoRepository.Create(treino))
              {
                  return Json(treino.RepetitionNumber);
              }
              else
              {
                  return Json(treino.RestTime);
              }*/

            return Json(treinos[0].FichaId);
        }

     
    }

      
}
