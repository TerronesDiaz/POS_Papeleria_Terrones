using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace POSPapeleriaTerrones.Server.Migrations
{
    public partial class EntradasSalidas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entradas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nota = table.Column<string>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    ArticuloId = table.Column<int>(nullable: false),
                    Articulo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entradas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Salidas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nota = table.Column<string>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    ArticuloId = table.Column<int>(nullable: false),
                    Articulo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salidas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entradas");

            migrationBuilder.DropTable(
                name: "Salidas");
        }
    }
}
