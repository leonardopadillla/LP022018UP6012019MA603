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
    public class publicacionsController : Controller
    {
        private readonly LP022018UP6012019MA603Context _context;

        public publicacionsController(LP022018UP6012019MA603Context context)
        {
            _context = context;
        }

        // GET: publicacions
        public async Task<IActionResult> Index()
        {
            var lP022018UP6012019MA603Context = _context.publicacion.Include(p => p.Usuario);
            return View(await lP022018UP6012019MA603Context.ToListAsync());
        }

        // GET: publicacions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.publicacion == null)
            {
                return NotFound();
            }

            var publicacion = await _context.publicacion
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(m => m.PublicacionId == id);
            if (publicacion == null)
            {
                return NotFound();
            }

            return View(publicacion);
        }

        // GET: publicacions/Create
        public IActionResult Create()
        {
            ViewData["UsuarioId"] = new SelectList(_context.usuario, "UsuarioId", "UsuarioId");
            return View();
        }

        // POST: publicacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PublicacionId,Titulo,Descripcion,UsuarioId")] publicacion publicacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(publicacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioId"] = new SelectList(_context.usuario, "UsuarioId", "UsuarioId", publicacion.UsuarioId);
            return View(publicacion);
        }

        // GET: publicacions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.publicacion == null)
            {
                return NotFound();
            }

            var publicacion = await _context.publicacion.FindAsync(id);
            if (publicacion == null)
            {
                return NotFound();
            }
            ViewData["UsuarioId"] = new SelectList(_context.usuario, "UsuarioId", "UsuarioId", publicacion.UsuarioId);
            return View(publicacion);
        }

        // POST: publicacions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PublicacionId,Titulo,Descripcion,UsuarioId")] publicacion publicacion)
        {
            if (id != publicacion.PublicacionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(publicacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!publicacionExists(publicacion.PublicacionId))
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
            ViewData["UsuarioId"] = new SelectList(_context.usuario, "UsuarioId", "UsuarioId", publicacion.UsuarioId);
            return View(publicacion);
        }

        // GET: publicacions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.publicacion == null)
            {
                return NotFound();
            }

            var publicacion = await _context.publicacion
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(m => m.PublicacionId == id);
            if (publicacion == null)
            {
                return NotFound();
            }

            return View(publicacion);
        }

        // POST: publicacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.publicacion == null)
            {
                return Problem("Entity set 'LP022018UP6012019MA603Context.publicacion'  is null.");
            }
            var publicacion = await _context.publicacion.FindAsync(id);
            if (publicacion != null)
            {
                _context.publicacion.Remove(publicacion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool publicacionExists(int id)
        {
          return (_context.publicacion?.Any(e => e.PublicacionId == id)).GetValueOrDefault();
        }
    }
}
