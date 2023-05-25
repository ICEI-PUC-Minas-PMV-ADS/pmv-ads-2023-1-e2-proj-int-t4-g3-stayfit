using Microsoft.AspNetCore.Mvc;
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

        public Usuario GetUserByEmail(string email)
		{
			Usuario usuario = new Usuario();
			var user = _context.Users.FirstOrDefault(u => u.Email == email);
			if(user != null)
			{ 
				usuario.Nome = user.Nome;
				usuario.Email = email;
				usuario.Foto = user.Foto;
				usuario.CPF = user.CPF;
				usuario.TipoUsuario = user.TipoUsuario;
				usuario.Matricula = user.Matricula;
				usuario.Cliente = _context.Clientes.FirstOrDefault(c => c.CPF == user.CPF);
			}

			return usuario;
		}

		
		public Usuario EditUsuario(Usuario usuario, string userInditityEmail)
		{
			var user = _context.Users.FirstOrDefault(user => user.Email == userInditityEmail);
			if (user != null)
			{
				user.Email = usuario.Email;
				user.Nome = usuario.Nome;
				user.CPF = usuario.CPF;
				user.Foto = usuario.Foto;

				if (user.Matricula != null)
				{

				}
				_context.Users.Update(user);
				_context.SaveChanges();
			
				return usuario;
			}
			return usuario;
		}
	}
}
