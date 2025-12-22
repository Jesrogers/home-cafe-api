using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HomeCafeApi.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "menu_items",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    price = table.Column<decimal>(type: "numeric", nullable: true),
                    allow_decaf_option = table.Column<bool>(type: "boolean", nullable: false),
                    allow_sugar_option = table.Column<bool>(type: "boolean", nullable: false),
                    is_item_out_of_stock = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menu_items", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    menu_item_id = table.Column<long>(type: "bigint", nullable: false),
                    customer_name = table.Column<string>(type: "text", nullable: false),
                    sweetener = table.Column<string>(type: "text", nullable: true),
                    special_requests = table.Column<string>(type: "text", nullable: true),
                    status = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.id);
                    table.ForeignKey(
                        name: "FK_orders_menu_items_menu_item_id",
                        column: x => x.menu_item_id,
                        principalTable: "menu_items",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "menu_items",
                columns: new[] { "id", "allow_decaf_option", "allow_sugar_option", "description", "is_item_out_of_stock", "name", "price" },
                values: new object[,]
                {
                    { 1L, true, true, "espresso, steamed milk", false, "Cafe Latte", null },
                    { 2L, true, true, "espresso, milk, ice", false, "Iced Cafe Latte", null },
                    { 3L, true, true, "espresso, water, ice", false, "Iced Americano", null },
                    { 4L, true, true, "espresso, hot water", false, "Americano", null },
                    { 5L, false, true, "matcha, steamed milk", false, "Matcha Latte", null },
                    { 6L, false, true, "matcha, milk, ice", false, "Iced Matcha Latte", null },
                    { 7L, false, true, "hojicha, steamed milk", false, "Hojicha Latte", null },
                    { 8L, false, true, "hojicha, milk, ice", false, "Iced Hojicha Latte", null },
                    { 9L, false, false, "hot chocolate mix, steamed milk", false, "Hot Chocolate", null },
                    { 10L, false, true, "please ask JP for current tea selection", false, "Tea", null },
                    { 11L, true, false, "espresso, milk, ice, pumpkin syrup, whipped cream", false, "Iced Pumpkin Spice Latte (seasonal)", null },
                    { 12L, true, false, "espresso, milk, ice, chocolate sauce, peppermint flavor, whipped cream, candy cane topping", false, "Iced Peppermint Mocha (seasonal)", null },
                    { 13L, true, false, "jasmine tea, milk, ice", false, "Iced Jasmine Latte", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_orders_menu_item_id",
                table: "orders",
                column: "menu_item_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "menu_items");
        }
    }
}
