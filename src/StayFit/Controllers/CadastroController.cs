using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace StayFit.Controllers
{
	public class CadastroController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Cadastrar(string name, string email, int cpf, int Matricula, DateOnly date)
		{

			return Json(new { });
		}
	}
}