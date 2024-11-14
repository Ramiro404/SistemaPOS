using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaPOS.Migrations
{
    /// <inheritdoc />
    public partial class PedidoCantidad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cantidad",
                table: "Pedidos",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cantidad",
                table: "Pedidos");
        }
    }
}
