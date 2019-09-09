using Microsoft.EntityFrameworkCore.Migrations;

namespace Nadd.Migrations
{
    public partial class AvaliacaoDisciplina : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DisciplinaId",
                table: "Avaliacao",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacao_DisciplinaId",
                table: "Avaliacao",
                column: "DisciplinaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacao_Disciplina_DisciplinaId",
                table: "Avaliacao",
                column: "DisciplinaId",
                principalTable: "Disciplina",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacao_Disciplina_DisciplinaId",
                table: "Avaliacao");

            migrationBuilder.DropIndex(
                name: "IX_Avaliacao_DisciplinaId",
                table: "Avaliacao");

            migrationBuilder.DropColumn(
                name: "DisciplinaId",
                table: "Avaliacao");
        }
    }
}
