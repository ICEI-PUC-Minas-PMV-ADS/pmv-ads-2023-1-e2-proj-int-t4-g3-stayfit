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
    public class FichasController : Controller
    {
    /*    private readonly AppDbContext _context;

        public FichasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Fichas
        public async Task<IActionResult> Index()
        {
              return _context.Fichas != null ? 
                          View(await _context.Fichas.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.Fichas'  is null.");
        }

        // GET: Fichas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Fichas == null)
            {
                return NotFound();
            }

            var ficha = await _context.Fichas
                .FirstOrDefaultAsync(m => m.FichaId == id);
            if (ficha == null)
            {
                return NotFound();
            }

            return View(ficha);
        }

        // GET: Fichas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fichas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FichaId,DataInicio,DataFim")] Ficha ficha)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ficha);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ficha);
        }

        // GET: Fichas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Fichas == null)
            {
                return NotFound();
            }

            var ficha = await _context.Fichas.FindAsync(id);
            if (ficha == null)
            {
                return NotFound();
            }
            return View(ficha);
        }

        // POST: Fichas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FichaId,DataInicio,DataFim")] Ficha ficha)
        {
            if (id != ficha.FichaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ficha);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FichaExists(ficha.FichaId))
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
            return View(ficha);
        }

        // GET: Fichas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Fichas == null)
            {
                return NotFound();
            }

            var ficha = await _context.Fichas
                .FirstOrDefaultAsync(m => m.FichaId == id);
            if (ficha == null)
            {
                return NotFound();
            }

            return View(ficha);
        }

        // POST: Fichas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Fichas == null)
            {
                return Problem("Entity set 'AppDbContext.Fichas'  is null.");
            }
            var ficha = await _context.Fichas.FindAsync(id);
            if (ficha != null)
            {
                _context.Fichas.Remove(ficha);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FichaExists(int id)
        {
          return (_context.Fichas?.Any(e => e.FichaId == id)).GetValueOrDefault();
        }
    */
    }
}
