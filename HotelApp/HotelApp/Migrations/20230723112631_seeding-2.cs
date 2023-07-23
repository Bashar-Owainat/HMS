using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelApp.Migrations
{
    /// <inheritdoc />
    public partial class seeding2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "hotelRooms",
                keyColumns: new[] { "hotelId", "roomId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "hotelRooms",
                keyColumns: new[] { "hotelId", "roomId" },
                keyValues: new object[] { 6, 6 });

            migrationBuilder.DeleteData(
                table: "hotels",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "hotels",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "rooms",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "rooms",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.InsertData(
                table: "hotelRooms",
                columns: new[] { "hotelId", "roomId", "petFriendly", "rate", "roomNumber" },
                values: new object[,]
                {
                    { 7, 7, true, 4, 6 },
                    { 8, 8, true, 4, 8 },
                    { 16, 16, false, 4, 7 }
                });

            migrationBuilder.InsertData(
                table: "hotels",
                columns: new[] { "Id", "Country", "Name", "Phone", "city", "state", "streetAddress" },
                values: new object[,]
                {
                    { 7, "Jordan", "marriott", 5469788, "Amman", "Jordan", "#####" },
                    { 8, "Jordan", "grand haya", 5469788, "Amman", "Jordan", "#####" },
                    { 16, "Jordan", "regency dalas", 5469788, "Amman", "Jordan", "#####" }
                });

            migrationBuilder.InsertData(
                table: "rooms",
                columns: new[] { "Id", "Layout", "Name" },
                values: new object[,]
                {
                    { 7, 4, "blue" },
                    { 8, 5, "green" },
                    { 16, 3, "red" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "hotelRooms",
                keyColumns: new[] { "hotelId", "roomId" },
                keyValues: new object[] { 7, 7 });

            migrationBuilder.DeleteData(
                table: "hotelRooms",
                keyColumns: new[] { "hotelId", "roomId" },
                keyValues: new object[] { 8, 8 });

            migrationBuilder.DeleteData(
                table: "hotelRooms",
                keyColumns: new[] { "hotelId", "roomId" },
                keyValues: new object[] { 16, 16 });

            migrationBuilder.DeleteData(
                table: "hotels",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "hotels",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "hotels",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "rooms",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "rooms",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "rooms",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.InsertData(
                table: "hotelRooms",
                columns: new[] { "hotelId", "roomId", "petFriendly", "rate", "roomNumber" },
                values: new object[,]
                {
                    { 5, 5, true, 4, 3 },
                    { 6, 6, false, 4, 4 }
                });

            migrationBuilder.InsertData(
                table: "hotels",
                columns: new[] { "Id", "Country", "Name", "Phone", "city", "state", "streetAddress" },
                values: new object[,]
                {
                    { 5, "Jordan", "regency dalas", 5469788, "Amman", "Jordan", "#####" },
                    { 6, "Jordan", "regency dalas", 5469788, "Amman", "Jordan", "#####" }
                });

            migrationBuilder.InsertData(
                table: "rooms",
                columns: new[] { "Id", "Layout", "Name" },
                values: new object[,]
                {
                    { 5, 3, "pink" },
                    { 6, 3, "red" }
                });
        }
    }
}
