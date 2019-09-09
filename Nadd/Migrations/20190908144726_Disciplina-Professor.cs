using Microsoft.EntityFrameworkCore.Migrations;

namespace Nadd.Migrations
{
    public partial class DisciplinaProfessor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfessorID",
                table: "Disciplina",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Disciplina_ProfessorID",
                table: "Disciplina",
                column: "ProfessorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplina_Professor_ProfessorID",
                table: "Disciplina",
                column: "ProfessorID",
                principalTable: "Professor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disciplina_Professor_ProfessorID",
                table: "Disciplina");

            migrationBuilder.DropIndex(
                name: "IX_Disciplina_ProfessorID",
                table: "Disciplina");

            migrationBuilder.DropColumn(
                name: "ProfessorID",
                table: "Disciplina");
        }
    }
}
