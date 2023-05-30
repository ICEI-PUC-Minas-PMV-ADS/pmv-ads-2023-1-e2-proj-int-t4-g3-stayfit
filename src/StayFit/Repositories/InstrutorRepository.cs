using StayFit.Context;
using StayFit.Models;
using StayFit.Repositories.Interfaces;

namespace StayFit.Repositories
{
    public class InstrutorRepository: IInsturtorRepository
    {
        private readonly AppDbContext _context;
        public InstrutorRepository(AppDbContext context)
        {
            _context = context;
        }
        public Instrutor GetInstrutorByCPF(string cpf)
        {
            return _context.Instrutores.FirstOrDefault(c => c.CPF == cpf);
        }
        public Instrutor Create(Instrutor instrutor) {
            var user = _context.Users.FirstOrDefault(u => u.CPF == instrutor.CPF);

            _context.Instrutores.Add(instrutor);
            _context.SaveChanges();

            if(user != null)
            {
                Instrutor inst = _context.Instrutores.FirstOrDefault(i => i.CPF == instrutor.CPF);
                user.TipoUsuario = TypeUser.Instrutor;
                user.Instrutor = inst;
                _context.Users.Update(user);
                _context.SaveChanges();
            }


            return instrutor;
        }
    }
}
