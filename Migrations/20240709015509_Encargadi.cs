using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArquiVision.Migrations
{
    public partial class Encargadi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Compañia",
                table: "Actividades",
                newName: "EmpresaEncargada");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmpresaEncargada",
                table: "Actividades",
                newName: "Compañia");
        }
    }
}
