using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace cinemawebapp.Migrations
{
    /// <inheritdoc />
    public partial class AddRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ValidFrom", "ValidUntil" },
                values: new object[] { "20% off with a valid student ID. Available for all screenings, every day. Just select the Student ticket type when booking.", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "ValidFrom", "ValidUntil" },
                values: new object[] { "Free admission every Monday for veterans and senior citizens aged 65+. Present your ID at the box office.", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "DiscountPercent", "Emoji", "Title", "ValidFrom", "ValidUntil" },
                values: new object[] { "Buy one ticket every Wednesday and get a second one free. Valid for any screening on Wednesdays only.", 50m, "🎬", "Wednesday 1+1", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Promotions",
                columns: new[] { "Id", "Description", "DiscountPercent", "Emoji", "IsActive", "Title", "ValidFrom", "ValidUntil" },
                values: new object[,]
                {
                    { 4, "Two tickets for just 55 RON every Friday. Select the Couples Friday option when booking — only available on Fridays.", 0m, "💑", true, "Couples Friday", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Four tickets for 99 RON — perfect for a family night out. Select the Family Pack option when booking.", 0m, "👨‍👩‍👧‍👦", true, "Family Pack", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ValidFrom", "ValidUntil" },
                values: new object[] { "20% off with a valid student ID. Available for all screenings, every day.", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "ValidFrom", "ValidUntil" },
                values: new object[] { "Free admission every Monday for veterans and senior citizens aged 65+.", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Promotions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "DiscountPercent", "Emoji", "Title", "ValidFrom", "ValidUntil" },
                values: new object[] { "Buy 3 tickets, get the 4th free. Valid Saturday & Sunday only.", 25m, "👨‍👩‍👧‍👦", "Weekend Family Pack", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
