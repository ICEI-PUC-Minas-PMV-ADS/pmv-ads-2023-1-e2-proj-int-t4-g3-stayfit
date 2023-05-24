using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using StayFit.Context;
using StayFit.Models;
using StayFit.Repositories.Interfaces;

namespace StayFit.Controllers
{
	public class CadastroController : Controller
	{
      
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly IClienteRepository _clienteRepository;
        private readonly ILoginRepository _loginRepository;
		 
		public CadastroController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ILoginRepository loginRepository, IClienteRepository clienteRepository)
		{
			_loginRepository = loginRepository;
			_userManager = userManager;
			_signInManager = signInManager;
			_clienteRepository = clienteRepository;
		} 

		public IActionResult Index()
		{
			return View();
		}

		//[HttpPost]
		//public IActionResult Create(Usuario user)
		//{
		//		user.Senha = BCrypt.Net.BCrypt.HashPassword(user.Senha);
		//		_loginRepository.Create(user);
  //              return View("~/Views/Home/Index.cshtml", user);
                      			
		//}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(Usuario usuario)
		{		
				Cliente cliente = _clienteRepository.GetClienteByCPF(usuario.CPF);
				
				if (cliente != null) 
				{
					usuario.Cliente = cliente;
				}

				var user = new ApplicationUser { UserName = usuario.Email,
					CPF = usuario.CPF, Email = usuario.Email, Cliente = usuario.Cliente  };
				
				var result = await _userManager.CreateAsync(user, usuario.Senha);

				if(result.Succeeded)
				{
					
					return RedirectToAction("Index", "Home");
				}
				else
				{
					this.ModelState.AddModelError("Cadastro", "Falha ao registrar usuário");
				}

			ModelState.AddModelError("", "Falha ao Cadastrar!!");
			return View("Index");
		}
	}
}