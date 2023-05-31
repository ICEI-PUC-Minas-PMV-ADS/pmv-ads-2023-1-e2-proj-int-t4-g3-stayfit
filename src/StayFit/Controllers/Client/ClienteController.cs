using Microsoft.AspNetCore.Mvc;
using StayFit.helpers;
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

		public ViewResult Edit()
        {
            Usuario usuario = _usuarioRepository.GetUserByEmail(User.Identity.Name);
            System.Diagnostics.Debug.WriteLine("================ " + usuario.Nome);
            return View("~/Views/Cliente/EditCliente.cshtml", usuario);
        }


        public IActionResult Ficha()
        {
            Usuario usuario = _usuarioRepository.GetUserByEmail(User.Identity.Name);
                      
                if(usuario.Cliente != null)
                {
                    Cliente cliente = _clienteRepository.GetCliente(usuario.Cliente.ClienteId);
                    IEnumerable<Ficha> fichas = _fichaRepository.GetFichasClient(usuario.Cliente.ClienteId);
                    IEnumerable<Treino> treinos = new List<Treino>();
                    foreach (Ficha ficha in fichas)
                    {
                        foreach (Treino t in ficha.Treinos)
                        {
                            treinos.Append(t);
                            t.Exercicio = _exercicioRepository.GetExercicio(t.ExercicioId);
                        }
                    }

                    ClienteFichaViewModel clienteFichaViewModel = new ClienteFichaViewModel
                    {
                        Usuario = usuario,
                        fichas = fichas,

                    };

                    return View("~/Views/Cliente/FichaCliente/Index.cshtml", clienteFichaViewModel);
                
            }
            return RedirectToAction("Index", "Login");          
           
        }

        [HttpPost]
        public async Task<ViewResult> EditUsuario(Usuario usuario, [FromForm(Name = "Foto")] IFormFile Photo)
        {
            string path = "wwwroot/PrivateFiles/users/imagens/";
            string url = "/PrivateFiles/users/imagens/";

            if (Photo != null && Photo.Length > 0)
            {
                // var fileName = exercicio.Name.ToLower() + Path.GetFileName(Photo.FileName).ToLower()  ;
                var fileName = Path.GetFileName(Photo.FileName).ToLower();
                if (await FileUpload.imageUpload(Photo, path))
                {
                    usuario.Foto = $"{url}{fileName}";
                    System.Diagnostics.Debug.WriteLine("=========== " + usuario.Foto + " =============");
                }

            }
            usuario = _usuarioRepository.EditUsuario(usuario, User.Identity.Name);

            return View("~/Views/Home/Index.cshtml", usuario);
        }


        public ViewResult Avaliacao()
        {
            Usuario usuario = _usuarioRepository.GetUserByEmail(User.Identity.Name);
            return View("~/Views/Cliente/ResultadoAvaliacao.cshtml", usuario);
        }
    }
}
