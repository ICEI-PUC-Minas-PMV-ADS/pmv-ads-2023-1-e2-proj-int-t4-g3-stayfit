using Microsoft.EntityFrameworkCore;
using StayFit.Context;
using StayFit.Models;
using StayFit.Repositories.Interfaces;

namespace StayFit.Repositories
{
    public class TreinoRepository : ITreinoRepository
    {
        private readonly AppDbContext _context;

        public TreinoRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Treino> Treinos => _context.Treinos;

        public bool Create(Treino treino)
        {
            try
            {
                _context.Treinos.Add(treino);
                Save();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<Treino> GetTreinosFicha(int fichaId)
        {
            return _context.Treinos
                .Where(treino => treino.FichaId == fichaId)
                .Include(e => e.Exercicio);
        }

        public Treino GetTreino(int treinoId)
        {
            return _context.Treinos.Include(e => e.Exercicio)
                .FirstOrDefault(treino => treino.TreinoId == treinoId);
                        
        }

        private void Save()
        {
            _context.SaveChanges();
        }
    }
}
