using Microsoft.EntityFrameworkCore.Migrations;

namespace Nadd.Migrations
{
    public partial class CorrecoesTipoDado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Professor",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Professor",
                newName: "ID");
        }
    }
}
