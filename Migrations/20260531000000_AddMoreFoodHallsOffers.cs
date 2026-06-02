using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814

namespace MiniCinema.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreFoodHallsOffers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // ── More Food Items ──
            migrationBuilder.InsertData(
                table: "FoodItems",
                columns: new[] { "Id", "Name", "Description", "Price", "Category", "ImageUrl", "IsAvailable", "IsBestSeller" },
                values: new object[,]
                {
                    { 13, "Cheese Popcorn", "Cheddar cheese dusted popcorn — savory and addictive", 6.00m, 0, "https://images.unsplash.com/photo-1506354666786-959d6d497f1a?w=400", true, false },
                    { 14, "Mix Popcorn Bucket", "Half butter, half caramel — best of both worlds", 7.00m, 0, "https://images.unsplash.com/photo-1576186726115-4d51596775d1?w=400", true, true },
                    { 15, "Iced Lemonade", "Freshly made lemonade served over ice", 3.50m, 1, "https://images.unsplash.com/photo-1621506289937-a8e4df240d0b?w=400", true, false },
                    { 16, "Mineral Water", "500ml chilled sparkling mineral water", 2.00m, 1, "https://images.unsplash.com/photo-1548839140-29a749e1cf4d?w=400", true, false },
                    { 17, "Hot Chocolate", "Rich creamy hot chocolate with marshmallows", 4.50m, 1, "https://images.unsplash.com/photo-1542990253-0d0f5be5f0ed?w=400", true, false },
                    { 18, "Chicken Nuggets (6 pcs)", "Crispy golden chicken nuggets with dipping sauce", 6.50m, 3, "https://images.unsplash.com/photo-1562967914-608f82629710?w=400", true, true },
                    { 19, "Hot Dog", "Classic beef hot dog in a toasted bun with ketchup & mustard", 5.50m, 3, "https://images.unsplash.com/photo-1612392062631-94c93765e3d3?w=400", true, false },
                    { 20, "Pretzel Bites", "Warm soft pretzel bites served with cheese dip", 5.00m, 3, "https://images.unsplash.com/photo-1639561073-8c74a6b3dbb9?w=400", true, false },
                    { 21, "Mozzarella Sticks", "Crispy fried mozzarella sticks with marinara sauce", 6.00m, 3, "https://images.unsplash.com/photo-1548340748-6d2b7d7da280?w=400", true, false },
                    { 22, "Premium Combo", "Large popcorn + 2 drinks + Nachos — perfect for two", 15.00m, 2, "https://images.unsplash.com/photo-1516195851888-6f1a981a862e?w=400", true, true },
                    { 23, "Kids Combo", "Small popcorn + juice box + chocolate brownie", 9.00m, 2, "https://images.unsplash.com/photo-1476224203421-9ac39bcb3327?w=400", true, false },
                    { 24, "Strawberry Sundae", "Vanilla soft serve topped with fresh strawberry sauce", 4.50m, 4, "https://images.unsplash.com/photo-1587314168485-3236d6710814?w=400", true, false },
                    { 25, "Churros (4 pcs)", "Golden fried churros dusted with cinnamon sugar, served with chocolate dip", 5.50m, 4, "https://images.unsplash.com/photo-1593441895-4ca2cc844b7d?w=400", true, true },
                });

            // ── More Halls ──
            migrationBuilder.InsertData(
                table: "Halls",
                columns: new[] { "Id", "Name", "Type", "Capacity", "Description", "HasDolbyAtmos", "Has4K", "HasReclinerSeats", "IsActive", "PremiumSurcharge", "ImageUrl" },
                values: new object[,]
                {
                    { 5, "Standard Hall E", 0, 100, "Our largest standard hall with tiered seating and a wide HD screen — perfect for blockbuster nights.", false, false, false, true, 0.00m, "https://images.unsplash.com/photo-1460881680858-30d872d5b530?w=600" },
                    { 6, "IMAX Hall F", 2, 150, "Our second IMAX hall with an even larger screen and enhanced 4D seating for a fully immersive experience.", true, true, false, true, 12.00m, "https://images.unsplash.com/photo-1596776900519-6a37e2c44748?w=600" },
                    { 7, "Premium Hall G", 1, 20, "Ultra-exclusive 20-seat boutique hall with personal butler service, gourmet menu, and 4K laser screen.", true, true, true, true, 20.00m, "https://images.unsplash.com/photo-1536440136628-849c177e76a1?w=600" },
                    { 8, "Standard Hall H", 0, 60, "A cozy mid-size hall ideal for indie films, special screenings, and private events.", false, true, false, true, 0.00m, "https://images.unsplash.com/photo-1507924538820-ede94a04019d?w=600" },
                });

            // ── Fix Offer Dates + Add New Offers ──
            migrationBuilder.UpdateData(table: "Offers", keyColumn: "Id", keyValue: 1, column: "StartDate", value: new DateTime(2026, 1, 1));
            migrationBuilder.UpdateData(table: "Offers", keyColumn: "Id", keyValue: 1, column: "EndDate",   value: new DateTime(2026, 8, 31));
            migrationBuilder.UpdateData(table: "Offers", keyColumn: "Id", keyValue: 2, column: "StartDate", value: new DateTime(2026, 5, 1));
            migrationBuilder.UpdateData(table: "Offers", keyColumn: "Id", keyValue: 2, column: "EndDate",   value: new DateTime(2026, 7, 31));
            migrationBuilder.UpdateData(table: "Offers", keyColumn: "Id", keyValue: 3, column: "StartDate", value: new DateTime(2026, 6, 1));
            migrationBuilder.UpdateData(table: "Offers", keyColumn: "Id", keyValue: 3, column: "EndDate",   value: new DateTime(2026, 9, 30));
            migrationBuilder.UpdateData(table: "Offers", keyColumn: "Id", keyValue: 4, column: "StartDate", value: new DateTime(2026, 5, 15));
            migrationBuilder.UpdateData(table: "Offers", keyColumn: "Id", keyValue: 4, column: "EndDate",   value: new DateTime(2026, 8, 15));
            migrationBuilder.UpdateData(table: "Offers", keyColumn: "Id", keyValue: 5, column: "StartDate", value: new DateTime(2026, 6, 1));
            migrationBuilder.UpdateData(table: "Offers", keyColumn: "Id", keyValue: 5, column: "EndDate",   value: new DateTime(2026, 12, 31));

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "Title", "PromoCode", "Description", "Type", "DiscountValue", "StartDate", "EndDate", "IsActive", "BadgeColor", "ApplicableHallType", "ImageUrl" },
                values: new object[,]
                {
                    { 6, "Summer Blockbuster Pass", "SUMMER26", "Enjoy 15% off any booking throughout summer. No restrictions — all halls, all days.", 0, 15m, new DateTime(2026, 6, 21), new DateTime(2026, 9, 21), true, "warning", null, "" },
                    { 7, "Early Bird Special",       "EARLYBIRD", "Book any screening before 12:00 PM and save $3 on your ticket price.", 1, 3m,  new DateTime(2026, 5, 1),  new DateTime(2026, 10, 31), true, "success", null, "" },
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(table: "FoodItems", keyColumn: "Id", keyValues: new object[] { 13,14,15,16,17,18,19,20,21,22,23,24,25 });
            migrationBuilder.DeleteData(table: "Halls", keyColumn: "Id", keyValues: new object[] { 5,6,7,8 });
            migrationBuilder.DeleteData(table: "Offers", keyColumn: "Id", keyValues: new object[] { 6,7 });
        }
    }
}
