using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StayFit.Models;
using StayFit.Repositories.Interfaces;
using StayFit.ViewModels;
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
            IEnumerable<Treino> treinos = _treinoRepository.GetTreinosFicha(FichaId);
            
            TreinoViewModel treinoViewModel = new TreinoViewModel
            {
                TreinoList = treinos,
            };

            return View("~/Views/Admin/Instrutor/Treino/Create.cshtml", treinoViewModel);
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
        public IActionResult UpdateTreinos([FromBody] List<Treino> treinos)
        {
             int fichaid = treinos[0].FichaId;
              System.Diagnostics.Debug.WriteLine("============= Teste " + fichaid);

            foreach(Treino treino in treinos)
            {
                treino.Exercicio = _exercicioRepository.GetExercicio(treino.ExercicioId);
            }

            if (fichaid != 0 || fichaid != null)
            {
                Ficha ficha = _fichaRepository.UpdateTreinosFicha(treinos,fichaid);
                TempData["msgSuccess"] = "Exercício cadastrado com sucesso!";
                return Json(1);
            }
            else
            {
                return Json(0);
            }
            /*  if (_treinoRepository.Create(treino))
              {
                  return Json(treino.RepetitionNumber);
              }
              else
              {
                  return Json(treino.RestTime);
              }*/

            return RedirectToAction("/Admin/Cliente");
        }

     
    }

      
}
