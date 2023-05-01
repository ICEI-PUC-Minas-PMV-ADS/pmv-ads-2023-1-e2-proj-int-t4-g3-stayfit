using Microsoft.AspNetCore.Mvc;
using StayFit.Models;

namespace StayFit.Repositories.Interfaces
{
    public interface IExercicioRepository
    {
        public Exercicio GetExercicio(int exercicioId);
        public IEnumerable<Exercicio> Exercicios { get; }
        public Exercicio Create(Exercicio exercicio);
    }
}
