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
		public IActionResult Create(Usuario login)
		{
				login.Senha = BCrypt.Net.BCrypt.HashPassword(login.Senha);
				_loginRepository.Create(login);
                return View("~/Views/Cliente/FichaCliente/Index.cshtml");
          
            
			
				
			
			
		}
	}
}