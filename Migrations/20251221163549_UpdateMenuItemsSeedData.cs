using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HomeCafeApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMenuItemsSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "menu_items",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "description", "name", "price" },
                values: new object[] { "espresso, steamed milk", "Cafe Latte", null });

            migrationBuilder.UpdateData(
                table: "menu_items",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "description", "name", "price" },
                values: new object[] { "espresso, milk, ice", "Iced Cafe Latte", null });

            migrationBuilder.UpdateData(
                table: "menu_items",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "description", "name", "price" },
                values: new object[] { "espresso, water, ice", "Iced Americano", null });

            migrationBuilder.UpdateData(
                table: "menu_items",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "description", "name", "price" },
                values: new object[] { "espresso, hot water", "Americano", null });

            migrationBuilder.UpdateData(
                table: "menu_items",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "description", "price" },
                values: new object[] { "matcha, steamed milk", null });

            migrationBuilder.InsertData(
                table: "menu_items",
                columns: new[] { "id", "description", "name", "price" },
                values: new object[,]
                {
                    { 6L, "matcha, milk, ice", "Iced Matcha Latte", null },
                    { 7L, "hojicha, steamed milk", "Hojicha Latte", null },
                    { 8L, "hojicha, milk, ice", "Iced Hojicha Latte", null },
                    { 9L, "hot chocolate mix, steamed milk", "Hot Chocolate", null },
                    { 10L, "please ask JP for current tea selection", "Tea", null },
                    { 11L, "espresso, milk, ice, pumpkin syrup, whipped cream", "Iced Pumpkin Spice Latte (seasonal)", null },
                    { 12L, "espresso, milk, ice, chocolate sauce, peppermint flavor, whipped cream, candy cane topping", "Iced Peppermint Mocha (seasonal)", null },
                    { 13L, "jasmine tea, milk, ice", "Iced Jasmine Latte", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "menu_items",
                keyColumn: "id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "menu_items",
                keyColumn: "id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "menu_items",
                keyColumn: "id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "menu_items",
                keyColumn: "id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "menu_items",
                keyColumn: "id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "menu_items",
                keyColumn: "id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "menu_items",
                keyColumn: "id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "menu_items",
                keyColumn: "id",
                keyValue: 13L);

            migrationBuilder.UpdateData(
                table: "menu_items",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "description", "name", "price" },
                values: new object[] { "Rich espresso with steamed milk foam", "Cappuccino", 4.5m });

            migrationBuilder.UpdateData(
                table: "menu_items",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "description", "name", "price" },
                values: new object[] { "Smooth espresso with creamy milk", "Latte", 4.0m });

            migrationBuilder.UpdateData(
                table: "menu_items",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "description", "name", "price" },
                values: new object[] { "Chocolate espresso delight", "Mocha", 4.75m });

            migrationBuilder.UpdateData(
                table: "menu_items",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "description", "name", "price" },
                values: new object[] { "Spiced tea with steamed milk", "Chai Latte", 4.25m });

            migrationBuilder.UpdateData(
                table: "menu_items",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "description", "price" },
                values: new object[] { "Creamy green tea latte", 4.50m });
        }
    }
}
