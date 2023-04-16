using Microsoft.AspNetCore.Mvc;

namespace StayFit.Controllers.Adm
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
