using Microsoft.AspNetCore.Mvc;
using StayFit.Context;
using StayFit.Models;
using StayFit.Repositories.Interfaces;

namespace StayFit.Repositories
{
    public class ExercicioRepository : IExercicioRepository
    {
        private readonly AppDbContext _context;

        public ExercicioRepository(AppDbContext context)
        {
            _context = context; 
        }

        public IEnumerable<Exercicio> Exercicios => _context.Exercicios;


        public bool Create(Exercicio exercicio)
        {
            try
            {
                _context.Add(exercicio);
                Save();
                return true;
            }catch (Exception ex)
            {
                return false;
            }
        }

        private void Save()
        {
             _context.SaveChanges();
        }
    }
}
