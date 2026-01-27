using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace obras_mvc_ef.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artistas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artistas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exposiciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exposiciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Obras",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Estilo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UrlImagen = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ArtistaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Obras_Artistas_ArtistaId",
                        column: x => x.ArtistaId,
                        principalTable: "Artistas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ExposicionObras",
                columns: table => new
                {
                    ExposicionesObrasId = table.Column<int>(type: "int", nullable: false),
                    ObrasExpuestasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExposicionObras", x => new { x.ExposicionesObrasId, x.ObrasExpuestasId });
                    table.ForeignKey(
                        name: "FK_ExposicionObras_Exposiciones_ExposicionesObrasId",
                        column: x => x.ExposicionesObrasId,
                        principalTable: "Exposiciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExposicionObras_Obras_ObrasExpuestasId",
                        column: x => x.ObrasExpuestasId,
                        principalTable: "Obras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Exposiciones",
                columns: new[] { "Id", "FechaFin", "FechaInicio", "Nombre" },
                values: new object[] { 1, new DateTime(2025, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Expo especial" });

            migrationBuilder.CreateIndex(
                name: "IX_ExposicionObras_ObrasExpuestasId",
                table: "ExposicionObras",
                column: "ObrasExpuestasId");

            migrationBuilder.CreateIndex(
                name: "IX_Obras_ArtistaId",
                table: "Obras",
                column: "ArtistaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExposicionObras");

            migrationBuilder.DropTable(
                name: "Exposiciones");

            migrationBuilder.DropTable(
                name: "Obras");

            migrationBuilder.DropTable(
                name: "Artistas");
        }
    }
}
