using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniCinema.Migrations
{
    /// <inheritdoc />
    public partial class RestoreMoviesAndAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "Id", "AvailableSeats", "Hall", "HallId", "IsActive", "MovieId", "ShowDateTime", "TicketPrice", "TotalSeats" },
                values: new object[,]
                {
                    { 1, 60, "Hall A", 1, true, 1, new DateTime(2026, 6, 1, 14, 0, 0, 0, DateTimeKind.Unspecified), 12.50m, 60 },
                    { 2, 60, "Hall B", 2, true, 1, new DateTime(2026, 6, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), 15.00m, 60 },
                    { 3, 60, "Hall C", 3, true, 2, new DateTime(2026, 6, 2, 16, 0, 0, 0, DateTimeKind.Unspecified), 14.00m, 60 },
                    { 4, 60, "Hall A", 1, true, 3, new DateTime(2026, 6, 2, 20, 0, 0, 0, DateTimeKind.Unspecified), 16.00m, 60 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
