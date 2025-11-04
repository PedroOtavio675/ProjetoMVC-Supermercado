using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudMVC.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarColunaEstoqueAProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "estoque",
                table: "Produto",
                newName: "Estoque");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Estoque",
                table: "Produto",
                newName: "estoque");
        }
    }
}
