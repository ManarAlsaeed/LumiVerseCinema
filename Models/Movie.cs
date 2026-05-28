using System.ComponentModel.DataAnnotations;

namespace MiniCinema.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required, MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required, MaxLength(100)]
        public string Genre { get; set; } = string.Empty;

        [Required]
        public int DurationMinutes { get; set; }

        [Required]
        public string Director { get; set; } = string.Empty;

        [Required]
        public string Cast { get; set; } = string.Empty;

        public string PosterUrl { get; set; } = "/images/default-movie.jpg";

        public double Rating { get; set; } = 0;

        public DateTime ReleaseDate { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ICollection<Showtime> Showtimes { get; set; } = new List<Showtime>();
    }
}