
using System.ComponentModel.DataAnnotations;
 
namespace MiniCinema.Models
{
    public enum HallType { Standard, Premium, IMAX }
 
    public class Hall
    {
        public int Id { get; set; }
 
        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty; // e.g. "IMAX Hall 1"
 
        public HallType Type { get; set; } = HallType.Standard;
 
        [Required]
        public int Capacity { get; set; } = 60;
 
        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;
 
        // Features
        public bool HasDolbyAtmos { get; set; } = false;
        public bool Has4K { get; set; } = false;
        public bool HasReclinerSeats { get; set; } = false;
        public bool IsActive { get; set; } = true;
 
        // Extra charge on top of base ticket price
        public decimal PremiumSurcharge { get; set; } = 0;
 
        public string ImageUrl { get; set; } = string.Empty;
 
        // Navigation
        public ICollection<Showtime> Showtimes { get; set; } = new List<Showtime>();
    }
}
