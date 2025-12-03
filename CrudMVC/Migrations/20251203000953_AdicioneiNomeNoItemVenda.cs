using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudMVC.Migrations
{
    /// <inheritdoc />
    public partial class AdicioneiNomeNoItemVenda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "ItemVenda",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "ItemVenda");
        }
    }
}
