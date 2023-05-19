using Microsoft.AspNetCore.Mvc;
using StayFit.Models;
using StayFit.Repositories.Interfaces;
using StayFit.ViewModels;

namespace StayFit.Controllers.Client
{
    public class ClienteController : Controller
    {
        private readonly IExercicioRepository _exercicioRepository;
       
        private readonly IFichaRepository _fichaRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        public ClienteController(IClienteRepository clienteRepository, IFichaRepository fichaRepository, IExercicioRepository exercicioRepository, IUsuarioRepository usuarioRepository)
        {
            _exercicioRepository = exercicioRepository;
            _clienteRepository = clienteRepository;
            _fichaRepository = fichaRepository;
           _usuarioRepository = usuarioRepository;
        }

        [HttpPost]
		public IActionResult addMatricula(Usuario usuario)
		{
		
            Cliente cliente = _clienteRepository.GetClienteByMatricula((int)usuario.Matricula);
            Usuario user = usuario;

			if (cliente != null)
            {
                usuario.Cliente = cliente;
                user = _usuarioRepository.UpdateUsuarioCliente(usuario);

				System.Diagnostics.Debug.WriteLine("================ " + usuario.Matricula);
				System.Diagnostics.Debug.WriteLine("================ " + usuario.UsuarioId);
			}
            else
            {
				System.Diagnostics.Debug.WriteLine("================ NULO" );
			}
			return View("~/Views/Home/Index.cshtml", user);
		}

		public ViewResult Edit(int id)
        {
            System.Diagnostics.Debug.WriteLine("================ " + id);
            return View("~/Views/Cliente/EditCliente.cshtml");
        }


        public IActionResult Index()
        {

          //LEMBRAR DE MUDAR ID DO CLIENTE------------------------------
            int clientID = 1;
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
