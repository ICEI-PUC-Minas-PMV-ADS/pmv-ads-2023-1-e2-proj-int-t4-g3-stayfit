using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using StayFit.Models;
using StayFit.Repositories.Interfaces;

namespace StayFit.Controllers
{
	public class CadastroController : Controller
	{
		private readonly ILoginRepository _loginRepository;
		 
		public CadastroController(ILoginRepository loginRepository)
		{
			_loginRepository = loginRepository;
		} 

		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Usuario user)
		{
				user.Senha = BCrypt.Net.BCrypt.HashPassword(user.Senha);
				_loginRepository.Create(user);
                return View("~/Views/Home/Index.cshtml", user);
                      			
		}
	}
}