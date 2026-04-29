using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace cinemawebapp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateScreeningDates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartTime",
                value: new DateTime(2026, 4, 20, 18, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "MovieId", "StartTime" },
                values: new object[] { 2, new DateTime(2026, 4, 20, 21, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "MovieId", "StartTime" },
                values: new object[] { 3, new DateTime(2026, 4, 21, 17, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "HallId", "MovieId", "StartTime" },
                values: new object[] { 4, 1, new DateTime(2026, 4, 21, 20, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "HallId", "StartTime" },
                values: new object[] { 5, new DateTime(2026, 4, 22, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Screenings",
                columns: new[] { "Id", "HallId", "MovieId", "StartTime" },
                values: new object[,]
                {
                    { 6, 6, 3, new DateTime(2026, 4, 22, 21, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 2, 1, new DateTime(2026, 4, 23, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 3, 2, new DateTime(2026, 4, 23, 20, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 1, 3, new DateTime(2026, 4, 24, 17, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 5, 1, new DateTime(2026, 4, 24, 20, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 4, 2, new DateTime(2026, 4, 25, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 6, 3, new DateTime(2026, 4, 25, 19, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 3, 1, new DateTime(2026, 4, 26, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 1, 2, new DateTime(2026, 4, 26, 18, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.UpdateData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartTime",
                value: new DateTime(2025, 5, 10, 18, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "MovieId", "StartTime" },
                values: new object[] { 1, new DateTime(2025, 5, 10, 21, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "MovieId", "StartTime" },
                values: new object[] { 2, new DateTime(2025, 5, 11, 20, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "HallId", "MovieId", "StartTime" },
                values: new object[] { 5, 3, new DateTime(2025, 5, 12, 17, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Screenings",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "HallId", "StartTime" },
                values: new object[] { 6, new DateTime(2025, 5, 13, 19, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
