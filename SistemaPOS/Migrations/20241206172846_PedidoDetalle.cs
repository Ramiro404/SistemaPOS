using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaPOS.Migrations
{
    /// <inheritdoc />
    public partial class PedidoDetalle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cantidad",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "ProductoId",
                table: "Pedidos");

            migrationBuilder.AddColumn<int>(
                name: "FacturaId",
                table: "Pedidos",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FacturaId",
                table: "Pedidos");

            migrationBuilder.AddColumn<int>(
                name: "Cantidad",
                table: "Pedidos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductoId",
                table: "Pedidos",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
