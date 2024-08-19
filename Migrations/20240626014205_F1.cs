using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArquiVision.Migrations
{
    public partial class F1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actividades_Pedidos_IdPedido",
                table: "Actividades");

            migrationBuilder.AlterColumn<int>(
                name: "IdPedido",
                table: "Actividades",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Actividades_Pedidos_IdPedido",
                table: "Actividades",
                column: "IdPedido",
                principalTable: "Pedidos",
                principalColumn: "IdPedido");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actividades_Pedidos_IdPedido",
                table: "Actividades");

            migrationBuilder.AlterColumn<int>(
                name: "IdPedido",
                table: "Actividades",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Actividades_Pedidos_IdPedido",
                table: "Actividades",
                column: "IdPedido",
                principalTable: "Pedidos",
                principalColumn: "IdPedido",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
