using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniCinema.Data;
using MiniCinema.Models;
using MiniCinema.Models.ViewModels;

namespace MiniCinema.Controllers
{
    public class BookingController : Controller
    {
        private readonly CinemaDbContext _context;

        public BookingController(CinemaDbContext context)
        {
            _context = context;
        }

        private int? GetUserId()
        {
            return HttpContext.Session.GetInt32("UserId");
        }

        public async Task<IActionResult> Index(int id)
        {
            if (GetUserId() == null)
            {
                return RedirectToAction("Login", "Account", new { returnUrl = $"/Booking/Index/{id}" });
            }

            var showtime = await _context.Showtimes
                .Include(s => s.Movie)
                .Include(s => s.Seats)
                .FirstOrDefaultAsync(s => s.Id == id && s.IsActive);

            if (showtime == null)
            {
                return NotFound();
            }

            if (!showtime.Seats.Any())
            {
                var seats = new List<Seat>();
                string[] rows = { "A", "B", "C", "D", "E", "F" };

                foreach (var row in rows)
                {
                    for (int col = 1; col <= 10; col++)
                    {
                        seats.Add(new Seat
                        {
                            ShowtimeId = id,
                            SeatNumber = $"{row}{col}",
                            IsBooked = false
                        });
                    }
                }

                _context.Seats.AddRange(seats);
                await _context.SaveChangesAsync();

                showtime.Seats = seats;
            }

            var vm = new BookingViewModel
            {
                ShowtimeId = id,
                Movie = showtime.Movie,
                Showtime = showtime,
                AvailableSeats = showtime.Seats.ToList()
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Confirm(int showtimeId, List<string> selectedSeats)
        {
            var userId = GetUserId();

            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            if (selectedSeats == null || !selectedSeats.Any())
            {
                TempData["Error"] = "Please select at least one seat.";
                return RedirectToAction("Index", new { id = showtimeId });
            }

            var showtime = await _context.Showtimes
                .Include(s => s.Seats)
                .FirstOrDefaultAsync(s => s.Id == showtimeId);

            if (showtime == null)
            {
                return NotFound();
            }

            var seatsToBook = showtime.Seats
                .Where(s => selectedSeats.Contains(s.SeatNumber) && !s.IsBooked)
                .ToList();

            if (seatsToBook.Count != selectedSeats.Count)
            {
                TempData["Error"] = "Some selected seats are no longer available.";
                return RedirectToAction("Index", new { id = showtimeId });
            }

            var booking = new Booking
            {
                UserId = userId.Value,
                ShowtimeId = showtimeId,
                NumberOfTickets = seatsToBook.Count,
                TotalAmount = seatsToBook.Count * showtime.TicketPrice,
                Status = BookingStatus.Confirmed,
                BookingReference = Guid.NewGuid().ToString("N")[..8].ToUpper(),
                BookedAt = DateTime.Now
            };

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            foreach (var seat in seatsToBook)
            {
                seat.IsBooked = true;
                seat.BookingId = booking.Id;
            }

            showtime.AvailableSeats -= seatsToBook.Count;

            await _context.SaveChangesAsync();

            TempData["Success"] = $"Booking confirmed! Reference: {booking.BookingReference}";

            return RedirectToAction("MyBookings");
        }

        public async Task<IActionResult> MyBookings()
        {
            var userId = GetUserId();

            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var bookings = await _context.Bookings
                .Include(b => b.Showtime)
                    .ThenInclude(s => s!.Movie)
                .Include(b => b.Seats)
                .Where(b => b.UserId == userId.Value)
                .OrderByDescending(b => b.BookedAt)
                .ToListAsync();

            return View(bookings);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cancel(int id)
        {
            var userId = GetUserId();

            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var booking = await _context.Bookings
                .Include(b => b.Seats)
                .Include(b => b.Showtime)
                .FirstOrDefaultAsync(b => b.Id == id && b.UserId == userId.Value);

            if (booking == null)
            {
                return NotFound();
            }

            booking.Status = BookingStatus.Cancelled;

            foreach (var seat in booking.Seats)
            {
                seat.IsBooked = false;
                seat.BookingId = null;
            }

            if (booking.Showtime != null)
            {
                booking.Showtime.AvailableSeats += booking.NumberOfTickets;
            }

            await _context.SaveChangesAsync();

            TempData["Success"] = "Booking cancelled successfully.";

            return RedirectToAction("MyBookings");
        }
    }
}