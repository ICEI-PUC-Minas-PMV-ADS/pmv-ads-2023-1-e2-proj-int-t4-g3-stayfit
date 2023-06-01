﻿using Microsoft.AspNetCore.Mvc;
using StayFit.Models;
using StayFit.Repositories.Interfaces;
using StayFit.ViewModels;

namespace StayFit.Controllers.Instructor
{
    public class FichaController : Controller
    {
        private readonly IFichaRepository _fichaRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly ITreinoRepository _treinoRepository;
        public FichaController(IFichaRepository fichaRepository, IClienteRepository clienteRepository, ITreinoRepository treinoRepository) 
        { 
            _fichaRepository = fichaRepository;
            _clienteRepository = clienteRepository;
            _treinoRepository = treinoRepository;
        }
        public IActionResult Create(int cliente)
        {
            ViewBag.ClienteId = cliente;
            IEnumerable<Ficha> fichas = _fichaRepository.GetFichasClient(cliente);
            FichaViewModel fichaViewModel = new FichaViewModel
            {
                FichaList = fichas,
            };
            return View("~/Views/Admin/Instrutor/Fichas/Create.cshtml", fichaViewModel);
        }

        [HttpPost]
        public IActionResult Create(Ficha ficha)
        {   if (ModelState.IsValid)
            {
                Ficha resposta = _fichaRepository.Create(ficha);
                IEnumerable<Treino> treinos = _treinoRepository.GetTreinosFicha(ficha.FichaId);
           /*     FichaTreinoViewModel fichaTreino = new FichaTreinoViewModel
                {
                    Treino = new Treino(),
                    Treinos = treinos,
                    Ficha = resposta,
                };
           */

                return RedirectToAction("Create", new RouteValueDictionary(
                              new { controller = "Treino", action = "Create", ficha.FichaId }));
               // return View("Views/Admin/Instrutor/Treino/Create.cshtml", fichaTreino);
            }
            return RedirectToAction("Create", new RouteValueDictionary(
                                 new { controller = "Treino", action = "Create" ,ficha.FichaId}));
        }

        [HttpPost]
        public IActionResult CadTreinosIniciante(int clienteId)
        {
            System.Diagnostics.Debug.WriteLine("CadTreinoIniciate ==> " + clienteId);
            int fichaId = 2;
            IEnumerable<Ficha> fichas = _fichaRepository.GetFichasClient(fichaId);

            foreach(Ficha ficha in fichas)
            {
                Ficha f = new Ficha();
                f.DataInicio = ficha.DataInicio;
                f.DataFim = ficha.DataFim;
                f.NomeAtividade = ficha.NomeAtividade;
                f.ClienteId = clienteId;
                f.DiaSemana = ficha.DiaSemana;
                f.Treinos = ficha.Treinos;

            

                 _fichaRepository.Create(f);
                //Ficha f = _fichaRepository.
                //foreach(Treino t in ficha.Treinos)
                //{
                //    Treino treino = new Treino();
                //    treino.FichaId = ;
                //    treino.ExercicioId = t.ExercicioId;
                //    treino.Distance = t.Distance;
                //    treino.RestBetween = t.RestBetween;
                //    treino.Series = t.Series;
                //    treino.Exercicio = t.Exercicio;
                //    treino.RepetitionNumber = t.RepetitionNumber;
                //    treino.RestTime = t.RestTime;
                //    treino.Weight = t.Weight;

                //   // _treinoRepository.Create(treino);
               // }
            }

            

            return RedirectToAction("ListClient", new RouteValueDictionary(
                                  new { controller = "AdminCliente" }));
        }

    }
}
