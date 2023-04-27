using StayFit.Context;
using StayFit.Models;
using StayFit.Repositories.Interfaces;

namespace StayFit.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _context;

        public Cliente GetCliente(int ClienteId)
        {
            return _context.Cliente.FirstOrDefault(cliente => cliente.ClienteId == ClienteId);
        }
        public ClienteRepository(AppDbContext context)
        {
           _context = context;  
        }

        public IEnumerable<Cliente> Clientes => _context.Clientes;

    }
}
