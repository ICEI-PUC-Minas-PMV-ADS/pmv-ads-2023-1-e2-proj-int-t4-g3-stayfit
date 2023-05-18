using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StayFit.Models;
using StayFit.Repositories;
using StayFit.Repositories.Interfaces;
using System.IO;

namespace StayFit.Controllers.Instructor
{
    public class ExercicioController : Controller
    {
        private readonly IExercicioRepository _exercicioRepository;

        public ExercicioController(IExercicioRepository exercicioRepository)
        {
            _exercicioRepository = exercicioRepository;
        }
        public IActionResult Index()
        {
            IEnumerable<Exercicio> exercicios = _exercicioRepository.Exercicios;
            return View("~/Views/Admin/Instrutor/Exercicios/Index.cshtml", exercicios);
        }


        public IActionResult Create()
        {
            return View("~/Views/Admin/Instrutor/Exercicios/Create.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> Create(Exercicio exercicio, IFormFile Photo, IFormFile Video)
        {
            if (Photo != null && Photo.Length > 0)
            {
               // var fileName = exercicio.Name.ToLower() + Path.GetFileName(Photo.FileName).ToLower()  ;
                var fileName = Path.GetFileName(Photo.FileName).ToLower()  ;
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagens/exercicios/", fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await Photo.CopyToAsync(fileStream);
                }

                exercicio.Photo = $"/imagens/exercicios/{fileName}";
            }

            if (Video != null && Video.Length > 0)
            {
              //var fileName = exercicio.Name.ToLower()+Path.GetFileName(Video.FileName).ToLower();
              var fileName = Path.GetFileName(Video.FileName).ToLower();
              var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/videos/exercicios/", fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await Video.CopyToAsync(fileStream);
        }

            exercicio.Video = $"/videos/exercicios/{fileName}";
    }


            IEnumerable<Exercicio> exercicios;
            try
            {
                if (ModelState.IsValid)
                {
                    _exercicioRepository.Create(exercicio);
                    exercicios = _exercicioRepository.Exercicios;
                    TempData["msgSuccess"] = "Exercício cadastrado com sucesso!";
                    return View("~/Views/Admin/Instrutor/Exercicios/Index.cshtml", exercicios);

                }

            }
            catch(System.Exception ex)
            {
                TempData["msgError"] = $"Não foi possivel cadastrar o exercício! {ex.Message}";
                exercicios = _exercicioRepository.Exercicios;
                return View("~/Views/Admin/Instrutor/Exercicios/Index.cshtml",exercicios);
            }

            return View("~/Views/Admin/Instrutor/Exercicios/Create.cshtml", exercicio);
          }

        public ViewResult Detail(int ExercicioId)
        {
            Exercicio exercicio = _exercicioRepository.GetExercicio(ExercicioId);
            return View("~/Views/Admin/Instrutor/Exercicios/Detail.cshtml", exercicio);
        }
    }
}
