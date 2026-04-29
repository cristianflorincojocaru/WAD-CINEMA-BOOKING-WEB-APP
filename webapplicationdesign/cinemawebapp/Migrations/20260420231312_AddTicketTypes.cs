using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace cinemawebapp.Migrations
{
    /// <inheritdoc />
    public partial class AddTicketTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TicketTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    MinSeats = table.Column<int>(type: "int", nullable: false),
                    MaxSeats = table.Column<int>(type: "int", nullable: false),
                    DayRestriction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Emoji = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TicketTypes",
                columns: new[] { "Id", "DayRestriction", "Emoji", "IsActive", "MaxSeats", "MinSeats", "Name", "Price" },
                values: new object[,]
                {
                    { 1, null, null, true, 5, 1, "Standard", 25m },
                    { 2, null, null, true, 5, 1, "Student", 18m },
                    { 3, null, null, true, 5, 1, "Senior", 20m },
                    { 4, "Friday", "💑", true, 2, 2, "Couples Friday", 55m },
                    { 5, null, "👨‍👩‍👧‍👦", true, 4, 4, "Family Pack", 99m },
                    { 6, "Wednesday", "🎟️", true, 2, 2, "Wednesday 1+1", 25m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicketTypes");
        }
    }
}
