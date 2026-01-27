using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using obras_mvc_ef.Models;
using Microsoft.EntityFrameworkCore;
using obras_mvc_ef.Data;
namespace obras_mvc_ef.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GaleriaDbContext _context;

        public HomeController(ILogger<HomeController> logger, GaleriaDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var obras = await _context.Obras
                .Take(6)
                .ToListAsync();
            return View(obras);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
