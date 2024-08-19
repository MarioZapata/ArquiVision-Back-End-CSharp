using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArquiVision.Migrations
{
    public partial class idPrDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id_ProductoVenta",
                table: "ProductoVentas",
                newName: "IdProductoVenta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdProductoVenta",
                table: "ProductoVentas",
                newName: "Id_ProductoVenta");
        }
    }
}
