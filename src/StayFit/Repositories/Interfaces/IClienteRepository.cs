using StayFit.Models;

namespace StayFit.Repositories.Interfaces
{
    public interface IClienteRepository
    {
        public IEnumerable<Cliente> Clientes { get; }

       
    }
}
