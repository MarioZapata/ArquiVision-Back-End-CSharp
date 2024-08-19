using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArquiVision.Migrations
{
    public partial class ClaveF2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actividades_Documento_IdDocumento",
                table: "Actividades");

            migrationBuilder.AlterColumn<int>(
                name: "IdDocumento",
                table: "Actividades",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "IdEstadoActividad",
                table: "Actividades",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Actividades_IdEstadoActividad",
                table: "Actividades",
                column: "IdEstadoActividad");

            migrationBuilder.AddForeignKey(
                name: "FK_Actividades_Cat_EstadoActividad_IdEstadoActividad",
                table: "Actividades",
                column: "IdEstadoActividad",
                principalTable: "Cat_EstadoActividad",
                principalColumn: "IdEstadoActividad",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Actividades_Documento_IdDocumento",
                table: "Actividades",
                column: "IdDocumento",
                principalTable: "Documento",
                principalColumn: "IdDocumento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actividades_Cat_EstadoActividad_IdEstadoActividad",
                table: "Actividades");

            migrationBuilder.DropForeignKey(
                name: "FK_Actividades_Documento_IdDocumento",
                table: "Actividades");

            migrationBuilder.DropIndex(
                name: "IX_Actividades_IdEstadoActividad",
                table: "Actividades");

            migrationBuilder.DropColumn(
                name: "IdEstadoActividad",
                table: "Actividades");

            migrationBuilder.AlterColumn<int>(
                name: "IdDocumento",
                table: "Actividades",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Actividades_Documento_IdDocumento",
                table: "Actividades",
                column: "IdDocumento",
                principalTable: "Documento",
                principalColumn: "IdDocumento",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
