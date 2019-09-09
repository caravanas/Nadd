using Microsoft.EntityFrameworkCore.Migrations;

namespace Nadd.Migrations
{
    public partial class DisciplinaCurso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CursoID",
                table: "Disciplina",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Disciplina_CursoID",
                table: "Disciplina",
                column: "CursoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplina_Curso_CursoID",
                table: "Disciplina",
                column: "CursoID",
                principalTable: "Curso",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disciplina_Curso_CursoID",
                table: "Disciplina");

            migrationBuilder.DropIndex(
                name: "IX_Disciplina_CursoID",
                table: "Disciplina");

            migrationBuilder.DropColumn(
                name: "CursoID",
                table: "Disciplina");
        }
    }
}
