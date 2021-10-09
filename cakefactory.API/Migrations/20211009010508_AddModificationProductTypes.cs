using Microsoft.EntityFrameworkCore.Migrations;

namespace cakefactory.API.Migrations
{
    public partial class AddModificationProductTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProdcutTypes",
                table: "ProdcutTypes");

            migrationBuilder.RenameTable(
                name: "ProdcutTypes",
                newName: "ProductTypes");

            migrationBuilder.RenameIndex(
                name: "IX_ProdcutTypes_Description",
                table: "ProductTypes",
                newName: "IX_ProductTypes_Description");

            migrationBuilder.AddColumn<string>(
                name: "PersoName",
                table: "Personalizations",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductTypes",
                table: "ProductTypes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Personalizations_PersoName",
                table: "Personalizations",
                column: "PersoName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Personalizations_PersoName",
                table: "Personalizations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductTypes",
                table: "ProductTypes");

            migrationBuilder.DropColumn(
                name: "PersoName",
                table: "Personalizations");

            migrationBuilder.RenameTable(
                name: "ProductTypes",
                newName: "ProdcutTypes");

            migrationBuilder.RenameIndex(
                name: "IX_ProductTypes_Description",
                table: "ProdcutTypes",
                newName: "IX_ProdcutTypes_Description");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProdcutTypes",
                table: "ProdcutTypes",
                column: "Id");
        }
    }
}
