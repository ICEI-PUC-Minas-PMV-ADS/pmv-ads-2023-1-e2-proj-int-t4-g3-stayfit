using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StayFit.Context;
using StayFit.Models;

namespace StayFit.Controllers
{
    public class TreinosController : Controller
    {
      /*  private readonly AppDbContext _context;

        public TreinosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Treinos
        public async Task<IActionResult> Index()
        {
              return _context.Treinos != null ? 
                          View(await _context.Treinos.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.Treinos'  is null.");
        }

        // GET: Treinos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Treinos == null)
            {
                return NotFound();
            }

            var treino = await _context.Treinos
                .FirstOrDefaultAsync(m => m.TreinoId == id);
            if (treino == null)
            {
                return NotFound();
            }

            return View(treino);
        }

        // GET: Treinos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Treinos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TreinoId,NomeTreino,DiaSemana,DataInicio,DataFim")] Treino treino)
        {
            if (ModelState.IsValid)
            {
                _context.Add(treino);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(treino);
        }

        // GET: Treinos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Treinos == null)
            {
                return NotFound();
            }

            var treino = await _context.Treinos.FindAsync(id);
            if (treino == null)
            {
                return NotFound();
            }
            return View(treino);
        }

        // POST: Treinos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TreinoId,NomeTreino,DiaSemana,DataInicio,DataFim")] Treino treino)
        {
            if (id != treino.TreinoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(treino);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TreinoExists(treino.TreinoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(treino);
        }

        // GET: Treinos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Treinos == null)
            {
                return NotFound();
            }

            var treino = await _context.Treinos
                .FirstOrDefaultAsync(m => m.TreinoId == id);
            if (treino == null)
            {
                return NotFound();
            }

            return View(treino);
        }

        // POST: Treinos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Treinos == null)
            {
                return Problem("Entity set 'AppDbContext.Treinos'  is null.");
            }
            var treino = await _context.Treinos.FindAsync(id);
            if (treino != null)
            {
                _context.Treinos.Remove(treino);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TreinoExists(int id)
        {
          return (_context.Treinos?.Any(e => e.TreinoId == id)).GetValueOrDefault();
        }
      */
    }
}
