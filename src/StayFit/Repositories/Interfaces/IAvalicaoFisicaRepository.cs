using StayFit.Context;
using StayFit.Models;

namespace StayFit.Repositories.Interfaces
{
    public interface IAvalicaoFisicaRepository
    {
        public Avaliacao GetAvaliacao(int avaliacaoId);
        public Avaliacao Create(Avaliacao avaliacao);
        public Avaliacao UpdateAnamnese(Avaliacao avaliacao);
    }
}
