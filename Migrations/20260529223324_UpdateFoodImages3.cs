using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniCinema.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFoodImages3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "/images/spicy.png");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "/imagesspicy.png");

            migrationBuilder.InsertData(
                table: "FoodItems",
                columns: new[] { "Id", "Category", "Description", "ImageUrl", "IsAvailable", "IsBestSeller", "Name", "Price" },
                values: new object[,]
                {
                    { 6, 1, "500ml chilled water", "https://images.unsplash.com/photo-1559839734-2b71ea197ec2?w=400", true, false, "Mineral Water", 2.00m },
                    { 10, 3, "Classic cinema hot dog with mustard & ketchup", "https://images.unsplash.com/photo-1619740455993-9d622990d41f?w=400", true, false, "Hot Dog", 4.50m }
                });
        }
    }
}
