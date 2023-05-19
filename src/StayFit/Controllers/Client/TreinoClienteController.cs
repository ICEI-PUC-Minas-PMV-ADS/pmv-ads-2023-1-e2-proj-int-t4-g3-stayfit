using Microsoft.AspNetCore.Mvc;
using StayFit.Models;
using StayFit.Repositories.Interfaces;

namespace StayFit.Controllers.Client
{
    public class TreinoClienteController : Controller
    {

        private readonly IExercicioRepository _exercicioRepository;
        private readonly ITreinoRepository _treinoRepository;
        private readonly IFichaRepository _fichaRepository;

        public TreinoClienteController(IExercicioRepository exercicioRepository, ITreinoRepository treinoRepository, IFichaRepository fichaRepository)
        {
            _exercicioRepository = exercicioRepository;
            _treinoRepository = treinoRepository;
            _fichaRepository = fichaRepository;
        }

        public ViewResult Cronometrar()
        {
            Treino treino = _treinoRepository.GetTreino(52);
            return View("~/Views/Cliente/FichaCliente/Cronometrar.cshtml", treino);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
