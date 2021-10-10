using Microsoft.EntityFrameworkCore.Migrations;

namespace cakefactory.API.Migrations
{
    public partial class AddUserTables3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Personalizations");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Personalizations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Personalizations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Personalizations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
