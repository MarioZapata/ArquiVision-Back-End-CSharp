using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ArquiVision.Migrations
{
    public partial class TipoConstruccion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proyectos_Cat_TipoActividad_Id_TipoConstruccion",
                table: "Proyectos");

            migrationBuilder.CreateTable(
                name: "Cat_TipoConstruccion",
                columns: table => new
                {
                    IdTipoConstruccion = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    Eliminado = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_TipoConstruccion", x => x.IdTipoConstruccion);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Proyectos_Cat_TipoConstruccion_Id_TipoConstruccion",
                table: "Proyectos",
                column: "Id_TipoConstruccion",
                principalTable: "Cat_TipoConstruccion",
                principalColumn: "IdTipoConstruccion",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proyectos_Cat_TipoConstruccion_Id_TipoConstruccion",
                table: "Proyectos");

            migrationBuilder.DropTable(
                name: "Cat_TipoConstruccion");

            migrationBuilder.AddForeignKey(
                name: "FK_Proyectos_Cat_TipoActividad_Id_TipoConstruccion",
                table: "Proyectos",
                column: "Id_TipoConstruccion",
                principalTable: "Cat_TipoActividad",
                principalColumn: "IdTipoActividad",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
