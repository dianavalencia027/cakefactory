using Microsoft.EntityFrameworkCore.Migrations;

namespace cakefactory.API.Migrations
{
    public partial class AddTableProductType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProdcutTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdcutTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProdcutTypes_Description",
                table: "ProdcutTypes",
                column: "Description",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdcutTypes");
        }
    }
}
