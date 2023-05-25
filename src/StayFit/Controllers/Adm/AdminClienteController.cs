using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StayFit.Context;
using StayFit.Models;
using StayFit.Repositories.Interfaces;

namespace StayFit.Controllers.Adm
{
    public class AdminClienteController : Controller
    {
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
        public IClienteRepository _clienteRepository;
		public AppDbContext _context;
        public AdminClienteController(AppDbContext context, UserManager<ApplicationUser> userManager , IClienteRepository clienteRepository)
        {            
            _clienteRepository = clienteRepository;
            _userManager = userManager;
            _context = context;
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
                var user = _userManager.Users.FirstOrDefault(u => u.CPF == cliente.CPF);
                if (user != null)
                {
                    user.Matricula = cliente.Matricula;
                    user.Cliente = cliente;
                    await _userManager.UpdateAsync(user);
                }
                //_clienteRepository.CreateClient(cliente);
                IEnumerable<Cliente> clientes = _clienteRepository.Clientes;
               
                return View("~/Views/Admin/Admin/AdminCliente/ListClient.cshtml", clientes);
            }
            return View("~/Views/Admin/Admin/AdminCliente/CreateClient.cshtml");

        }

    }
}
