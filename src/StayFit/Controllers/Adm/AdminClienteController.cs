using Microsoft.AspNetCore.Mvc;
using StayFit.Context;
using StayFit.Models;
using StayFit.Repositories.Interfaces;

namespace StayFit.Controllers.Adm
{
    public class AdminClienteController : Controller
    {
        public AppDbContext _context;
        public IClienteRepository _clienteRepository;
        public AdminClienteController(AppDbContext context, IClienteRepository clienteRepository)
        {
            _context = context;
            _clienteRepository = clienteRepository;
        }

        public ViewResult ListClient()
        {
            IEnumerable<Cliente> clientes = _clienteRepository.Clientes;
            return View("~/Views/Admin/Admin/AdminCliente/ListClient.cshtml", clientes);
        }


        public ViewResult CreateClient()
        {

            return View("~/Views/Admin/Admin/AdminCliente/CreateClient.cshtml");
        }

        [HttpPost]  
        public async Task<ViewResult> CreateClient(Cliente cliente)
        {
            if(ModelState.IsValid)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return View("~/Views/Admin/Admin/AdminCliente/ListClient.cshtml");
            }
            return View("~/Views/Admin/Admin/AdminCliente/CreateClient.cshtml");

        }
    }
}
