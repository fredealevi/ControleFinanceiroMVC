using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Controle_Financeiro.Migrations
{
    public partial class CriadoTotal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "Receitas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total",
                table: "Receitas");
        }
    }
}
