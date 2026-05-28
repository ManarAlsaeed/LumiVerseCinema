using System.ComponentModel.DataAnnotations;

namespace MiniCinema.Models
{
    public class Seat
    {
        public int Id { get; set; }

        public int ShowtimeId { get; set; }

        public int? BookingId { get; set; }

        [Required, MaxLength(10)]
        public string SeatNumber { get; set; } = string.Empty;

        public bool IsBooked { get; set; } = false;

        public Showtime? Showtime { get; set; }
        public Booking? Booking { get; set; }
    }
}