using Microsoft.AspNetCore.Mvc;
using StayFit.Models;
using StayFit.Repositories.Interfaces;

namespace StayFit.Controllers.Adm
{
	public class AdminInstrutorController : Controller
	{
		private readonly IInsturtorRepository _insturtorRepository;
		public AdminInstrutorController(IInsturtorRepository insturtorRepository)
		{
			_insturtorRepository = insturtorRepository;
		}
		public IActionResult Index()
		{
			return View();
		}

		public ViewResult Create()
		{
			return View("~/Views/Admin/Admin/AdminInstrutor/Create.cshtml");
		}

		[HttpPost]
		public ViewResult Create(Instrutor instructor)
		{
			Instrutor inst = _insturtorRepository.Create(instructor);
			if(inst == null)
			{
                return View("~/Views/Admin/Admin/AdminClient/Index.cshtml");
            }
			return View("~/Views/Admin/Admin/AdminClient/ListClient.cshtml");
        }
	}
}
