using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Controle_Financeiro.Migrations
{
    public partial class Descricao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descrição",
                table: "Despesas",
                newName: "Descricao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Despesas",
                newName: "Descrição");
        }
    }
}
