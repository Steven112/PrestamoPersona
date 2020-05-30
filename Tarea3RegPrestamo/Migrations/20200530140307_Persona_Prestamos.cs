using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tarea3RegPrestamo.Migrations
{
    public partial class Persona_Prestamos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "personas",
                columns: table => new
                {
                    PersonaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Normbre = table.Column<string>(nullable: false),
                    Telofono = table.Column<string>(maxLength: 10, nullable: false),
                    Cedula = table.Column<string>(nullable: false),
                    Direccion = table.Column<string>(nullable: false),
                    FechaNacimiento = table.Column<DateTime>(nullable: false),
                    Balance = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personas", x => x.PersonaId);
                });

            migrationBuilder.CreateTable(
                name: "prestamos",
                columns: table => new
                {
                    PrestamoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FechaPrestamo = table.Column<DateTime>(nullable: false),
                    PersonaId = table.Column<int>(nullable: false),
                    Concepto = table.Column<string>(nullable: false),
                    Monto = table.Column<decimal>(nullable: false),
                    Balances = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prestamos", x => x.PrestamoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "personas");

            migrationBuilder.DropTable(
                name: "prestamos");
        }
    }
}
