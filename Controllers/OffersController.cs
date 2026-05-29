using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniCinema.Data;
 
namespace MiniCinema.Controllers
{
    public class OffersController : Controller
    {
        private readonly CinemaDbContext _context;
        public OffersController(CinemaDbContext context) => _context = context;
 
        // GET: /Offers
        public async Task<IActionResult> Index()
        {
            var offers = await _context.Offers
                .Where(o => o.IsActive && o.EndDate >= DateTime.Today)
                .OrderBy(o => o.EndDate)
                .ToListAsync();
 
            return View(offers);
        }
    }
}