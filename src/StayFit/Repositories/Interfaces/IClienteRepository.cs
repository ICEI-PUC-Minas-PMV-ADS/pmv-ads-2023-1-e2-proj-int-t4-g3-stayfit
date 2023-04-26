using StayFit.Models;

namespace StayFit.Repositories.Interfaces
{
    public interface IClienteRepository
    {
        public Cliente GetCliente(int ClienteId);
        public IEnumerable<Cliente> Clientes { get; }

       
    }
}
