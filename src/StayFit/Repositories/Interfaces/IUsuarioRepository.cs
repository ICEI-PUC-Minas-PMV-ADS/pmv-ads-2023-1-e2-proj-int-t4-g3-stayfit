using StayFit.Models;

namespace StayFit.Repositories.Interfaces
{
	public interface IUsuarioRepository
	{
		public Usuario GetUsuario(int usuarioId);
		public Usuario UpdateUsuarioCliente(Usuario usuario);
		public Usuario EditUsuario(Usuario usuario);
	}
}
