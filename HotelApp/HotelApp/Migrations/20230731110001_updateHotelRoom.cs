using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelApp.Migrations
{
    /// <inheritdoc />
    public partial class updateHotelRoom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PetFriendly",
                table: "HotelRooms",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Rate",
                table: "HotelRooms",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "RoomNumber",
                table: "HotelRooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelId", "RoomId" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "PetFriendly", "Rate", "RoomNumber" },
                values: new object[] { true, 3m, 111 });

            migrationBuilder.UpdateData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelId", "RoomId" },
                keyValues: new object[] { 1, 2 },
                columns: new[] { "PetFriendly", "Rate", "RoomNumber" },
                values: new object[] { false, 4m, 222 });

            migrationBuilder.UpdateData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelId", "RoomId" },
                keyValues: new object[] { 2, 3 },
                columns: new[] { "PetFriendly", "Rate", "RoomNumber" },
                values: new object[] { true, 5m, 333 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PetFriendly",
                table: "HotelRooms");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "HotelRooms");

            migrationBuilder.DropColumn(
                name: "RoomNumber",
                table: "HotelRooms");
        }
    }
}
