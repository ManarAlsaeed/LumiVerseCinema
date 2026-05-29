using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniCinema.Migrations
{
    /// <inheritdoc />
    public partial class FoodOffersHalls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Showtimes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AddColumn<int>(
                name: "HallId",
                table: "Showtimes",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FoodItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Category = table.Column<int>(type: "INTEGER", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    IsAvailable = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsBestSeller = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BookingId = table.Column<int>(type: "INTEGER", nullable: true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "TEXT", nullable: false),
                    OrderedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodOrders_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FoodOrders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Halls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Capacity = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    HasDolbyAtmos = table.Column<bool>(type: "INTEGER", nullable: false),
                    Has4K = table.Column<bool>(type: "INTEGER", nullable: false),
                    HasReclinerSeats = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    PremiumSurcharge = table.Column<decimal>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Halls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    DiscountValue = table.Column<decimal>(type: "TEXT", nullable: false),
                    PromoCode = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    BadgeColor = table.Column<string>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    ApplicableHallType = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodOrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FoodOrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    FoodItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodOrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodOrderItems_FoodItems_FoodItemId",
                        column: x => x.FoodItemId,
                        principalTable: "FoodItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodOrderItems_FoodOrders_FoodOrderId",
                        column: x => x.FoodOrderId,
                        principalTable: "FoodOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FoodItems",
                columns: new[] { "Id", "Category", "Description", "ImageUrl", "IsAvailable", "IsBestSeller", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 0, "Large bucket of golden butter popcorn", "https://images.unsplash.com/photo-1606297199700-4adee06dc45d?w=400", true, true, "Classic Butter Popcorn", 5.50m },
                    { 2, 0, "Sweet caramel glazed popcorn", "https://images.unsplash.com/photo-1578849278619-e73505e9610f?w=400", true, false, "Caramel Popcorn", 6.00m },
                    { 3, 0, "Hot chili seasoned popcorn for spice lovers", "https://images.unsplash.com/photo-1621939514649-280e2ee25f60?w=400", true, false, "Spicy Popcorn", 5.50m },
                    { 4, 1, "Chilled Coca-Cola 750ml", "https://images.unsplash.com/photo-1554866585-cd94860890b7?w=400", true, true, "Coca-Cola Large", 3.50m },
                    { 5, 1, "Freshly squeezed orange juice", "https://images.unsplash.com/photo-1621506289937-a8e4df240d0b?w=400", true, false, "Fresh Orange Juice", 4.00m },
                    { 6, 1, "500ml chilled water", "https://images.unsplash.com/photo-1559839734-2b71ea197ec2?w=400", true, false, "Mineral Water", 2.00m },
                    { 7, 2, "Large popcorn + Large drink", "https://images.unsplash.com/photo-1585647347483-22b66260dfff?w=400", true, true, "Classic Combo", 8.00m },
                    { 8, 2, "2 Large popcorns + 4 drinks + nachos", "https://images.unsplash.com/photo-1516195851888-6f1a981a862e?w=400", true, true, "Family Combo", 22.00m },
                    { 9, 3, "Crispy nachos with warm cheese dip", "https://images.unsplash.com/photo-1531749668029-2db88e4276c7?w=400", true, false, "Nachos with Cheese", 5.00m },
                    { 10, 3, "Classic cinema hot dog with mustard & ketchup", "https://images.unsplash.com/photo-1619740455993-9d622990d41f?w=400", true, false, "Hot Dog", 4.50m },
                    { 11, 4, "Creamy vanilla soft serve", "https://images.unsplash.com/photo-1563805042-7684c019e1cb?w=400", true, false, "Vanilla Ice Cream", 3.50m },
                    { 12, 4, "Warm fudgy chocolate brownie", "https://images.unsplash.com/photo-1564355808539-22fda35bed7e?w=400", true, false, "Chocolate Brownie", 4.00m }
                });

            migrationBuilder.InsertData(
                table: "Halls",
                columns: new[] { "Id", "Capacity", "Description", "Has4K", "HasDolbyAtmos", "HasReclinerSeats", "ImageUrl", "IsActive", "Name", "PremiumSurcharge", "Type" },
                values: new object[,]
                {
                    { 1, 80, "Classic cinema experience with comfortable seats.", false, false, false, "https://images.unsplash.com/photo-1489599849927-2ee91cede3ba?w=600", true, "Standard Hall A", 0m, 0 },
                    { 2, 40, "Luxury recliner seats with Dolby Atmos surround sound and 4K projection.", true, true, true, "https://images.unsplash.com/photo-1517604931442-7e0c8ed2963c?w=600", true, "Premium Hall B", 8.00m, 1 },
                    { 3, 120, "The ultimate IMAX experience with massive screen, laser projection, and immersive 12-channel sound.", true, true, false, "https://images.unsplash.com/photo-1596776900519-6a37e2c44748?w=600", true, "IMAX Hall C", 12.00m, 2 },
                    { 4, 30, "VIP private lounge with fully reclining seats, personal service, and 4K screen.", true, true, true, "https://images.unsplash.com/photo-1524985069026-dd778a71c7b4?w=600", true, "Premium Hall D", 15.00m, 1 }
                });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "ApplicableHallType", "BadgeColor", "Description", "DiscountValue", "EndDate", "ImageUrl", "IsActive", "PromoCode", "StartDate", "Title", "Type" },
                values: new object[,]
                {
                    { 1, null, "info", "20% off all tickets every Tuesday. Valid student ID required at the counter.", 20m, new DateTime(2026, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, "STUDENT20", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Student Tuesday Deal", 0 },
                    { 2, 2, "primary", "Book 2 IMAX tickets and get $5 off your total. Weekends only.", 5m, new DateTime(2026, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, "IMAXWEEKEND", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "IMAX Weekend Special", 1 },
                    { 3, 0, "success", "Buy one Standard ticket on Monday and get the second one absolutely free!", 100m, new DateTime(2026, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, "BOGO", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Buy 1 Get 1 Free — Mondays", 2 },
                    { 4, 1, "warning", "2 Premium tickets + 2 drinks + 1 popcorn combo at a special bundled price.", 15m, new DateTime(2026, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, "DATENITE", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Premium Date Night", 3 },
                    { 5, null, "danger", "4 tickets for the price of 3! Perfect for family outings.", 25m, new DateTime(2026, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, "FAMILY4", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Family Pack", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Showtimes_HallId",
                table: "Showtimes",
                column: "HallId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodOrderItems_FoodItemId",
                table: "FoodOrderItems",
                column: "FoodItemId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodOrderItems_FoodOrderId",
                table: "FoodOrderItems",
                column: "FoodOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodOrders_BookingId",
                table: "FoodOrders",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodOrders_UserId",
                table: "FoodOrders",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Showtimes_Halls_HallId",
                table: "Showtimes",
                column: "HallId",
                principalTable: "Halls",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Showtimes_Halls_HallId",
                table: "Showtimes");

            migrationBuilder.DropTable(
                name: "FoodOrderItems");

            migrationBuilder.DropTable(
                name: "Halls");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "FoodItems");

            migrationBuilder.DropTable(
                name: "FoodOrders");

            migrationBuilder.DropIndex(
                name: "IX_Showtimes_HallId",
                table: "Showtimes");

            migrationBuilder.DropColumn(
                name: "HallId",
                table: "Showtimes");

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Cast", "CreatedAt", "Description", "Director", "DurationMinutes", "Genre", "IsActive", "PosterUrl", "Rating", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, "Leonardo DiCaprio, Joseph Gordon-Levitt", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A skilled thief enters dreams to steal secrets and plant ideas.", "Christopher Nolan", 148, "Sci-Fi", true, "https://image.tmdb.org/t/p/w500/oYuLEt3zVCKq57qu2F8dT7NIa6f.jpg", 8.8000000000000007, new DateTime(2010, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inception" },
                    { 2, "Matthew McConaughey, Anne Hathaway", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A group of explorers travel through space to save humanity.", "Christopher Nolan", 169, "Sci-Fi", true, "https://image.tmdb.org/t/p/w500/gEU2QniE6E77NI6lCU6MxlNBvIx.jpg", 8.6999999999999993, new DateTime(2014, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Interstellar" },
                    { 3, "Christian Bale, Heath Ledger", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Batman faces the Joker, a criminal mastermind spreading chaos.", "Christopher Nolan", 152, "Action", true, "https://image.tmdb.org/t/p/w500/qJ2tW6WMUDux911r6m7haRef0WH.jpg", 9.0, new DateTime(2008, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Dark Knight" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FullName", "IsAdmin", "PasswordHash" },
                values: new object[] { 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@minicinema.com", "Admin", true, "a8c0FSuYbAljQVFfcAQ5i/APfHmGAjviYalifjtzw+U=" });

            migrationBuilder.InsertData(
                table: "Showtimes",
                columns: new[] { "Id", "AvailableSeats", "Hall", "IsActive", "MovieId", "ShowDateTime", "TicketPrice", "TotalSeats" },
                values: new object[,]
                {
                    { 1, 60, "Hall A", true, 1, new DateTime(2026, 6, 1, 14, 0, 0, 0, DateTimeKind.Unspecified), 12.50m, 60 },
                    { 2, 60, "Hall B", true, 1, new DateTime(2026, 6, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), 15.00m, 60 },
                    { 3, 60, "Hall C", true, 2, new DateTime(2026, 6, 2, 16, 0, 0, 0, DateTimeKind.Unspecified), 14.00m, 60 },
                    { 4, 60, "Hall A", true, 3, new DateTime(2026, 6, 2, 20, 0, 0, 0, DateTimeKind.Unspecified), 16.00m, 60 }
                });
        }
    }
}
