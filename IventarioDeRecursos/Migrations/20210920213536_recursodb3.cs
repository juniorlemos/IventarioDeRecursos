using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IventarioDeRecursos.Migrations
{
    public partial class recursodb3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Recursos",
                table: "Recursos");

            migrationBuilder.DropColumn(
                name: "RecursoID",
                table: "Recursos");

            migrationBuilder.DropColumn(
                name: "Entrada",
                table: "Recursos");

            migrationBuilder.DropColumn(
                name: "Recursoid",
                table: "Movimentacao");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Recursos",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecursoDescricao",
                table: "Movimentacao",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recursos",
                table: "Recursos",
                column: "Descricao");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacao_RecursoDescricao",
                table: "Movimentacao",
                column: "RecursoDescricao");

            migrationBuilder.AddForeignKey(
                name: "FK_Movimentacao_Recursos_RecursoDescricao",
                table: "Movimentacao",
                column: "RecursoDescricao",
                principalTable: "Recursos",
                principalColumn: "Descricao",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movimentacao_Recursos_RecursoDescricao",
                table: "Movimentacao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recursos",
                table: "Recursos");

            migrationBuilder.DropIndex(
                name: "IX_Movimentacao_RecursoDescricao",
                table: "Movimentacao");

            migrationBuilder.DropColumn(
                name: "RecursoDescricao",
                table: "Movimentacao");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Recursos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "RecursoID",
                table: "Recursos",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "Entrada",
                table: "Recursos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Recursoid",
                table: "Movimentacao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recursos",
                table: "Recursos",
                column: "RecursoID");
        }
    }
}
