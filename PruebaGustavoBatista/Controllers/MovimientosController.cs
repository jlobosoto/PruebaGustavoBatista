using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PruebaGustavoBatista.Data;
using PruebaGustavoBatista.Models;

namespace PruebaGustavoBatista.Controllers
{
    public class MovimientosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MovimientosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Movimientos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Movimientos.Include(m => m.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Movimientos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Movimientos == null)
            {
                return NotFound();
            }

            var movimientos = await _context.Movimientos
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movimientos == null)
            {
                return NotFound();
            }

            return View(movimientos);
        }

        // GET: Movimientos/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Movimientos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Id_Tipo_Movimiento,Fecha,Valor,UserId")] Movimientos movimientos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movimientos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", movimientos.UserId);
            return View(movimientos);
        }

        // GET: Movimientos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Movimientos == null)
            {
                return NotFound();
            }

            var movimientos = await _context.Movimientos.FindAsync(id);
            if (movimientos == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", movimientos.UserId);
            return View(movimientos);
        }

        // POST: Movimientos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Id_Tipo_Movimiento,Fecha,Valor,UserId")] Movimientos movimientos)
        {
            if (id != movimientos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movimientos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovimientosExists(movimientos.Id))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", movimientos.UserId);
            return View(movimientos);
        }

        // GET: Movimientos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Movimientos == null)
            {
                return NotFound();
            }

            var movimientos = await _context.Movimientos
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movimientos == null)
            {
                return NotFound();
            }

            return View(movimientos);
        }

        // POST: Movimientos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Movimientos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Movimientos'  is null.");
            }
            var movimientos = await _context.Movimientos.FindAsync(id);
            if (movimientos != null)
            {
                _context.Movimientos.Remove(movimientos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovimientosExists(int id)
        {
          return (_context.Movimientos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
