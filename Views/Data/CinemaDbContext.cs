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
                },
                new Hall
                {
                    Id = 5, Name = "Standard Hall E", Type = HallType.Standard,
                    Capacity = 100, Description = "Our largest standard hall with tiered seating and a wide HD screen — perfect for blockbuster nights.",
                    HasDolbyAtmos = false, Has4K = false, HasReclinerSeats = false,
                    PremiumSurcharge = 0, IsActive = true,
                    ImageUrl = "https://images.unsplash.com/photo-1460881680858-30d872d5b530?w=600"
                },
                new Hall
                {
                    Id = 6, Name = "IMAX Hall F", Type = HallType.IMAX,
                    Capacity = 150, Description = "Our second IMAX hall with an even larger screen and enhanced 4D seating for a fully immersive experience.",
                    HasDolbyAtmos = true, Has4K = true, HasReclinerSeats = false,
                    PremiumSurcharge = 12.00m, IsActive = true,
                    ImageUrl = "https://images.unsplash.com/photo-1596776900519-6a37e2c44748?w=600"
                },
                new Hall
                {
                    Id = 7, Name = "Premium Hall G", Type = HallType.Premium,
                    Capacity = 20, Description = "Ultra-exclusive 20-seat boutique hall with personal butler service, gourmet menu, and 4K laser screen.",
                    HasDolbyAtmos = true, Has4K = true, HasReclinerSeats = true,
                    PremiumSurcharge = 20.00m, IsActive = true,
                    ImageUrl = "https://images.unsplash.com/photo-1536440136628-849c177e76a1?w=600"
                },
                new Hall
                {
                    Id = 8, Name = "Standard Hall H", Type = HallType.Standard,
                    Capacity = 60, Description = "A cozy mid-size hall ideal for indie films, special screenings, and private events.",
                    HasDolbyAtmos = false, Has4K = true, HasReclinerSeats = false,
                    PremiumSurcharge = 0, IsActive = true,
                    ImageUrl = "https://images.unsplash.com/photo-1507924538820-ede94a04019d?w=600"
                }
            );
 
            // =================== SEED: FOOD ITEMS ===================
            modelBuilder.Entity<FoodItem>().HasData(
                // Popcorn
                new FoodItem { Id = 1, Name = "Classic Butter Popcorn", Description = "Large bucket of golden butter popcorn", Price = 5.50m, Category = FoodCategory.Popcorn, IsBestSeller = true, ImageUrl =  "/images/popcorn-classic.png", IsAvailable = true },
                new FoodItem { Id = 2, Name = "Caramel Popcorn", Description = "Sweet caramel glazed popcorn", Price = 6.00m, Category = FoodCategory.Popcorn, IsBestSeller = false, ImageUrl = "/images/caramel.png", IsAvailable = true },
                new FoodItem { Id = 3, Name = "Spicy Popcorn", Description = "Hot chili seasoned popcorn for spice lovers", Price = 5.50m, Category = FoodCategory.Popcorn, IsBestSeller = false, ImageUrl = "/images/spicy.png", IsAvailable = true },
                // Drinks
                new FoodItem { Id = 4, Name = "Coca-Cola Large", Description = "Chilled Coca-Cola 750ml", Price = 3.50m, Category = FoodCategory.Drinks, IsBestSeller = true, ImageUrl = "https://images.unsplash.com/photo-1554866585-cd94860890b7?w=400", IsAvailable = true },
                new FoodItem { Id = 5, Name = "Fresh Orange Juice", Description = "Freshly squeezed orange juice", Price = 4.00m, Category = FoodCategory.Drinks, IsBestSeller = false, ImageUrl = "https://images.unsplash.com/photo-1621506289937-a8e4df240d0b?w=400", IsAvailable = true },
                // Combos
                new FoodItem { Id = 7, Name = "Classic Combo", Description = "Large popcorn + Large drink", Price = 8.00m, Category = FoodCategory.Combo, IsBestSeller = true, ImageUrl = "https://images.unsplash.com/photo-1585647347483-22b66260dfff?w=400", IsAvailable = true },
                new FoodItem { Id = 8, Name = "Family Combo", Description = "2 Large popcorns + 4 drinks + nachos", Price = 22.00m, Category = FoodCategory.Combo, IsBestSeller = true, ImageUrl = "https://images.unsplash.com/photo-1516195851888-6f1a981a862e?w=400", IsAvailable = true },
                // Snacks
                new FoodItem { Id = 9, Name = "Nachos with Cheese", Description = "Crispy nachos with warm cheese dip", Price = 5.00m, Category = FoodCategory.Snacks, IsBestSeller = false, ImageUrl = "https://images.unsplash.com/photo-1531749668029-2db88e4276c7?w=400", IsAvailable = true },
                // Desserts
                new FoodItem { Id = 11, Name = "Vanilla Ice Cream", Description = "Creamy vanilla soft serve", Price = 3.50m, Category = FoodCategory.Desserts, IsBestSeller = false, ImageUrl = "https://images.unsplash.com/photo-1563805042-7684c019e1cb?w=400", IsAvailable = true },
                new FoodItem { Id = 12, Name = "Chocolate Brownie", Description = "Warm fudgy chocolate brownie", Price = 4.00m, Category = FoodCategory.Desserts, IsBestSeller = false, ImageUrl = "https://images.unsplash.com/photo-1564355808539-22fda35bed7e?w=400", IsAvailable = true },
                // More Popcorn
                new FoodItem { Id = 13, Name = "Cheese Popcorn", Description = "Cheddar cheese dusted popcorn — savory and addictive", Price = 6.00m, Category = FoodCategory.Popcorn, IsBestSeller = false, ImageUrl = "https://images.unsplash.com/photo-1506354666786-959d6d497f1a?w=400", IsAvailable = true },
                new FoodItem { Id = 14, Name = "Mix Popcorn Bucket", Description = "Half butter, half caramel — best of both worlds", Price = 7.00m, Category = FoodCategory.Popcorn, IsBestSeller = true, ImageUrl = "https://images.unsplash.com/photo-1576186726115-4d51596775d1?w=400", IsAvailable = true },
                // More Drinks
                new FoodItem { Id = 15, Name = "Iced Lemonade", Description = "Freshly made lemonade served over ice", Price = 3.50m, Category = FoodCategory.Drinks, IsBestSeller = false, ImageUrl = "https://images.unsplash.com/photo-1621506289937-a8e4df240d0b?w=400", IsAvailable = true },
                new FoodItem { Id = 16, Name = "Mineral Water", Description = "500ml chilled sparkling mineral water", Price = 2.00m, Category = FoodCategory.Drinks, IsBestSeller = false, ImageUrl = "https://images.unsplash.com/photo-1548839140-29a749e1cf4d?w=400", IsAvailable = true },
                new FoodItem { Id = 17, Name = "Hot Chocolate", Description = "Rich creamy hot chocolate with marshmallows", Price = 4.50m, Category = FoodCategory.Drinks, IsBestSeller = false, ImageUrl = "https://images.unsplash.com/photo-1542990253-0d0f5be5f0ed?w=400", IsAvailable = true },
                // More Snacks
                new FoodItem { Id = 18, Name = "Chicken Nuggets (6 pcs)", Description = "Crispy golden chicken nuggets with dipping sauce", Price = 6.50m, Category = FoodCategory.Snacks, IsBestSeller = true, ImageUrl = "https://images.unsplash.com/photo-1562967914-608f82629710?w=400", IsAvailable = true },
                new FoodItem { Id = 19, Name = "Hot Dog", Description = "Classic beef hot dog in a toasted bun with ketchup & mustard", Price = 5.50m, Category = FoodCategory.Snacks, IsBestSeller = false, ImageUrl = "https://images.unsplash.com/photo-1612392062631-94c93765e3d3?w=400", IsAvailable = true },
                new FoodItem { Id = 20, Name = "Pretzel Bites", Description = "Warm soft pretzel bites served with cheese dip", Price = 5.00m, Category = FoodCategory.Snacks, IsBestSeller = false, ImageUrl = "https://images.unsplash.com/photo-1639561073-8c74a6b3dbb9?w=400", IsAvailable = true },
                new FoodItem { Id = 21, Name = "Mozzarella Sticks", Description = "Crispy fried mozzarella sticks with marinara sauce", Price = 6.00m, Category = FoodCategory.Snacks, IsBestSeller = false, ImageUrl = "https://images.unsplash.com/photo-1548340748-6d2b7d7da280?w=400", IsAvailable = true },
                // More Combos
                new FoodItem { Id = 22, Name = "Premium Combo", Description = "Large popcorn + 2 drinks + Nachos — perfect for two", Price = 15.00m, Category = FoodCategory.Combo, IsBestSeller = true, ImageUrl = "https://images.unsplash.com/photo-1516195851888-6f1a981a862e?w=400", IsAvailable = true },
                new FoodItem { Id = 23, Name = "Kids Combo", Description = "Small popcorn + juice box + chocolate brownie", Price = 9.00m, Category = FoodCategory.Combo, IsBestSeller = false, ImageUrl = "https://images.unsplash.com/photo-1476224203421-9ac39bcb3327?w=400", IsAvailable = true },
                // More Desserts
                new FoodItem { Id = 24, Name = "Strawberry Sundae", Description = "Vanilla soft serve topped with fresh strawberry sauce", Price = 4.50m, Category = FoodCategory.Desserts, IsBestSeller = false, ImageUrl = "https://images.unsplash.com/photo-1587314168485-3236d6710814?w=400", IsAvailable = true },
                new FoodItem { Id = 25, Name = "Churros (4 pcs)", Description = "Golden fried churros dusted with cinnamon sugar, served with chocolate dip", Price = 5.50m, Category = FoodCategory.Desserts, IsBestSeller = true, ImageUrl = "https://images.unsplash.com/photo-1593441895-4ca2cc844b7d?w=400", IsAvailable = true }
            );
 
            // =================== SEED: OFFERS ===================
            modelBuilder.Entity<Offer>().HasData(
                new Offer
                {
                    Id = 1, Title = "Student Tuesday Deal", PromoCode = "STUDENT20",
                    Description = "20% off all tickets every Tuesday. Valid student ID required at the counter.",
                    Type = OfferType.Percentage, DiscountValue = 20,
                    StartDate = new DateTime(2026, 1, 1), EndDate = new DateTime(2026, 8, 31),
                    IsActive = true, BadgeColor = "info", ApplicableHallType = null
                },
                new Offer
                {
                    Id = 2, Title = "IMAX Weekend Special", PromoCode = "IMAXWEEKEND",
                    Description = "Book 2 IMAX tickets and get $5 off your total. Weekends only.",
                    Type = OfferType.FixedAmount, DiscountValue = 5,
                    StartDate = new DateTime(2026, 5, 1), EndDate = new DateTime(2026, 7, 31),
                    IsActive = true, BadgeColor = "primary", ApplicableHallType = HallType.IMAX
                },
                new Offer
                {
                    Id = 3, Title = "Buy 1 Get 1 Free — Mondays", PromoCode = "BOGO",
                    Description = "Buy one Standard ticket on Monday and get the second one absolutely free!",
                    Type = OfferType.BuyOneGetOne, DiscountValue = 100,
                    StartDate = new DateTime(2026, 6, 1), EndDate = new DateTime(2026, 9, 30),
                    IsActive = true, BadgeColor = "success", ApplicableHallType = HallType.Standard
                },
                new Offer
                {
                    Id = 4, Title = "Premium Date Night", PromoCode = "DATENITE",
                    Description = "2 Premium tickets + 2 drinks + 1 popcorn combo at a special bundled price.",
                    Type = OfferType.ComboMeal, DiscountValue = 15,
                    StartDate = new DateTime(2026, 5, 15), EndDate = new DateTime(2026, 8, 15),
                    IsActive = true, BadgeColor = "warning", ApplicableHallType = HallType.Premium
                },
                new Offer
                {
                    Id = 5, Title = "Family Pack", PromoCode = "FAMILY4",
                    Description = "4 tickets for the price of 3! Perfect for family outings.",
                    Type = OfferType.Percentage, DiscountValue = 25,
                    StartDate = new DateTime(2026, 6, 1), EndDate = new DateTime(2026, 12, 31),
                    IsActive = true, BadgeColor = "danger", ApplicableHallType = null
                },
                new Offer
                {
                    Id = 6, Title = "Summer Blockbuster Pass", PromoCode = "SUMMER26",
                    Description = "Enjoy 15% off any booking throughout summer. No restrictions — all halls, all days.",
                    Type = OfferType.Percentage, DiscountValue = 15,
                    StartDate = new DateTime(2026, 6, 21), EndDate = new DateTime(2026, 9, 21),
                    IsActive = true, BadgeColor = "warning", ApplicableHallType = null
                },
                new Offer
                {
                    Id = 7, Title = "Early Bird Special", PromoCode = "EARLYBIRD",
                    Description = "Book any screening before 12:00 PM and save $3 on your ticket price.",
                    Type = OfferType.FixedAmount, DiscountValue = 3,
                    StartDate = new DateTime(2026, 5, 1), EndDate = new DateTime(2026, 10, 31),
                    IsActive = true, BadgeColor = "success", ApplicableHallType = null
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