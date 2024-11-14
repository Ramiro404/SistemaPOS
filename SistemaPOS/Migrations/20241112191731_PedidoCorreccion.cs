using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaPOS.Migrations
{
    /// <inheritdoc />
    public partial class PedidoCorreccion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Pedidos_PedidoId",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_PedidoId",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "PedidoId",
                table: "Productos");

            migrationBuilder.AddColumn<bool>(
                name: "Eliminado",
                table: "Pedidos",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ProductoId",
                table: "Pedidos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ProductoId",
                table: "Pedidos",
                column: "ProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Productos_ProductoId",
                table: "Pedidos",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Productos_ProductoId",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_ProductoId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Eliminado",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "ProductoId",
                table: "Pedidos");

            migrationBuilder.AddColumn<int>(
                name: "PedidoId",
                table: "Productos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Productos_PedidoId",
                table: "Productos",
                column: "PedidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Pedidos_PedidoId",
                table: "Productos",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
