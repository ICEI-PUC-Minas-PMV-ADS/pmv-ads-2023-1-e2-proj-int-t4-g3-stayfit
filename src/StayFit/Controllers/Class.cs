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
		public IActionResult Logar(string email, string senha)
		{

			return Json(new { });
		}
	}
}
