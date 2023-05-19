using Microsoft.EntityFrameworkCore;
using StayFit.Context;
using StayFit.Models;
using StayFit.Repositories.Interfaces;

namespace StayFit.Repositories
{
	public class UsuarioRepository:IUsuarioRepository
	{
		private readonly AppDbContext _context;

		public UsuarioRepository(AppDbContext context)
		{
			_context = context;
		}
		public Usuario GetUsuario(int usuarioId)
		{
			return _context.Usuarios
				.Include(c => c.Cliente)
				.FirstOrDefault(user => user.UsuarioId == usuarioId);
		}

		public Usuario UpdateUsuarioCliente(Usuario usuario)
		{
			Usuario user = GetUsuario(usuario.UsuarioId);
			if (user != null)
			{
				user.Matricula = usuario.Matricula;
				user.Cliente = usuario.Cliente;
				try
				{
					_context.Usuarios.Update(user);
					_context.SaveChanges();

				}
				catch (Exception ex)
				{
					System.Diagnostics.Debug.WriteLine("=====================" + ex);
				}


				return user;
			}
			else
			{
				System.Diagnostics.Debug.WriteLine("===================== USUARIO NAO ENCONTRADO");
			}
			return user;
		}
	}
}
