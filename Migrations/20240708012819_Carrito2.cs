using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArquiVision.Migrations
{
    public partial class Carrito2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "Carritos",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaEliminacion",
                table: "Carritos",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaModificacion",
                table: "Carritos",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioCreo",
                table: "Carritos",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioElimino",
                table: "Carritos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioModifico",
                table: "Carritos",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "Carritos");

            migrationBuilder.DropColumn(
                name: "FechaEliminacion",
                table: "Carritos");

            migrationBuilder.DropColumn(
                name: "FechaModificacion",
                table: "Carritos");

            migrationBuilder.DropColumn(
                name: "UsuarioCreo",
                table: "Carritos");

            migrationBuilder.DropColumn(
                name: "UsuarioElimino",
                table: "Carritos");

            migrationBuilder.DropColumn(
                name: "UsuarioModifico",
                table: "Carritos");
        }
    }
}
