using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ArquiVision.Migrations
{
    public partial class Tablas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Materiales");

            migrationBuilder.DropTable(
                name: "MaterialVentas");

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id_Producto = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Eliminado = table.Column<bool>(type: "boolean", nullable: false),
                    NombreMaterial = table.Column<string>(type: "text", nullable: false),
                    Costo = table.Column<decimal>(type: "numeric", nullable: false),
                    TipoMaterial = table.Column<int>(type: "integer", nullable: false),
                    UsuarioCreo = table.Column<string>(type: "text", nullable: true),
                    UsuarioElimino = table.Column<string>(type: "text", nullable: true),
                    UsuarioModifico = table.Column<string>(type: "text", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaEliminacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id_Producto);
                });

            migrationBuilder.CreateTable(
                name: "ProductoVentas",
                columns: table => new
                {
                    Id_ProductoVenta = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Eliminado = table.Column<bool>(type: "boolean", nullable: false),
                    Id_Pedido = table.Column<int>(type: "integer", nullable: false),
                    NombreMaterial = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Cantidad = table.Column<int>(type: "integer", nullable: false),
                    CostoIndividual = table.Column<decimal>(type: "numeric", nullable: false),
                    Total = table.Column<decimal>(type: "numeric", nullable: false),
                    UsuarioCreo = table.Column<string>(type: "text", nullable: false),
                    UsuarioElimino = table.Column<string>(type: "text", nullable: true),
                    UsuarioModifico = table.Column<string>(type: "text", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaEliminacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoVentas", x => x.Id_ProductoVenta);
                    table.ForeignKey(
                        name: "FK_ProductoVentas_Pedidos_Id_Pedido",
                        column: x => x.Id_Pedido,
                        principalTable: "Pedidos",
                        principalColumn: "IdPedido",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductoVentas_Id_Pedido",
                table: "ProductoVentas",
                column: "Id_Pedido");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "ProductoVentas");

            migrationBuilder.CreateTable(
                name: "Materiales",
                columns: table => new
                {
                    Id_Material = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id_Pedido = table.Column<int>(type: "integer", nullable: false),
                    Cantidad = table.Column<int>(type: "integer", nullable: false),
                    CostoIndividual = table.Column<decimal>(type: "numeric", nullable: false),
                    Eliminado = table.Column<bool>(type: "boolean", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaEliminacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    NombreMaterial = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Total = table.Column<decimal>(type: "numeric", nullable: false),
                    UsuarioCreo = table.Column<string>(type: "text", nullable: false),
                    UsuarioElimino = table.Column<string>(type: "text", nullable: true),
                    UsuarioModifico = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materiales", x => x.Id_Material);
                    table.ForeignKey(
                        name: "FK_Materiales_Pedidos_Id_Pedido",
                        column: x => x.Id_Pedido,
                        principalTable: "Pedidos",
                        principalColumn: "IdPedido",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaterialVentas",
                columns: table => new
                {
                    Id_MaterialVenta = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Costo = table.Column<decimal>(type: "numeric", nullable: false),
                    Eliminado = table.Column<bool>(type: "boolean", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaEliminacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    NombreMaterial = table.Column<string>(type: "text", nullable: false),
                    TipoMaterial = table.Column<int>(type: "integer", nullable: false),
                    UsuarioCreo = table.Column<string>(type: "text", nullable: true),
                    UsuarioElimino = table.Column<string>(type: "text", nullable: true),
                    UsuarioModifico = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialVentas", x => x.Id_MaterialVenta);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Materiales_Id_Pedido",
                table: "Materiales",
                column: "Id_Pedido");
        }
    }
}
