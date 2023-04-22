using Microsoft.AspNetCore.Mvc;
using StayFit.Models;

namespace StayFit.Repositories.Interfaces
{
    public interface IExercicioRepository
    {
        public IEnumerable<Exercicio> Exercicios { get; }
        public bool Create(Exercicio exercicio);
    }
}
