using StayFit.Models;

namespace StayFit.helpers.Interfaces
{
    public interface ISession
    {
        void CriarSessaoUsuario(Usuario usuario);
        void RemoverSessaoUsuario();
        Usuario GetSessaoUsuario();
    }
}
