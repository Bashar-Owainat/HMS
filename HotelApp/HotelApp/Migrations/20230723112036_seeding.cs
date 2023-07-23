using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelApp.Migrations
{
    /// <inheritdoc />
    public partial class seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "hotelRooms",
                keyColumns: new[] { "hotelId", "roomId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "hotelRooms",
                keyColumns: new[] { "hotelId", "roomId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "hotelRooms",
                keyColumns: new[] { "hotelId", "roomId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "hotels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "hotels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "hotels",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "hotels",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "rooms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "rooms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "rooms",
                keyColumn: "Id",
                keyValue: 3);

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
                values: new object[] { 6, "Jordan", "regency dalas", 5469788, "Amman", "Jordan", "#####" });

            migrationBuilder.InsertData(
                table: "rooms",
                columns: new[] { "Id", "Layout", "Name" },
                values: new object[,]
                {
                    { 5, 3, "pink" },
                    { 6, 3, "red" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { 1, 1, true, 4, 1 },
                    { 1, 2, false, 4, 2 },
                    { 1, 3, true, 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "hotels",
                columns: new[] { "Id", "Country", "Name", "Phone", "city", "state", "streetAddress" },
                values: new object[,]
                {
                    { 1, "Jordan", "Grand haya", 12151620, "Amman", "Jordan", "Gardens" },
                    { 2, "Jordan", "royal", 127890, "Amman", "Jordan", "rainbow" },
                    { 3, "Jordan", "4 seasons", 32456848, "Amman", "Jordan", "al madinah" },
                    { 4, "Jordan", "regency", 5469788, "Amman", "Jordan", "#####" }
                });

            migrationBuilder.InsertData(
                table: "rooms",
                columns: new[] { "Id", "Layout", "Name" },
                values: new object[,]
                {
                    { 1, 1, "red" },
                    { 2, 2, "blue" },
                    { 3, 3, "pink" }
                });
        }
    }
}
