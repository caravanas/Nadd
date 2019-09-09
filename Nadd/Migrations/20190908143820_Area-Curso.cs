using Microsoft.EntityFrameworkCore.Migrations;

namespace Nadd.Migrations
{
    public partial class AreaCurso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AreaID",
                table: "Curso",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Curso_AreaID",
                table: "Curso",
                column: "AreaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Curso_Area_AreaID",
                table: "Curso",
                column: "AreaID",
                principalTable: "Area",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Curso_Area_AreaID",
                table: "Curso");

            migrationBuilder.DropIndex(
                name: "IX_Curso_AreaID",
                table: "Curso");

            migrationBuilder.DropColumn(
                name: "AreaID",
                table: "Curso");
        }
    }
}
