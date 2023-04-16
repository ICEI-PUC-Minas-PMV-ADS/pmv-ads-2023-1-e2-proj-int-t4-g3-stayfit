using Microsoft.AspNetCore.Mvc;
using StayFit.Models;

namespace StayFit.Repositories.Interfaces
{
    public interface IExercicioRepository
    {
        public bool Create(Exercicio exercicio);
    }
}
