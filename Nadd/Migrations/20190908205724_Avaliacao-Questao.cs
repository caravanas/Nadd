using Microsoft.EntityFrameworkCore.Migrations;

namespace Nadd.Migrations
{
    public partial class AvaliacaoQuestao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AvaliacaoId",
                table: "Questao",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Questao_AvaliacaoId",
                table: "Questao",
                column: "AvaliacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questao_Avaliacao_AvaliacaoId",
                table: "Questao",
                column: "AvaliacaoId",
                principalTable: "Avaliacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questao_Avaliacao_AvaliacaoId",
                table: "Questao");

            migrationBuilder.DropIndex(
                name: "IX_Questao_AvaliacaoId",
                table: "Questao");

            migrationBuilder.DropColumn(
                name: "AvaliacaoId",
                table: "Questao");
        }
    }
}
