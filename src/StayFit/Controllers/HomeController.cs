using Microsoft.AspNetCore.Mvc;
using StayFit.Context;
using StayFit.Models;
using StayFit.Repositories.Interfaces;
using StayFit.ViewModels;
using System.Collections.Generic;
using System.Diagnostics;

namespace StayFit.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context, ILogger<HomeController> logger, IUsuarioRepository usuarioRepository, IClienteRepository clienteRepository)
        {
            _logger = logger;
            _usuarioRepository = usuarioRepository;
            _context = context;
        }

      
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated == false)            
              return RedirectToAction("Index", "Login");

            Usuario usuario = _usuarioRepository.GetUserByEmail(User.Identity.Name);
          
            if(usuario!=null && usuario.TipoUsuario == TypeUser.Cliente)
            {
                 UsuarioViewModel usuarioViewModel = new UsuarioViewModel
                 {
                     Usuario = usuario,
                     NomeUsuario = usuario.Nome.Split(' ')[0],
                 };
                 return View(usuarioViewModel);
            }

            if(usuario != null && usuario.TipoUsuario == TypeUser.Instrutor)
            {
				 
				InstrutorClienteViewModel viewModel = new InstrutorClienteViewModel
                {
                    Usuario = usuario,
                    Clientes = _context.Clientes,
			};
             return View("Instrutor", viewModel);

            }

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