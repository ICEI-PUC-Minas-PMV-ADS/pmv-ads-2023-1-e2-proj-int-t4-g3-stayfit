using Microsoft.AspNetCore.Mvc;

namespace StayFit.Controllers.Adm
{
	public class AdminHomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
