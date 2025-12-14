using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeCafeApi.Migrations
{
    /// <inheritdoc />
    public partial class ChangeOrderModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .OldAnnotation("Npgsql:Enum:order_status", "in_progress,complete")
                .OldAnnotation("Npgsql:Enum:sweetener", "none,maple_syrup,pumpkin_spice");

            migrationBuilder.AlterColumn<string>(
                name: "sweetener",
                table: "orders",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "orders",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:order_status", "in_progress,complete")
                .Annotation("Npgsql:Enum:sweetener", "none,maple_syrup,pumpkin_spice");

            migrationBuilder.AlterColumn<int>(
                name: "sweetener",
                table: "orders",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "status",
                table: "orders",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
