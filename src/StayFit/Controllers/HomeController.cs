using Microsoft.AspNetCore.Mvc;
using StayFit.Models;
using StayFit.Repositories.Interfaces;
using System.Diagnostics;

namespace StayFit.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUsuarioRepository _usuarioRepository;
        public HomeController(ILogger<HomeController> logger, IUsuarioRepository usuarioRepository)
        {
            _logger = logger;
            _usuarioRepository = usuarioRepository;
        }

      
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated == false)            
              return RedirectToAction("Index", "Login");

            Usuario usuario = _usuarioRepository.GetUserByEmail(User.Identity.Name);
            if(usuario!=null || usuario.TipoUsuario == TypeUser.Cliente)
             return View(usuario);

            if(usuario != null || usuario.TipoUsuario == TypeUser.Instrutor)
             return View("Instrutor", usuario);

            usuario.Nome = "Error";
            return View(usuario);
           
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}