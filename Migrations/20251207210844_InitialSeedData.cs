using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HomeCafeApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "menu_items",
                columns: new[] { "id", "description", "name", "price" },
                values: new object[,]
                {
                    { 1L, "Rich espresso with steamed milk foam", "Cappuccino", 4.5m },
                    { 2L, "Smooth espresso with creamy milk", "Latte", 4.0m },
                    { 3L, "Chocolate espresso delight", "Mocha", 4.75m },
                    { 4L, "Spiced tea with steamed milk", "Chai Latte", 4.25m },
                    { 5L, "Creamy green tea latte", "Matcha Latte", 4.50m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "menu_items",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "menu_items",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "menu_items",
                keyColumn: "id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "menu_items",
                keyColumn: "id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "menu_items",
                keyColumn: "id",
                keyValue: 5L);
        }
    }
}
