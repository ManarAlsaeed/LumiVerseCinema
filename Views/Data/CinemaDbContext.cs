using Microsoft.EntityFrameworkCore;
using MiniCinema.Models;

namespace MiniCinema.Data
{
    public class CinemaDbContext : DbContext
    {
        public CinemaDbContext(DbContextOptions<CinemaDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Showtime> Showtimes { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Seat> Seats { get; set; }

        public static string HashPassword(string password)
        {
            return Convert.ToBase64String(
                System.Security.Cryptography.SHA256.HashData(
                    System.Text.Encoding.UTF8.GetBytes(password + "CINEMA_SALT")
                )
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                FullName = "Admin",
                Email = "admin@minicinema.com",
                PasswordHash = HashPassword("Admin123!"),
                IsAdmin = true,
                CreatedAt = new DateTime(2026, 1, 1)
            });

            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 1,
                    Title = "Inception",
                    Description = "A skilled thief enters dreams to steal secrets and plant ideas.",
                    Genre = "Sci-Fi",
                    DurationMinutes = 148,
                    Director = "Christopher Nolan",
                    Cast = "Leonardo DiCaprio, Joseph Gordon-Levitt",
                    PosterUrl = "https://image.tmdb.org/t/p/w500/oYuLEt3zVCKq57qu2F8dT7NIa6f.jpg",
                    Rating = 8.8,
                    ReleaseDate = new DateTime(2010, 7, 16),
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1)
                },
                new Movie
                {
                    Id = 2,
                    Title = "Interstellar",
                    Description = "A group of explorers travel through space to save humanity.",
                    Genre = "Sci-Fi",
                    DurationMinutes = 169,
                    Director = "Christopher Nolan",
                    Cast = "Matthew McConaughey, Anne Hathaway",
                    PosterUrl = "https://image.tmdb.org/t/p/w500/gEU2QniE6E77NI6lCU6MxlNBvIx.jpg",
                    Rating = 8.7,
                    ReleaseDate = new DateTime(2014, 11, 7),
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1)
                },
                new Movie
                {
                    Id = 3,
                    Title = "The Dark Knight",
                    Description = "Batman faces the Joker, a criminal mastermind spreading chaos.",
                    Genre = "Action",
                    DurationMinutes = 152,
                    Director = "Christopher Nolan",
                    Cast = "Christian Bale, Heath Ledger",
                    PosterUrl = "https://image.tmdb.org/t/p/w500/qJ2tW6WMUDux911r6m7haRef0WH.jpg",
                    Rating = 9.0,
                    ReleaseDate = new DateTime(2008, 7, 18),
                    IsActive = true,
                    CreatedAt = new DateTime(2026, 1, 1)
                }
            );

            modelBuilder.Entity<Showtime>().HasData(
                new Showtime
                {
                    Id = 1,
                    MovieId = 1,
                    ShowDateTime = new DateTime(2026, 6, 1, 14, 0, 0),
                    Hall = "Hall A",
                    TotalSeats = 60,
                    AvailableSeats = 60,
                    TicketPrice = 12.50m,
                    IsActive = true
                },
                new Showtime
                {
                    Id = 2,
                    MovieId = 1,
                    ShowDateTime = new DateTime(2026, 6, 1, 18, 0, 0),
                    Hall = "Hall B",
                    TotalSeats = 60,
                    AvailableSeats = 60,
                    TicketPrice = 15.00m,
                    IsActive = true
                },
                new Showtime
                {
                    Id = 3,
                    MovieId = 2,
                    ShowDateTime = new DateTime(2026, 6, 2, 16, 0, 0),
                    Hall = "Hall C",
                    TotalSeats = 60,
                    AvailableSeats = 60,
                    TicketPrice = 14.00m,
                    IsActive = true
                },
                new Showtime
                {
                    Id = 4,
                    MovieId = 3,
                    ShowDateTime = new DateTime(2026, 6, 2, 20, 0, 0),
                    Hall = "Hall A",
                    TotalSeats = 60,
                    AvailableSeats = 60,
                    TicketPrice = 16.00m,
                    IsActive = true
                }
            );
        }
    }
}