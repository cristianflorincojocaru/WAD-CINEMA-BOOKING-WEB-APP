using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cinemawebapp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLinks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6,
                column: "TrailerUrl",
                value: "https://www.youtube.com/embed/fwLwaihdSo8");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 7,
                column: "TrailerUrl",
                value: "https://www.youtube.com/embed/T5IligQP7Fo");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ImagePath", "TrailerUrl" },
                values: new object[] { "/images/Pan’sLabyrinth.jpg", "https://www.youtube.com/embed/oOQV8gg9b5o" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ImagePath", "TrailerUrl" },
                values: new object[] { "/images/Schindler’sList.jpg", "https://www.youtube.com/embed/mxphAlJID9U" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 16,
                column: "TrailerUrl",
                value: "https://www.youtube.com/embed/T3taV43-lGc");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6,
                column: "TrailerUrl",
                value: "https://www.youtube.com/embed/9XCB6GGc3s0");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 7,
                column: "TrailerUrl",
                value: "https://www.youtube.com/embed/UUxbBMkOoM8");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ImagePath", "TrailerUrl" },
                values: new object[] { "/images/Pan'sLabyrinth.jpg", "https://www.youtube.com/embed/sRTsJITq2EY" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ImagePath", "TrailerUrl" },
                values: new object[] { "/images/Schindler'sList.jpg", "https://www.youtube.com/embed/gG22M1L6G4Q" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 16,
                column: "TrailerUrl",
                value: "https://www.youtube.com/embed/kovL8QOS408");
        }
    }
}
