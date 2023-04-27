using StayFit.Models;

namespace StayFit.Repositories.Interfaces
{
    public interface IFichaRepository
    {
        Ficha GetFichaById(int fichaId);
        Ficha Create(Ficha ficha); 

        Ficha UpdateTreinosFicha(List<Treino> treinoList, int fichaId);
    }
}
