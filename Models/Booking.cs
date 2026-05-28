using System.ComponentModel.DataAnnotations;

namespace MiniCinema.Models
{
    public enum BookingStatus
    {
        Confirmed,
        Cancelled,
        Pending
    }

    public class Booking
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int ShowtimeId { get; set; }

        [Required]
        public int NumberOfTickets { get; set; }

        public decimal TotalAmount { get; set; }

        public BookingStatus Status { get; set; } = BookingStatus.Confirmed;

        public string BookingReference { get; set; } =
            Guid.NewGuid().ToString("N")[..8].ToUpper();

        public DateTime BookedAt { get; set; } = DateTime.Now;

        public User? User { get; set; }
        public Showtime? Showtime { get; set; }
        public ICollection<Seat> Seats { get; set; } = new List<Seat>();
    }
}