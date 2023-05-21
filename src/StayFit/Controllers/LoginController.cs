using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using StayFit.Context;
using StayFit.Models;
using System.Security.Claims;

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
        public IActionResult Login([Bind("Email,Senha")] Usuario usuario)
        {
            var user = _context.Usuarios.FirstOrDefault(u => u.Email == usuario.Email);
            ViewBag.msg = "";

            if (user == null)
            {   
                ViewBag.msg = "Email e/ou senha invalida(s)";
                return View("Index");
            }

			//System.Diagnostics.Debug.WriteLine("=====================");
			
			bool isPassValid = BCrypt.Net.BCrypt.Verify(usuario.Senha, user.Senha);


            if(!isPassValid)
            {
				ViewBag.msg = "Email e/ou senha invalida(s)";
				return View("Index");
			}


            return View("~/Views/Home/Index.cshtml", user);
        }
    }
}
