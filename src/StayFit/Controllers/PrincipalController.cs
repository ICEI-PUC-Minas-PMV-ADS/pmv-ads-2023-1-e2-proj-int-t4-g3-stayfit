using Microsoft.AspNetCore.Mvc;
using StayFit.Context;
using StayFit.Models;

namespace StayFit.Controllers
{
    public class PrincipalController : Controller
    {
        private readonly AppDbContext _context;

        public PrincipalController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ViewResult Contato()
        {
            return View();
        }

        [HttpPost]
        public async Task<ViewResult> Contato(Contato contato)
        {
            if(ModelState.IsValid)
            {
                _context.Contatos.Add(contato);
               await _context.SaveChangesAsync();
              
                ViewBag.Contato = "Obrigado pelo por nos contatar, em breve estaremos respondendo a sua solicitação!"; 
               
                return View("Index");
            }
            ViewBag.Contato = "Não conseguimos atender a sua solicitação... <br> Por vafor, tente novamente mais tarde!";

            return View(contato);
        }
    }
}
