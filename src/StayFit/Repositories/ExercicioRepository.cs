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

        public Exercicio GetExercicio(int exercicioId)
        {
            return _context.Exercicios.FirstOrDefault(exercicio => exercicio.ExercicioId == exercicioId);
        }

        public IEnumerable<Exercicio> Exercicios => _context.Exercicios;


        public Exercicio Create(Exercicio exercicio)
        {
            
                _context.Exercicios.Add(exercicio);
                Save();
                return exercicio;
          
        }

        private void Save()
        {
             _context.SaveChanges();
        }
    }
}
