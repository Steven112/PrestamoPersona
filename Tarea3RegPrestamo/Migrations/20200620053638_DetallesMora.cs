using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tarea3RegPrestamo.Migrations
{
    public partial class DetallesMora : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "moras",
                columns: table => new
                {
                    MoraId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Total = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_moras", x => x.MoraId);
                });

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

            migrationBuilder.CreateTable(
                name: "MoraDetalle",
                columns: table => new
                {
                    DetalleId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MoraId = table.Column<int>(nullable: false),
                    PrestamoId = table.Column<int>(nullable: false),
                    PrestamosId = table.Column<int>(nullable: true),
                    Valor = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoraDetalle", x => x.DetalleId);
                    table.ForeignKey(
                        name: "FK_MoraDetalle_moras_MoraId",
                        column: x => x.MoraId,
                        principalTable: "moras",
                        principalColumn: "MoraId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoraDetalle_prestamos_PrestamosId",
                        column: x => x.PrestamosId,
                        principalTable: "prestamos",
                        principalColumn: "PrestamoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MoraDetalle_MoraId",
                table: "MoraDetalle",
                column: "MoraId");

            migrationBuilder.CreateIndex(
                name: "IX_MoraDetalle_PrestamosId",
                table: "MoraDetalle",
                column: "PrestamosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MoraDetalle");

            migrationBuilder.DropTable(
                name: "personas");

            migrationBuilder.DropTable(
                name: "moras");

            migrationBuilder.DropTable(
                name: "prestamos");
        }
    }
}
