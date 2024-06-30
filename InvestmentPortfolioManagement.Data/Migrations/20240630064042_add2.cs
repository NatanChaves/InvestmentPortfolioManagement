using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InvestmentPortfolioManagement.Data.Migrations
{
    public partial class add2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FundosImobiliarios",
                columns: table => new
                {
                    FundoImobiliarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeFundo = table.Column<string>(nullable: true),
                    CodigoNegociacao = table.Column<int>(nullable: false),
                    CorretoraExcutora = table.Column<int>(nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundosImobiliarios", x => x.FundoImobiliarioId);
                });

            migrationBuilder.CreateTable(
                name: "Investimentos",
                columns: table => new
                {
                    InvestimentoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataOperacao = table.Column<DateTime>(nullable: false),
                    DataVencimento = table.Column<DateTime>(nullable: false),
                    CodigoCliente = table.Column<int>(nullable: false),
                    CorretoraExcutora = table.Column<int>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    TipoOperacao = table.Column<string>(nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrecoTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NomeFundo = table.Column<string>(nullable: true),
                    FundoImobiliarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investimentos", x => x.InvestimentoId);
                    table.ForeignKey(
                        name: "FK_Investimentos_FundosImobiliarios_FundoImobiliarioId",
                        column: x => x.FundoImobiliarioId,
                        principalTable: "FundosImobiliarios",
                        principalColumn: "FundoImobiliarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Investimentos_FundoImobiliarioId",
                table: "Investimentos",
                column: "FundoImobiliarioId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Investimentos");

            migrationBuilder.DropTable(
                name: "FundosImobiliarios");
        }
    }
}
