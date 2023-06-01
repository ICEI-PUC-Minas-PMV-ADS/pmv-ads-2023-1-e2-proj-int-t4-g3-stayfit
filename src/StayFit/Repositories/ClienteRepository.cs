﻿using StayFit.Context;
using StayFit.Models;
using StayFit.Repositories.Interfaces;

namespace StayFit.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _context;

        public Cliente GetCliente(int ClienteId)
        {
            return _context.Clientes.FirstOrDefault(cliente => cliente.ClienteId == ClienteId);
        }
        public ClienteRepository(AppDbContext context)
        {
           _context = context;  
        }

        public Cliente GetClienteByMatricula(int matricula)
        {
            return _context.Clientes.FirstOrDefault(cli => cli.Matricula == matricula);
        }

        public Cliente GetClienteByCPF(string cpf)
        {
            return _context.Clientes.FirstOrDefault(c => c.CPF == cpf);
        }

        public Cliente CreateClient(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();


            return cliente;
        }

        public IEnumerable<Cliente> Clientes => _context.Clientes.Where(c => c.Matricula != 120002);

    }
}
