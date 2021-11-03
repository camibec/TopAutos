using Microsoft.EntityFrameworkCore.Migrations;

namespace TopAutos.Migrations
{
    public partial class TopAutosContextTopAutosDatabaseContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Clave = table.Column<string>(nullable: true),
                    Rol = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modelo = table.Column<string>(nullable: true),
                    Marca = table.Column<string>(nullable: true),
                    Ano = table.Column<int>(nullable: false),
                    CantPuertas = table.Column<int>(nullable: false),
                    Precio = table.Column<double>(nullable: false),
                    VieneAutomatico = table.Column<bool>(nullable: false),
                    Tipo = table.Column<int>(nullable: false),
                    Voto = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehiculoFavUsuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(nullable: true),
                    VehiculoId = table.Column<int>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "VotosUsuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(nullable: true),
                    VehiculoId = table.Column<int>(nullable: true),
                    Voto = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VotosUsuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VotosUsuario_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VotosUsuario_Vehiculos_VehiculoId",
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

            migrationBuilder.CreateIndex(
                name: "IX_VotosUsuario_UsuarioId",
                table: "VotosUsuario",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_VotosUsuario_VehiculoId",
                table: "VotosUsuario",
                column: "VehiculoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehiculoFavUsuario");

            migrationBuilder.DropTable(
                name: "VotosUsuario");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Vehiculos");
        }
    }
}
