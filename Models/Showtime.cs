using System.ComponentModel.DataAnnotations;
 
namespace MiniCinema.Models
{
    public class Showtime
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
 
        [Required]
        public DateTime ShowDateTime { get; set; }
 
        [Required, MaxLength(100)]
        public string Hall { get; set; } = string.Empty;
 
        // ← الإضافة الجديدة
        public int? HallId { get; set; }
 
        [Required]
        public int TotalSeats { get; set; } = 60;
        public int AvailableSeats { get; set; } = 60;
 
        [Required]
        public decimal TicketPrice { get; set; }
        public bool IsActive { get; set; } = true;
 
        // Navigation
        public Movie? Movie { get; set; }
        public Hall? HallDetails { get; set; }  // ← الإضافة الجديدة
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
        public ICollection<Seat> Seats { get; set; } = new List<Seat>();
    }
}