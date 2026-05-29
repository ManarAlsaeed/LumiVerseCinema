using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniCinema.Data;
 
namespace MiniCinema.Controllers
{
    public class HallsController : Controller
    {
        private readonly CinemaDbContext _context;
        public HallsController(CinemaDbContext context) => _context = context;
 
        // GET: /Halls
        public async Task<IActionResult> Index()
        {
            var halls = await _context.Halls
                .Where(h => h.IsActive)
                .Include(h => h.Showtimes.Where(s => s.IsActive && s.ShowDateTime > DateTime.Now))
                .ToListAsync();
 
            return View(halls);
        }
    }
}