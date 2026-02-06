using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using obras_mvc_ef.Data;
using obras_mvc_ef.Models;

namespace obras_mvc_ef.Controllers
{
    [Authorize]
    public class ObraController : Controller
    {
        private readonly GaleriaDbContext _context;
        public ObraController(GaleriaDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> DetalleObra(string id, int idExpo)
        {
            ViewBag.idExpo = idExpo;
            var obra = await _context.Obras
                .Include(o => o.Artista)
                .FirstOrDefaultAsync(o => o.Id.ToString() == id);
            return View(obra);
        }

    }
}
