using Microsoft.EntityFrameworkCore;
using MiniCinema.Models;
 
namespace MiniCinema.Data
{
    public class CinemaDbContext : DbContext
    {
        public CinemaDbContext(DbContextOptions<CinemaDbContext> options) : base(options) { }
 
        // الجداول الأصلية
        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Showtime> Showtimes { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Seat> Seats { get; set; }
 
        // ← الجداول الجديدة
        public DbSet<Hall> Halls { get; set; }
        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<FoodOrder> FoodOrders { get; set; }
        public DbSet<FoodOrderItem> FoodOrderItems { get; set; }
        public DbSet<Offer> Offers { get; set; }
 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
 
            // =================== SEED: HALLS ===================
            modelBuilder.Entity<Hall>().HasData(
                new Hall
                {
                    Id = 1, Name = "Standard Hall A", Type = HallType.Standard,
                    Capacity = 80, Description = "Classic cinema experience with comfortable seats.",
                    HasDolbyAtmos = false, Has4K = false, HasReclinerSeats = false,
                    PremiumSurcharge = 0, IsActive = true,
                    ImageUrl = "https://images.unsplash.com/photo-1489599849927-2ee91cede3ba?w=600"
                },
                new Hall
                {
                    Id = 2, Name = "Premium Hall B", Type = HallType.Premium,
                    Capacity = 40, Description = "Luxury recliner seats with Dolby Atmos surround sound and 4K projection.",
                    HasDolbyAtmos = true, Has4K = true, HasReclinerSeats = true,
                    PremiumSurcharge = 8.00m, IsActive = true,
                    ImageUrl = "https://images.unsplash.com/photo-1517604931442-7e0c8ed2963c?w=600"
                },
                new Hall
                {
                    Id = 3, Name = "IMAX Hall C", Type = HallType.IMAX,
                    Capacity = 120, Description = "The ultimate IMAX experience with massive screen, laser projection, and immersive 12-channel sound.",
                    HasDolbyAtmos = true, Has4K = true, HasReclinerSeats = false,
                    PremiumSurcharge = 12.00m, IsActive = true,
                    ImageUrl = "https://images.unsplash.com/photo-1596776900519-6a37e2c44748?w=600"
                },
                new Hall
                {
                    Id = 4, Name = "Premium Hall D", Type = HallType.Premium,
                    Capacity = 30, Description = "VIP private lounge with fully reclining seats, personal service, and 4K screen.",
                    HasDolbyAtmos = true, Has4K = true, HasReclinerSeats = true,
                    PremiumSurcharge = 15.00m, IsActive = true,
                    ImageUrl = "https://images.unsplash.com/photo-1524985069026-dd778a71c7b4?w=600"
                }
            );
 
            // =================== SEED: FOOD ITEMS ===================
            modelBuilder.Entity<FoodItem>().HasData(
                // Popcorn
                new FoodItem { Id = 1, Name = "Classic Butter Popcorn", Description = "Large bucket of golden butter popcorn", Price = 5.50m, Category = FoodCategory.Popcorn, IsBestSeller = true, ImageUrl = "https://images.unsplash.com/photo-1606297199700-4adee06dc45d?w=400", IsAvailable = true },
                new FoodItem { Id = 2, Name = "Caramel Popcorn", Description = "Sweet caramel glazed popcorn", Price = 6.00m, Category = FoodCategory.Popcorn, IsBestSeller = false, ImageUrl = "https://images.unsplash.com/photo-1578849278619-e73505e9610f?w=400", IsAvailable = true },
                new FoodItem { Id = 3, Name = "Spicy Popcorn", Description = "Hot chili seasoned popcorn for spice lovers", Price = 5.50m, Category = FoodCategory.Popcorn, IsBestSeller = false, ImageUrl = "https://images.unsplash.com/photo-1621939514649-280e2ee25f60?w=400", IsAvailable = true },
                // Drinks
                new FoodItem { Id = 4, Name = "Coca-Cola Large", Description = "Chilled Coca-Cola 750ml", Price = 3.50m, Category = FoodCategory.Drinks, IsBestSeller = true, ImageUrl = "https://images.unsplash.com/photo-1554866585-cd94860890b7?w=400", IsAvailable = true },
                new FoodItem { Id = 5, Name = "Fresh Orange Juice", Description = "Freshly squeezed orange juice", Price = 4.00m, Category = FoodCategory.Drinks, IsBestSeller = false, ImageUrl = "https://images.unsplash.com/photo-1621506289937-a8e4df240d0b?w=400", IsAvailable = true },
                new FoodItem { Id = 6, Name = "Mineral Water", Description = "500ml chilled water", Price = 2.00m, Category = FoodCategory.Drinks, IsBestSeller = false, ImageUrl = "https://images.unsplash.com/photo-1559839734-2b71ea197ec2?w=400", IsAvailable = true },
                // Combos
                new FoodItem { Id = 7, Name = "Classic Combo", Description = "Large popcorn + Large drink", Price = 8.00m, Category = FoodCategory.Combo, IsBestSeller = true, ImageUrl = "https://images.unsplash.com/photo-1585647347483-22b66260dfff?w=400", IsAvailable = true },
                new FoodItem { Id = 8, Name = "Family Combo", Description = "2 Large popcorns + 4 drinks + nachos", Price = 22.00m, Category = FoodCategory.Combo, IsBestSeller = true, ImageUrl = "https://images.unsplash.com/photo-1516195851888-6f1a981a862e?w=400", IsAvailable = true },
                // Snacks
                new FoodItem { Id = 9, Name = "Nachos with Cheese", Description = "Crispy nachos with warm cheese dip", Price = 5.00m, Category = FoodCategory.Snacks, IsBestSeller = false, ImageUrl = "https://images.unsplash.com/photo-1531749668029-2db88e4276c7?w=400", IsAvailable = true },
                new FoodItem { Id = 10, Name = "Hot Dog", Description = "Classic cinema hot dog with mustard & ketchup", Price = 4.50m, Category = FoodCategory.Snacks, IsBestSeller = false, ImageUrl = "https://images.unsplash.com/photo-1619740455993-9d622990d41f?w=400", IsAvailable = true },
                // Desserts
                new FoodItem { Id = 11, Name = "Vanilla Ice Cream", Description = "Creamy vanilla soft serve", Price = 3.50m, Category = FoodCategory.Desserts, IsBestSeller = false, ImageUrl = "https://images.unsplash.com/photo-1563805042-7684c019e1cb?w=400", IsAvailable = true },
                new FoodItem { Id = 12, Name = "Chocolate Brownie", Description = "Warm fudgy chocolate brownie", Price = 4.00m, Category = FoodCategory.Desserts, IsBestSeller = false, ImageUrl = "https://images.unsplash.com/photo-1564355808539-22fda35bed7e?w=400", IsAvailable = true }
            );
 
            // =================== SEED: OFFERS ===================
            modelBuilder.Entity<Offer>().HasData(
                new Offer
                {
                    Id = 1, Title = "Student Tuesday Deal", PromoCode = "STUDENT20",
                    Description = "20% off all tickets every Tuesday. Valid student ID required at the counter.",
                    Type = OfferType.Percentage, DiscountValue = 20,
                    StartDate = new DateTime(2025, 1, 1), EndDate = new DateTime(2026, 12, 31),
                    IsActive = true, BadgeColor = "info", ApplicableHallType = null
                },
                new Offer
                {
                    Id = 2, Title = "IMAX Weekend Special", PromoCode = "IMAXWEEKEND",
                    Description = "Book 2 IMAX tickets and get $5 off your total. Weekends only.",
                    Type = OfferType.FixedAmount, DiscountValue = 5,
                    StartDate = new DateTime(2025, 1, 1), EndDate = new DateTime(2026, 12, 31),
                    IsActive = true, BadgeColor = "primary", ApplicableHallType = HallType.IMAX
                },
                new Offer
                {
                    Id = 3, Title = "Buy 1 Get 1 Free — Mondays", PromoCode = "BOGO",
                    Description = "Buy one Standard ticket on Monday and get the second one absolutely free!",
                    Type = OfferType.BuyOneGetOne, DiscountValue = 100,
                    StartDate = new DateTime(2025, 1, 1), EndDate = new DateTime(2026, 12, 31),
                    IsActive = true, BadgeColor = "success", ApplicableHallType = HallType.Standard
                },
                new Offer
                {
                    Id = 4, Title = "Premium Date Night", PromoCode = "DATENITE",
                    Description = "2 Premium tickets + 2 drinks + 1 popcorn combo at a special bundled price.",
                    Type = OfferType.ComboMeal, DiscountValue = 15,
                    StartDate = new DateTime(2025, 1, 1), EndDate = new DateTime(2026, 12, 31),
                    IsActive = true, BadgeColor = "warning", ApplicableHallType = HallType.Premium
                },
                new Offer
                {
                    Id = 5, Title = "Family Pack", PromoCode = "FAMILY4",
                    Description = "4 tickets for the price of 3! Perfect for family outings.",
                    Type = OfferType.Percentage, DiscountValue = 25,
                    StartDate = new DateTime(2025, 1, 1), EndDate = new DateTime(2026, 12, 31),
                    IsActive = true, BadgeColor = "danger", ApplicableHallType = null
                }
            );
 
          
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
        HallId = 1,
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
        HallId = 2,
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
        HallId = 3,
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
        HallId = 1,
        TotalSeats = 60,
        AvailableSeats = 60,
        TicketPrice = 16.00m,
        IsActive = true
    }
);   
        }
 
        public static string HashPassword(string password)
        {
            return Convert.ToBase64String(
                System.Security.Cryptography.SHA256.HashData(
                    System.Text.Encoding.UTF8.GetBytes(password + "CINEMA_SALT")));
        }
    }
}