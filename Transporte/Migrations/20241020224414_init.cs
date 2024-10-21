using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Transporte.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conteiners",
                columns: table => new
                {
                    Numero = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Cliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<short>(type: "smallint", nullable: false),
                    Status = table.Column<short>(type: "smallint", nullable: false),
                    Categoria = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conteiners", x => x.Numero);
                });

            migrationBuilder.CreateTable(
                name: "Movimentacaos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroConteiner = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tipo = table.Column<short>(type: "smallint", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimentacaos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movimentacaos_Conteiners_NumeroConteiner",
                        column: x => x.NumeroConteiner,
                        principalTable: "Conteiners",
                        principalColumn: "Numero",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacaos_NumeroConteiner",
                table: "Movimentacaos",
                column: "NumeroConteiner");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movimentacaos");

            migrationBuilder.DropTable(
                name: "Conteiners");
        }
    }
}
