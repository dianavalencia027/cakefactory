using Microsoft.EntityFrameworkCore.Migrations;

namespace cakefactory.API.Migrations
{
    public partial class AddUserTables2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PersoName",
                table: "Personalizations",
                newName: "Description");

            migrationBuilder.RenameIndex(
                name: "IX_Personalizations_PersoName",
                table: "Personalizations",
                newName: "IX_Personalizations_Description");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Personalizations",
                newName: "PersoName");

            migrationBuilder.RenameIndex(
                name: "IX_Personalizations_Description",
                table: "Personalizations",
                newName: "IX_Personalizations_PersoName");
        }
    }
}
