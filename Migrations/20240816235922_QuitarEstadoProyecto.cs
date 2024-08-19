using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArquiVision.Migrations
{
    public partial class QuitarEstadoProyecto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actividades_Cat_EstadoProyecto_IdEstadoProyecto",
                table: "Actividades");

            migrationBuilder.DropIndex(
                name: "IX_Actividades_IdEstadoProyecto",
                table: "Actividades");

            migrationBuilder.DropColumn(
                name: "IdEstadoProyecto",
                table: "Actividades");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdEstadoProyecto",
                table: "Actividades",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Actividades_IdEstadoProyecto",
                table: "Actividades",
                column: "IdEstadoProyecto");

            migrationBuilder.AddForeignKey(
                name: "FK_Actividades_Cat_EstadoProyecto_IdEstadoProyecto",
                table: "Actividades",
                column: "IdEstadoProyecto",
                principalTable: "Cat_EstadoProyecto",
                principalColumn: "IdEstadoProyecto",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
