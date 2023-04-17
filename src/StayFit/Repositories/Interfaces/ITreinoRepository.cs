using StayFit.Models;

namespace StayFit.Repositories.Interfaces
{
    public interface ITreinoRepository
    {
        public IEnumerable<Treino> Treinos { get; }
        public bool Create(Treino treino);
    }
}
