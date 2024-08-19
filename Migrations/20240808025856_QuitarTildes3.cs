using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArquiVision.Migrations
{
    public partial class QuitarTildes3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CostoDeEnvío",
                table: "Pedidos",
                newName: "CostoDeEnvio");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CostoDeEnvio",
                table: "Pedidos",
                newName: "CostoDeEnvío");
        }
    }
}
