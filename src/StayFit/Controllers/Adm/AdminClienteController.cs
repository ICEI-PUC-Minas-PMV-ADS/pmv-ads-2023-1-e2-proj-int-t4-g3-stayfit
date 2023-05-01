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
        public ViewResult CreateClient(Cliente cliente)
        {
            if(ModelState.IsValid)
            {
                _clienteRepository.CreateClient(cliente);
                IEnumerable<Cliente> clientes = _clienteRepository.Clientes;
               
                return View("~/Views/Admin/Admin/AdminCliente/ListClient.cshtml", clientes);
            }
            return View("~/Views/Admin/Admin/AdminCliente/CreateClient.cshtml");

        }

    }
}
