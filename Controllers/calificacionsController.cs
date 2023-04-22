using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LP022018UP6012019MA603.Data;
using LP022018UP6012019MA603.Models;

namespace LP022018UP6012019MA603.Controllers
{
    public class calificacionsController : Controller
    {
        private readonly LP022018UP6012019MA603Context _context;

        public calificacionsController(LP022018UP6012019MA603Context context)
        {
            _context = context;
        }

        // GET: calificacions
        public async Task<IActionResult> Index()
        {
            var lP022018UP6012019MA603Context = _context.calificacion.Include(c => c.Publicacion).Include(c => c.Usuario);
            return View(await lP022018UP6012019MA603Context.ToListAsync());
        }

        // GET: calificacions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.calificacion == null)
            {
                return NotFound();
            }

            var calificacion = await _context.calificacion
                .Include(c => c.Publicacion)
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.CalificacionId == id);
            if (calificacion == null)
            {
                return NotFound();
            }

            return View(calificacion);
        }

        // GET: calificacions/Create
        public IActionResult Create()
        {
            ViewData["PublicacionId"] = new SelectList(_context.Set<publicacion>(), "PublicacionId", "PublicacionId");
            ViewData["UsuarioId"] = new SelectList(_context.Set<usuario>(), "UsuarioId", "UsuarioId");
            return View();
        }

        // POST: calificacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CalificacionId,PublicacionId,UsuarioId,Calificacion")] calificacion calificacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(calificacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PublicacionId"] = new SelectList(_context.Set<publicacion>(), "PublicacionId", "PublicacionId", calificacion.PublicacionId);
            ViewData["UsuarioId"] = new SelectList(_context.Set<usuario>(), "UsuarioId", "UsuarioId", calificacion.UsuarioId);
            return View(calificacion);
        }

        // GET: calificacions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.calificacion == null)
            {
                return NotFound();
            }

            var calificacion = await _context.calificacion.FindAsync(id);
            if (calificacion == null)
            {
                return NotFound();
            }
            ViewData["PublicacionId"] = new SelectList(_context.Set<publicacion>(), "PublicacionId", "PublicacionId", calificacion.PublicacionId);
            ViewData["UsuarioId"] = new SelectList(_context.Set<usuario>(), "UsuarioId", "UsuarioId", calificacion.UsuarioId);
            return View(calificacion);
        }

        // POST: calificacions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CalificacionId,PublicacionId,UsuarioId,Calificacion")] calificacion calificacion)
        {
            if (id != calificacion.CalificacionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(calificacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!calificacionExists(calificacion.CalificacionId))
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
            ViewData["PublicacionId"] = new SelectList(_context.Set<publicacion>(), "PublicacionId", "PublicacionId", calificacion.PublicacionId);
            ViewData["UsuarioId"] = new SelectList(_context.Set<usuario>(), "UsuarioId", "UsuarioId", calificacion.UsuarioId);
            return View(calificacion);
        }

        // GET: calificacions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.calificacion == null)
            {
                return NotFound();
            }

            var calificacion = await _context.calificacion
                .Include(c => c.Publicacion)
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.CalificacionId == id);
            if (calificacion == null)
            {
                return NotFound();
            }

            return View(calificacion);
        }

        // POST: calificacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.calificacion == null)
            {
                return Problem("Entity set 'LP022018UP6012019MA603Context.calificacion'  is null.");
            }
            var calificacion = await _context.calificacion.FindAsync(id);
            if (calificacion != null)
            {
                _context.calificacion.Remove(calificacion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool calificacionExists(int id)
        {
          return (_context.calificacion?.Any(e => e.CalificacionId == id)).GetValueOrDefault();
        }
    }
}
