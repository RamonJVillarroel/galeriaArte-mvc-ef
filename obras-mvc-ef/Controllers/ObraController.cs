using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using obras_mvc_ef.Data;

namespace obras_mvc_ef.Controllers
{
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
        public async Task<IActionResult> DetalleObra(string id)
        {
            var obra = await _context.Obras.FirstOrDefaultAsync(O => O.Id.ToString() == id);

            return View(obra);
        } 

    }
}
