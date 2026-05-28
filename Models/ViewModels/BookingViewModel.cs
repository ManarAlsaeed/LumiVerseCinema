using System.ComponentModel.DataAnnotations;

namespace MiniCinema.Models.ViewModels
{
    public class BookingViewModel
    {
        public int ShowtimeId { get; set; }

        public Movie? Movie { get; set; }

        public Showtime? Showtime { get; set; }

        [Required, Range(1, 10, ErrorMessage = "You can book 1 to 10 tickets")]
        public int NumberOfTickets { get; set; } = 1;

        public List<string> SelectedSeats { get; set; } = new();

        public List<Seat> AvailableSeats { get; set; } = new();
    }
}