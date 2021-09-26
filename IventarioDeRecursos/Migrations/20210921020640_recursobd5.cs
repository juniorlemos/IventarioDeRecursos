using Microsoft.EntityFrameworkCore.Migrations;

namespace IventarioDeRecursos.Migrations
{
    public partial class recursobd5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movimentacao_Recursos_RecursoDescricao",
                table: "Movimentacao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movimentacao",
                table: "Movimentacao");

            migrationBuilder.DropIndex(
                name: "IX_Movimentacao_RecursoDescricao",
                table: "Movimentacao");

            migrationBuilder.DropColumn(
                name: "MovimentacaoID",
                table: "Movimentacao");

            migrationBuilder.DropColumn(
                name: "RecursoDescricao",
                table: "Movimentacao");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Movimentacao",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movimentacao",
                table: "Movimentacao",
                column: "Descricao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Movimentacao",
                table: "Movimentacao");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Movimentacao",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "MovimentacaoID",
                table: "Movimentacao",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "RecursoDescricao",
                table: "Movimentacao",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movimentacao",
                table: "Movimentacao",
                column: "MovimentacaoID");

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
    }
}
