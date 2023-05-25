using Microsoft.AspNetCore.Mvc;

namespace StayFit.Controllers.Adm
{
	public class AdminInstrutorController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public ViewResult Create()
		{
			return View("~/Views/Admin/Admin/AdminInstrutor/Create.cshtml");
		}
	}
}
