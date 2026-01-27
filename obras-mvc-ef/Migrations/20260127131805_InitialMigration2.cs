using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace obras_mvc_ef.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Obras_Artistas_ArtistaId",
                table: "Obras");

            migrationBuilder.RenameColumn(
                name: "ArtistaId",
                table: "Obras",
                newName: "ArtistaID");

            migrationBuilder.RenameIndex(
                name: "IX_Obras_ArtistaId",
                table: "Obras",
                newName: "IX_Obras_ArtistaID");

            migrationBuilder.AlterColumn<Guid>(
                name: "ArtistaID",
                table: "Obras",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Obras_Artistas_ArtistaID",
                table: "Obras",
                column: "ArtistaID",
                principalTable: "Artistas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Obras_Artistas_ArtistaID",
                table: "Obras");

            migrationBuilder.RenameColumn(
                name: "ArtistaID",
                table: "Obras",
                newName: "ArtistaId");

            migrationBuilder.RenameIndex(
                name: "IX_Obras_ArtistaID",
                table: "Obras",
                newName: "IX_Obras_ArtistaId");

            migrationBuilder.AlterColumn<Guid>(
                name: "ArtistaId",
                table: "Obras",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Obras_Artistas_ArtistaId",
                table: "Obras",
                column: "ArtistaId",
                principalTable: "Artistas",
                principalColumn: "Id");
        }
    }
}
