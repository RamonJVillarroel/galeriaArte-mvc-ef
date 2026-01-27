using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using obras_mvc_ef.Data;
using obras_mvc_ef.Models;

namespace obras_mvc_ef.Controllers
{
    public class ObrasController : Controller
    {
        private readonly GaleriaDbContext _context;

        public ObrasController(GaleriaDbContext context)
        {
            _context = context;
        }

        // GET: Obras
        public async Task<IActionResult> Index()
        {
            var galeriaDbContext = _context.Obras.Include(o => o.Artista);
            return View(await galeriaDbContext.ToListAsync());
        }

        // GET: Obras/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obras = await _context.Obras
                .Include(o => o.Artista)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (obras == null)
            {
                return NotFound();
            }

            return View(obras);
        }

        // GET: Obras/Create
        public IActionResult Create()
        {
            ViewData["ArtistaID"] = new SelectList(_context.Artistas, "Id", "Nombre");
            return View();
        }

        // POST: Obras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Estilo,UrlImagen,ArtistaID")] Obras obras)
        {
            if (ModelState.IsValid)
            {
                obras.Id = Guid.NewGuid();
                _context.Add(obras);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArtistaID"] = new SelectList(_context.Artistas, "Id", "Nombre", obras.ArtistaID);
            return View(obras);
        }

        // GET: Obras/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obras = await _context.Obras.FindAsync(id);
            if (obras == null)
            {
                return NotFound();
            }
            ViewData["ArtistaID"] = new SelectList(_context.Artistas, "Id", "Nombre", obras.ArtistaID);
            return View(obras);
        }

        // POST: Obras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Titulo,Estilo,UrlImagen,ArtistaID")] Obras obras)
        {
            if (id != obras.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(obras);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObrasExists(obras.Id))
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
            ViewData["ArtistaID"] = new SelectList(_context.Artistas, "Id", "Nombre", obras.ArtistaID);
            return View(obras);
        }

        // GET: Obras/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obras = await _context.Obras
                .Include(o => o.Artista)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (obras == null)
            {
                return NotFound();
            }

            return View(obras);
        }

        // POST: Obras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var obras = await _context.Obras.FindAsync(id);
            if (obras != null)
            {
                _context.Obras.Remove(obras);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObrasExists(Guid id)
        {
            return _context.Obras.Any(e => e.Id == id);
        }
    }
}
