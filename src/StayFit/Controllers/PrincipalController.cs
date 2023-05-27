using Microsoft.AspNetCore.Mvc;

namespace StayFit.Controllers
{
    public class PrincipalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
