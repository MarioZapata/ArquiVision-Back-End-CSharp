using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArquiVision.Migrations
{
    public partial class idPedidRes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductoVentas_Pedidos_Id_Pedido",
                table: "ProductoVentas");

            migrationBuilder.RenameColumn(
                name: "Id_Pedido",
                table: "ProductoVentas",
                newName: "IdPedido");

            migrationBuilder.RenameIndex(
                name: "IX_ProductoVentas_Id_Pedido",
                table: "ProductoVentas",
                newName: "IX_ProductoVentas_IdPedido");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductoVentas_Pedidos_IdPedido",
                table: "ProductoVentas",
                column: "IdPedido",
                principalTable: "Pedidos",
                principalColumn: "IdPedido",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductoVentas_Pedidos_IdPedido",
                table: "ProductoVentas");

            migrationBuilder.RenameColumn(
                name: "IdPedido",
                table: "ProductoVentas",
                newName: "Id_Pedido");

            migrationBuilder.RenameIndex(
                name: "IX_ProductoVentas_IdPedido",
                table: "ProductoVentas",
                newName: "IX_ProductoVentas_Id_Pedido");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductoVentas_Pedidos_Id_Pedido",
                table: "ProductoVentas",
                column: "Id_Pedido",
                principalTable: "Pedidos",
                principalColumn: "IdPedido",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
