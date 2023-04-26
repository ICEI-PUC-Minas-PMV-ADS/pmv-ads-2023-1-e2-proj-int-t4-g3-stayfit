using Microsoft.AspNetCore.Mvc;
using StayFit.Models;
using StayFit.Repositories.Interfaces;
using StayFit.ViewModels;

namespace StayFit.Controllers.Instructor
{
    public class FichaController : Controller
    {
        private readonly IFichaRepository _fichaRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly ITreinoRepository _treinoRepository;
        public FichaController(IFichaRepository fichaRepository, IClienteRepository clienteRepository, ITreinoRepository treinoRepository) 
        { 
            _fichaRepository = fichaRepository;
            _clienteRepository = clienteRepository;
            _treinoRepository = treinoRepository;
        }
        public IActionResult Create(int cliente)
        {
            ViewBag.ClienteId = cliente;
            return View("~/Views/Admin/Instrutor/Fichas/Create.cshtml");
        }

        [HttpPost]
        public IActionResult Create(Ficha ficha)
        {   if (ModelState.IsValid)
            {
                Ficha resposta = _fichaRepository.Create(ficha);
                IEnumerable<Treino> treinos = _treinoRepository.GetTreinosFicha(ficha.FichaId);
           /*     FichaTreinoViewModel fichaTreino = new FichaTreinoViewModel
                {
                    Treino = new Treino(),
                    Treinos = treinos,
                    Ficha = resposta,
                };
           */

                return RedirectToAction("Create", new RouteValueDictionary(
                              new { controller = "Treino", action = "Create", ficha.FichaId }));
               // return View("Views/Admin/Instrutor/Treino/Create.cshtml", fichaTreino);
            }
            return RedirectToAction("Create", new RouteValueDictionary(
                                 new { controller = "Treino", action = "Create" ,ficha.FichaId}));
        }

    }
}
