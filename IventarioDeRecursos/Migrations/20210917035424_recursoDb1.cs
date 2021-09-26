using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IventarioDeRecursos.Migrations
{
    public partial class recursoDb1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movimentacao",
                columns: table => new
                {
                    MovimentacaoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Recursoid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeEntradaRecurso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeSaidaRecurso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataEntrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataSaida = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimentacao", x => x.MovimentacaoID);
                });

            migrationBuilder.CreateTable(
                name: "Recursos",
                columns: table => new
                {
                    RecursoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Observacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeResponsavel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Entrada = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recursos", x => x.RecursoID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movimentacao");

            migrationBuilder.DropTable(
                name: "Recursos");
        }
    }
}
