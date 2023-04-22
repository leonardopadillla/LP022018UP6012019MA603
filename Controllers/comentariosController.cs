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
    public class comentariosController : Controller
    {
        private readonly LP022018UP6012019MA603Context _context;

        public comentariosController(LP022018UP6012019MA603Context context)
        {
            _context = context;
        }

        // GET: comentarios
        public async Task<IActionResult> Index()
        {
            var lP022018UP6012019MA603Context = _context.comentario.Include(c => c.Publicacion).Include(c => c.Usuario);
            return View(await lP022018UP6012019MA603Context.ToListAsync());
        }

        // GET: comentarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.comentario == null)
            {
                return NotFound();
            }

            var comentario = await _context.comentario
                .Include(c => c.Publicacion)
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.ComentarioId == id);
            if (comentario == null)
            {
                return NotFound();
            }

            return View(comentario);
        }

        // GET: comentarios/Create
        public IActionResult Create()
        {
            ViewData["PublicacionId"] = new SelectList(_context.Set<publicacion>(), "PublicacionId", "PublicacionId");
            ViewData["UsuarioId"] = new SelectList(_context.usuario, "UsuarioId", "UsuarioId");
            return View();
        }

        // POST: comentarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ComentarioId,PublicacionId,UsuarioId,Comentario")] comentario comentario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comentario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PublicacionId"] = new SelectList(_context.Set<publicacion>(), "PublicacionId", "PublicacionId", comentario.PublicacionId);
            ViewData["UsuarioId"] = new SelectList(_context.usuario, "UsuarioId", "UsuarioId", comentario.UsuarioId);
            return View(comentario);
        }

        // GET: comentarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.comentario == null)
            {
                return NotFound();
            }

            var comentario = await _context.comentario.FindAsync(id);
            if (comentario == null)
            {
                return NotFound();
            }
            ViewData["PublicacionId"] = new SelectList(_context.Set<publicacion>(), "PublicacionId", "PublicacionId", comentario.PublicacionId);
            ViewData["UsuarioId"] = new SelectList(_context.usuario, "UsuarioId", "UsuarioId", comentario.UsuarioId);
            return View(comentario);
        }

        // POST: comentarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ComentarioId,PublicacionId,UsuarioId,Comentario")] comentario comentario)
        {
            if (id != comentario.ComentarioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comentario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!comentarioExists(comentario.ComentarioId))
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
            ViewData["PublicacionId"] = new SelectList(_context.Set<publicacion>(), "PublicacionId", "PublicacionId", comentario.PublicacionId);
            ViewData["UsuarioId"] = new SelectList(_context.usuario, "UsuarioId", "UsuarioId", comentario.UsuarioId);
            return View(comentario);
        }

        // GET: comentarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.comentario == null)
            {
                return NotFound();
            }

            var comentario = await _context.comentario
                .Include(c => c.Publicacion)
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.ComentarioId == id);
            if (comentario == null)
            {
                return NotFound();
            }

            return View(comentario);
        }

        // POST: comentarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.comentario == null)
            {
                return Problem("Entity set 'LP022018UP6012019MA603Context.comentario'  is null.");
            }
            var comentario = await _context.comentario.FindAsync(id);
            if (comentario != null)
            {
                _context.comentario.Remove(comentario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool comentarioExists(int id)
        {
          return (_context.comentario?.Any(e => e.ComentarioId == id)).GetValueOrDefault();
        }
    }
}
