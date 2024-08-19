using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArquiVision.Migrations
{
    public partial class TildesQuitar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MétodoDeEnvío",
                table: "Pedidos",
                newName: "MetodoDeEnvio");

            migrationBuilder.RenameColumn(
                name: "MétodoDeCompra",
                table: "Pedidos",
                newName: "MetodoDeCompra");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MetodoDeEnvio",
                table: "Pedidos",
                newName: "MétodoDeEnvío");

            migrationBuilder.RenameColumn(
                name: "MetodoDeCompra",
                table: "Pedidos",
                newName: "MétodoDeCompra");
        }
    }
}
