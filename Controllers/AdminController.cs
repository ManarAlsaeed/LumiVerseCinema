using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniCinema.Data;
using MiniCinema.Models;
using MiniCinema.Models.ViewModels;

namespace MiniCinema.Controllers
{
    public class AdminController : Controller
    {
        private readonly CinemaDbContext _context;

        public AdminController(CinemaDbContext context)
        {
            _context = context;
        }

        private bool IsAdmin()
        {
            return HttpContext.Session.GetString("IsAdmin") == "True";
        }

        private IActionResult? RequireAdmin()
        {
            if (!IsAdmin())
            {
                return RedirectToAction("Login", "Account");
            }

            return null;
        }

        public async Task<IActionResult> Dashboard()
        {
            var check = RequireAdmin();
            if (check != null) return check;

            ViewBag.TotalMovies = await _context.Movies.CountAsync();
            ViewBag.TotalBookings = await _context.Bookings.CountAsync();
            ViewBag.TotalUsers = await _context.Users.CountAsync(u => !u.IsAdmin);

            ViewBag.TotalRevenue = await _context.Bookings
                .Where(b => b.Status == BookingStatus.Confirmed)
                .SumAsync(b => b.TotalAmount);

            var recentBookings = await _context.Bookings
                .Include(b => b.User)
                .Include(b => b.Showtime)
                    .ThenInclude(s => s!.Movie)
                .OrderByDescending(b => b.BookedAt)
                .Take(10)
                .ToListAsync();

            return View(recentBookings);
        }

        public async Task<IActionResult> Movies()
        {
            var check = RequireAdmin();
            if (check != null) return check;

            var movies = await _context.Movies
                .Include(m => m.Showtimes)
                .OrderByDescending(m => m.CreatedAt)
                .ToListAsync();

            return View(movies);
        }

        public async Task<IActionResult> AddEditMovie(int? id)
        {
            var check = RequireAdmin();
            if (check != null) return check;

            if (id == null)
            {
                return View(new AdminMovieViewModel
                {
                    ReleaseDate = DateTime.Today
                });
            }

            var movie = await _context.Movies.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            var vm = new AdminMovieViewModel
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                Genre = movie.Genre,
                DurationMinutes = movie.DurationMinutes,
                Director = movie.Director,
                Cast = movie.Cast,
                PosterUrl = movie.PosterUrl,
                Rating = movie.Rating,
                ReleaseDate = movie.ReleaseDate,
                IsActive = movie.IsActive
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEditMovie(AdminMovieViewModel vm)
        {
            var check = RequireAdmin();
            if (check != null) return check;

            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            if (vm.Id == 0)
            {
                var movie = new Movie
                {
                    Title = vm.Title,
                    Description = vm.Description,
                    Genre = vm.Genre,
                    DurationMinutes = vm.DurationMinutes,
                    Director = vm.Director,
                    Cast = vm.Cast,
                    PosterUrl = string.IsNullOrEmpty(vm.PosterUrl)
                        ? "/images/default-movie.jpg"
                        : vm.PosterUrl,
                    Rating = vm.Rating,
                    ReleaseDate = vm.ReleaseDate,
                    IsActive = vm.IsActive,
                    CreatedAt = DateTime.Now
                };

                _context.Movies.Add(movie);
            }
            else
            {
                var movie = await _context.Movies.FindAsync(vm.Id);

                if (movie == null)
                {
                    return NotFound();
                }

                movie.Title = vm.Title;
                movie.Description = vm.Description;
                movie.Genre = vm.Genre;
                movie.DurationMinutes = vm.DurationMinutes;
                movie.Director = vm.Director;
                movie.Cast = vm.Cast;
                movie.PosterUrl = string.IsNullOrEmpty(vm.PosterUrl)
                    ? "/images/default-movie.jpg"
                    : vm.PosterUrl;
                movie.Rating = vm.Rating;
                movie.ReleaseDate = vm.ReleaseDate;
                movie.IsActive = vm.IsActive;
            }

            await _context.SaveChangesAsync();

            TempData["Success"] = vm.Id == 0
                ? "Movie added successfully."
                : "Movie updated successfully.";

            return RedirectToAction("Movies");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var check = RequireAdmin();
            if (check != null) return check;

            var movie = await _context.Movies.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            movie.IsActive = false;

            await _context.SaveChangesAsync();

            TempData["Success"] = "Movie removed successfully.";

            return RedirectToAction("Movies");
        }

        public async Task<IActionResult> AddShowtime(int id)
        {
            var check = RequireAdmin();
            if (check != null) return check;

            var movie = await _context.Movies.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            ViewBag.Movie = movie;

            return View(new Showtime
            {
                MovieId = id,
                ShowDateTime = DateTime.Now.AddDays(1),
                Hall = "Hall A",
                TotalSeats = 60,
                AvailableSeats = 60,
                TicketPrice = 12.50m,
                IsActive = true
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddShowtime(Showtime showtime)
        {
            var check = RequireAdmin();
            if (check != null) return check;

            if (ModelState.IsValid)
            {
                showtime.AvailableSeats = showtime.TotalSeats;

                _context.Showtimes.Add(showtime);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Showtime added successfully.";

                return RedirectToAction("Movies");
            }

            var movie = await _context.Movies.FindAsync(showtime.MovieId);
            ViewBag.Movie = movie;

            return View(showtime);
        }
    }
}