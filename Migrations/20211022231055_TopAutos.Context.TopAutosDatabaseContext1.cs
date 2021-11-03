using Microsoft.EntityFrameworkCore.Migrations;

namespace TopAutos.Migrations
{
    public partial class TopAutosContextTopAutosDatabaseContext1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Imagen",
                table: "Vehiculos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagen",
                table: "Vehiculos");
        }
    }
}
