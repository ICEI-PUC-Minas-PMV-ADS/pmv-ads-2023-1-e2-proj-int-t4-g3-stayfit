using Microsoft.AspNetCore.Mvc;
using StayFit.Models;
using StayFit.Repositories.Interfaces;
using StayFit.ViewModels;

namespace StayFit.Controllers.Client
{
    public class FichaClienteController : Controller
    {
        private readonly IExercicioRepository _exercicioRepository;
       
        private readonly IFichaRepository _fichaRepository;
        private readonly IClienteRepository _clienteRepository;

        public FichaClienteController(IClienteRepository clienteRepository, IFichaRepository fichaRepository, IExercicioRepository exercicioRepository)
        {
            _exercicioRepository = exercicioRepository;
            _clienteRepository = clienteRepository;
            _fichaRepository = fichaRepository;
           
        }
        public IActionResult Index()
        {

          //LEMBRAR DE MUDAR ID DO CLIENTE------------------------------
            int clientID = 11;
            Cliente cliente = _clienteRepository.GetCliente(clientID);
            IEnumerable< Ficha > fichas = _fichaRepository.GetFichasClient(clientID);
            
            foreach(Ficha ficha in fichas)
            {
                foreach(Treino t in ficha.Treinos)
                {
                    t.Exercicio = _exercicioRepository.GetExercicio(t.ExercicioId);
                }
            }
          
            ClienteFichaViewModel clienteFichaViewModel = new ClienteFichaViewModel
            {
                cliente = cliente,
                fichas = fichas,
            };

            return View("~/Views/Cliente/FichaCliente/Index.cshtml", clienteFichaViewModel);
        }
    }
}
