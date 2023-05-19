using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using StayFit.Context;
using StayFit.Models;

namespace StayFit.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDbContext _context;
		private int salt = 15935;
		public LoginController(AppDbContext context)
        {
            _context = context;
        }
               
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login([Bind("Matricula,Senha")] Usuario usuario)
        {
            var user = _context.Usuarios.FirstOrDefault(u => u.Matricula == usuario.Matricula);
            ViewBag.msg = "";

            if (user == null)
            {   
                ViewBag.msg = "Matricula e/ou senha invalida(s)";
                return View("Teste1");
            }

			//System.Diagnostics.Debug.WriteLine("=====================");
			
			bool isPassValid = BCrypt.Net.BCrypt.Verify(usuario.Senha, user.Senha);

           

            if(!isPassValid)
            {
				ViewBag.msg = "Matricula e/ou senha invalida(s)";
				return View("Teste2");
			}

            return View("~/Views/Home/Index.cshtml", user);
        }
    }
}
