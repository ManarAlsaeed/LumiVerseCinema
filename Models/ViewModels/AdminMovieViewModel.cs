using System.ComponentModel.DataAnnotations;

namespace MiniCinema.Models.ViewModels
{
    public class AdminMovieViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Genre is required")]
        public string Genre { get; set; } = string.Empty;

        [Required, Range(30, 300, ErrorMessage = "Duration must be between 30 and 300 minutes")]
        public int DurationMinutes { get; set; }

        [Required]
        public string Director { get; set; } = string.Empty;

        [Required]
        public string Cast { get; set; } = string.Empty;

        public string PosterUrl { get; set; } = string.Empty;

        public string TrailerUrl { get; set; } = string.Empty;

        [Range(0, 10)]
        public double Rating { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; } = DateTime.Today;

        public bool IsActive { get; set; } = true;
    }
}