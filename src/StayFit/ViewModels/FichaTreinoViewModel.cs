using StayFit.Models;

namespace StayFit.ViewModels
{
    public class FichaTreinoViewModel
    {
        public Treino Treino { get; set; }
        public IEnumerable<Treino> Treinos { get; set; }
        public Ficha Ficha { get; set; }
    }
}
