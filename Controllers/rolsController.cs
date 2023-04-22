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
    public class rolsController : Controller
    {
        private readonly LP022018UP6012019MA603Context _context;

        public rolsController(LP022018UP6012019MA603Context context)
        {
            _context = context;
        }

        // GET: rols
        public async Task<IActionResult> Index()
        {
              return _context.rol != null ? 
                          View(await _context.rol.ToListAsync()) :
                          Problem("Entity set 'LP022018UP6012019MA603Context.rol'  is null.");
        }

        // GET: rols/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.rol == null)
            {
                return NotFound();
            }

            var rol = await _context.rol
                .FirstOrDefaultAsync(m => m.RolId == id);
            if (rol == null)
            {
                return NotFound();
            }

            return View(rol);
        }

        // GET: rols/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: rols/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RolId,Rol")] rol rol)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rol);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rol);
        }

        // GET: rols/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.rol == null)
            {
                return NotFound();
            }

            var rol = await _context.rol.FindAsync(id);
            if (rol == null)
            {
                return NotFound();
            }
            return View(rol);
        }

        // POST: rols/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RolId,Rol")] rol rol)
        {
            if (id != rol.RolId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rol);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!rolExists(rol.RolId))
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
            return View(rol);
        }

        // GET: rols/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.rol == null)
            {
                return NotFound();
            }

            var rol = await _context.rol
                .FirstOrDefaultAsync(m => m.RolId == id);
            if (rol == null)
            {
                return NotFound();
            }

            return View(rol);
        }

        // POST: rols/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.rol == null)
            {
                return Problem("Entity set 'LP022018UP6012019MA603Context.rol'  is null.");
            }
            var rol = await _context.rol.FindAsync(id);
            if (rol != null)
            {
                _context.rol.Remove(rol);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool rolExists(int id)
        {
          return (_context.rol?.Any(e => e.RolId == id)).GetValueOrDefault();
        }
    }
}
