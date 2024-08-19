using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArquiVision.Migrations
{
    public partial class PedidosSinDocumneto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Documento_IdDocumento",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_IdDocumento",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "IdDocumento",
                table: "Pedidos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdDocumento",
                table: "Pedidos",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_IdDocumento",
                table: "Pedidos",
                column: "IdDocumento");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Documento_IdDocumento",
                table: "Pedidos",
                column: "IdDocumento",
                principalTable: "Documento",
                principalColumn: "IdDocumento");
        }
    }
}
