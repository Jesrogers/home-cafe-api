using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeCafeApi.Migrations
{
    /// <inheritdoc />
    public partial class AddImageUrlAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "image_url",
                table: "menu_items",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "menu_items",
                keyColumn: "id",
                keyValue: 1L,
                column: "image_url",
                value: null);

            migrationBuilder.UpdateData(
                table: "menu_items",
                keyColumn: "id",
                keyValue: 2L,
                column: "image_url",
                value: null);

            migrationBuilder.UpdateData(
                table: "menu_items",
                keyColumn: "id",
                keyValue: 3L,
                column: "image_url",
                value: null);

            migrationBuilder.UpdateData(
                table: "menu_items",
                keyColumn: "id",
                keyValue: 4L,
                column: "image_url",
                value: null);

            migrationBuilder.UpdateData(
                table: "menu_items",
                keyColumn: "id",
                keyValue: 5L,
                column: "image_url",
                value: null);

            migrationBuilder.UpdateData(
                table: "menu_items",
                keyColumn: "id",
                keyValue: 6L,
                column: "image_url",
                value: null);

            migrationBuilder.UpdateData(
                table: "menu_items",
                keyColumn: "id",
                keyValue: 7L,
                column: "image_url",
                value: null);

            migrationBuilder.UpdateData(
                table: "menu_items",
                keyColumn: "id",
                keyValue: 8L,
                column: "image_url",
                value: null);

            migrationBuilder.UpdateData(
                table: "menu_items",
                keyColumn: "id",
                keyValue: 9L,
                column: "image_url",
                value: null);

            migrationBuilder.UpdateData(
                table: "menu_items",
                keyColumn: "id",
                keyValue: 10L,
                column: "image_url",
                value: null);

            migrationBuilder.UpdateData(
                table: "menu_items",
                keyColumn: "id",
                keyValue: 11L,
                column: "image_url",
                value: null);

            migrationBuilder.UpdateData(
                table: "menu_items",
                keyColumn: "id",
                keyValue: 12L,
                column: "image_url",
                value: null);

            migrationBuilder.UpdateData(
                table: "menu_items",
                keyColumn: "id",
                keyValue: 13L,
                column: "image_url",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "image_url",
                table: "menu_items");
        }
    }
}
