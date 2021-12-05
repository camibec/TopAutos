using Microsoft.EntityFrameworkCore.Migrations;

namespace TopAutos.Migrations
{
    public partial class TopAutosContextTopAutosDatabaseContext3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehiculoFavUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehiculoFavUsuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
                    VehiculoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiculoFavUsuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehiculoFavUsuario_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VehiculoFavUsuario_Vehiculos_VehiculoId",
                        column: x => x.VehiculoId,
                        principalTable: "Vehiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehiculoFavUsuario_UsuarioId",
                table: "VehiculoFavUsuario",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiculoFavUsuario_VehiculoId",
                table: "VehiculoFavUsuario",
                column: "VehiculoId");
        }
    }
}
