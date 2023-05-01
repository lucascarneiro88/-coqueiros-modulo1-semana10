using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Semana10Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CARROS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataLocacao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CARROS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MARCAS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MarcaModel = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MARCAS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MARCAS_CARROS_MarcaModel",
                        column: x => x.MarcaModel,
                        principalTable: "CARROS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MARCAS_MarcaModel",
                table: "MARCAS",
                column: "MarcaModel");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MARCAS");

            migrationBuilder.DropTable(
                name: "CARROS");
        }
    }
}
