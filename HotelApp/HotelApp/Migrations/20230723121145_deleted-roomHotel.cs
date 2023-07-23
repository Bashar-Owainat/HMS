using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelApp.Migrations
{
    /// <inheritdoc />
    public partial class deletedroomHotel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "hotelRooms");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "hotelRooms",
                columns: table => new
                {
                    hotelId = table.Column<int>(type: "int", nullable: false),
                    roomId = table.Column<int>(type: "int", nullable: false),
                    petFriendly = table.Column<bool>(type: "bit", nullable: false),
                    rate = table.Column<int>(type: "int", nullable: false),
                    roomNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hotelRooms", x => new { x.hotelId, x.roomId });
                });

            migrationBuilder.InsertData(
                table: "hotelRooms",
                columns: new[] { "hotelId", "roomId", "petFriendly", "rate", "roomNumber" },
                values: new object[,]
                {
                    { 7, 7, true, 4, 6 },
                    { 8, 8, true, 4, 8 },
                    { 16, 16, false, 4, 7 }
                });
        }
    }
}
