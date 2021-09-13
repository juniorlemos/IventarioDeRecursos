using Microsoft.EntityFrameworkCore.Migrations;

namespace IventarioDeRecursos.Migrations
{
    public partial class RecursosDB2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente");

            migrationBuilder.RenameTable(
                name: "Cliente",
                newName: "Recursos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recursos",
                table: "Recursos",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Recursos",
                table: "Recursos");

            migrationBuilder.RenameTable(
                name: "Recursos",
                newName: "Cliente");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente",
                column: "Id");
        }
    }
}
