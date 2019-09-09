using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nadd.Migrations
{
    public partial class Avaliacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Avaliacao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataInicioAvaliacao = table.Column<DateTime>(nullable: false),
                    DataConclusaoAvaliacao = table.Column<DateTime>(nullable: false),
                    ValorProvaExplicito = table.Column<int>(nullable: false),
                    ValorQuestaoExplicito = table.Column<int>(nullable: false),
                    SomatorioValoresQuestoes = table.Column<int>(nullable: false),
                    ReferenciasBibliograficas = table.Column<int>(nullable: false),
                    MultiplaEscolhaDiscursiva = table.Column<int>(nullable: false),
                    ValorTotalProva = table.Column<int>(nullable: false),
                    NumeroQuestoes = table.Column<int>(nullable: false),
                    EquilibrioDistruibacaoValorQuestao = table.Column<int>(nullable: false),
                    Diversificacao = table.Column<int>(nullable: false),
                    QuestaoContextualizada = table.Column<int>(nullable: false),
                    Observacoes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacao", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Avaliacao");
        }
    }
}
