using Microsoft.EntityFrameworkCore;
using StayFit.Context;
using StayFit.Models;
using StayFit.Repositories.Interfaces;

namespace StayFit.Repositories
{

    public class FichaRepository:IFichaRepository
    {
       private readonly AppDbContext _context;
       public FichaRepository(AppDbContext context)
        {
            _context = context;
        } 

        public async Task<bool> save()
        {
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }catch (Exception ex)
            {
                return false;
            }
        }
       public Ficha Create(Ficha ficha)
        {
            _context.Ficha.Add(ficha);
            _context.SaveChanges();

            return ficha;
        }

        public Ficha GetFichaById(int fichaId)
        {
            return _context.Ficha.FirstOrDefault(ficha => ficha.FichaId == fichaId);
        }

        public Ficha UpdateTreinosFicha(List<Treino> treinoList, int fichaId)
        {
            Ficha ficha = GetFichaById(fichaId);
            ficha.Treinos = treinoList;
            _context.Ficha.Update(ficha);
            _context.SaveChanges();
            return ficha;
        }

        public IEnumerable<Ficha> GetFichasClient(int clientId) {
            return _context.Ficha.Where(ficha => ficha.ClienteId == clientId).Include(treino => treino.Treinos);
           
           
        }
    }
}
