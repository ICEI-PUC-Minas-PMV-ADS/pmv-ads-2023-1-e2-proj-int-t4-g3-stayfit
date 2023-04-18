﻿using Microsoft.AspNetCore.Mvc;
using StayFit.Models;
using StayFit.Repositories;
using StayFit.Repositories.Interfaces;

namespace StayFit.Controllers.Instructor
{
    public class ExerciciosController : Controller
    {
        private readonly IExercicioRepository _exercicioRepository;

        public ExerciciosController(IExercicioRepository exercicioRepository)
        {
            _exercicioRepository = exercicioRepository;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Exercicio exercicio)
        {
            if(ModelState.IsValid)
            {
                if(_exercicioRepository.Create(exercicio))
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return RedirectToAction("Teste");
                }
            }

            return View();
        }
    }
}
