using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArquiVision.Migrations
{
    public partial class misPedidos1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Documento_IdDocumento",
                table: "Pedidos");

            migrationBuilder.AlterColumn<string>(
                name: "MétodoDeEnvío",
                table: "Pedidos",
                type: "character varying(35)",
                maxLength: 35,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(35)",
                oldMaxLength: 35,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdDocumento",
                table: "Pedidos",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<decimal>(
                name: "CostoRegreso",
                table: "Pedidos",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Documento_IdDocumento",
                table: "Pedidos",
                column: "IdDocumento",
                principalTable: "Documento",
                principalColumn: "IdDocumento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Documento_IdDocumento",
                table: "Pedidos");

            migrationBuilder.AlterColumn<string>(
                name: "MétodoDeEnvío",
                table: "Pedidos",
                type: "character varying(35)",
                maxLength: 35,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(35)",
                oldMaxLength: 35);

            migrationBuilder.AlterColumn<int>(
                name: "IdDocumento",
                table: "Pedidos",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "CostoRegreso",
                table: "Pedidos",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Documento_IdDocumento",
                table: "Pedidos",
                column: "IdDocumento",
                principalTable: "Documento",
                principalColumn: "IdDocumento",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
