using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniCinema.Migrations
{
    /// <inheritdoc />
    public partial class FixMovieTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FoodItems",
                columns: new[] { "Id", "Category", "Description", "ImageUrl", "IsAvailable", "IsBestSeller", "Name", "Price" },
                values: new object[,]
                {
                    { 13, 0, "Cheddar cheese dusted popcorn — savory and addictive", "https://images.unsplash.com/photo-1506354666786-959d6d497f1a?w=400", true, false, "Cheese Popcorn", 6.00m },
                    { 14, 0, "Half butter, half caramel — best of both worlds", "https://images.unsplash.com/photo-1576186726115-4d51596775d1?w=400", true, true, "Mix Popcorn Bucket", 7.00m },
                    { 15, 1, "Freshly made lemonade served over ice", "https://images.unsplash.com/photo-1621506289937-a8e4df240d0b?w=400", true, false, "Iced Lemonade", 3.50m },
                    { 16, 1, "500ml chilled sparkling mineral water", "https://images.unsplash.com/photo-1548839140-29a749e1cf4d?w=400", true, false, "Mineral Water", 2.00m },
                    { 17, 1, "Rich creamy hot chocolate with marshmallows", "https://images.unsplash.com/photo-1542990253-0d0f5be5f0ed?w=400", true, false, "Hot Chocolate", 4.50m },
                    { 18, 3, "Crispy golden chicken nuggets with dipping sauce", "https://images.unsplash.com/photo-1562967914-608f82629710?w=400", true, true, "Chicken Nuggets (6 pcs)", 6.50m },
                    { 19, 3, "Classic beef hot dog in a toasted bun with ketchup & mustard", "https://images.unsplash.com/photo-1612392062631-94c93765e3d3?w=400", true, false, "Hot Dog", 5.50m },
                    { 20, 3, "Warm soft pretzel bites served with cheese dip", "https://images.unsplash.com/photo-1639561073-8c74a6b3dbb9?w=400", true, false, "Pretzel Bites", 5.00m },
                    { 21, 3, "Crispy fried mozzarella sticks with marinara sauce", "https://images.unsplash.com/photo-1548340748-6d2b7d7da280?w=400", true, false, "Mozzarella Sticks", 6.00m },
                    { 22, 2, "Large popcorn + 2 drinks + Nachos — perfect for two", "https://images.unsplash.com/photo-1516195851888-6f1a981a862e?w=400", true, true, "Premium Combo", 15.00m },
                    { 23, 2, "Small popcorn + juice box + chocolate brownie", "https://images.unsplash.com/photo-1476224203421-9ac39bcb3327?w=400", true, false, "Kids Combo", 9.00m },
                    { 24, 4, "Vanilla soft serve topped with fresh strawberry sauce", "https://images.unsplash.com/photo-1587314168485-3236d6710814?w=400", true, false, "Strawberry Sundae", 4.50m },
                    { 25, 4, "Golden fried churros dusted with cinnamon sugar, served with chocolate dip", "https://images.unsplash.com/photo-1593441895-4ca2cc844b7d?w=400", true, true, "Churros (4 pcs)", 5.50m }
                });

            migrationBuilder.InsertData(
                table: "Halls",
                columns: new[] { "Id", "Capacity", "Description", "Has4K", "HasDolbyAtmos", "HasReclinerSeats", "ImageUrl", "IsActive", "Name", "PremiumSurcharge", "Type" },
                values: new object[,]
                {
                    { 5, 100, "Our largest standard hall with tiered seating and a wide HD screen — perfect for blockbuster nights.", false, false, false, "https://images.unsplash.com/photo-1460881680858-30d872d5b530?w=600", true, "Standard Hall E", 0m, 0 },
                    { 6, 150, "Our second IMAX hall with an even larger screen and enhanced 4D seating for a fully immersive experience.", true, true, false, "https://images.unsplash.com/photo-1596776900519-6a37e2c44748?w=600", true, "IMAX Hall F", 12.00m, 2 },
                    { 7, 20, "Ultra-exclusive 20-seat boutique hall with personal butler service, gourmet menu, and 4K laser screen.", true, true, true, "https://images.unsplash.com/photo-1536440136628-849c177e76a1?w=600", true, "Premium Hall G", 20.00m, 1 },
                    { 8, 60, "A cozy mid-size hall ideal for indie films, special screenings, and private events.", true, false, false, "https://images.unsplash.com/photo-1507924538820-ede94a04019d?w=600", true, "Standard Hall H", 0m, 0 }
                });

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 5,
                column: "StartDate",
                value: new DateTime(2026, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "ApplicableHallType", "BadgeColor", "Description", "DiscountValue", "EndDate", "ImageUrl", "IsActive", "PromoCode", "StartDate", "Title", "Type" },
                values: new object[,]
                {
                    { 6, null, "warning", "Enjoy 15% off any booking throughout summer. No restrictions — all halls, all days.", 15m, new DateTime(2026, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, "SUMMER26", new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Summer Blockbuster Pass", 0 },
                    { 7, null, "success", "Book any screening before 12:00 PM and save $3 on your ticket price.", 3m, new DateTime(2026, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, "EARLYBIRD", new DateTime(2026, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Early Bird Special", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Halls",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Halls",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Halls",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Halls",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 5,
                column: "StartDate",
                value: new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
