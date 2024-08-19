using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArquiVision.Migrations
{
    public partial class Catalgos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proyectos_Cat_TipoConstruccion_Id_TipoConstruccion",
                table: "Proyectos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cat_TipoConstruccion",
                table: "Cat_TipoConstruccion");

            migrationBuilder.RenameTable(
                name: "Cat_TipoConstruccion",
                newName: "Cat_TipoConstruccions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cat_TipoConstruccions",
                table: "Cat_TipoConstruccions",
                column: "IdTipoConstruccion");

            migrationBuilder.AddForeignKey(
                name: "FK_Proyectos_Cat_TipoConstruccions_Id_TipoConstruccion",
                table: "Proyectos",
                column: "Id_TipoConstruccion",
                principalTable: "Cat_TipoConstruccions",
                principalColumn: "IdTipoConstruccion",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proyectos_Cat_TipoConstruccions_Id_TipoConstruccion",
                table: "Proyectos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cat_TipoConstruccions",
                table: "Cat_TipoConstruccions");

            migrationBuilder.RenameTable(
                name: "Cat_TipoConstruccions",
                newName: "Cat_TipoConstruccion");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cat_TipoConstruccion",
                table: "Cat_TipoConstruccion",
                column: "IdTipoConstruccion");

            migrationBuilder.AddForeignKey(
                name: "FK_Proyectos_Cat_TipoConstruccion_Id_TipoConstruccion",
                table: "Proyectos",
                column: "Id_TipoConstruccion",
                principalTable: "Cat_TipoConstruccion",
                principalColumn: "IdTipoConstruccion",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
