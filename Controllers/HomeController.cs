using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniCinema.Data;

namespace MiniCinema.Controllers
{
    public class HomeController : Controller
    {
        private readonly CinemaDbContext _context;

        public HomeController(CinemaDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var movies = await _context.Movies
                .Where(m => m.IsActive)
                .OrderByDescending(m => m.Rating)
                .ToListAsync();

            return View(movies);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}