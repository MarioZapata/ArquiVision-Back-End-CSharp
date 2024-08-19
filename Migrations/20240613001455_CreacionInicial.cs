using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ArquiVision.Migrations
{
    public partial class CreacionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cat_EstadoActividad",
                columns: table => new
                {
                    IdEstadoActividad = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    Eliminado = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_EstadoActividad", x => x.IdEstadoActividad);
                });

            migrationBuilder.CreateTable(
                name: "Cat_EstadoProyecto",
                columns: table => new
                {
                    IdEstadoProyecto = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    Eliminado = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_EstadoProyecto", x => x.IdEstadoProyecto);
                });

            migrationBuilder.CreateTable(
                name: "Cat_Prioridad",
                columns: table => new
                {
                    IdPrioridad = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    Eliminado = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_Prioridad", x => x.IdPrioridad);
                });

            migrationBuilder.CreateTable(
                name: "Cat_TipoActividad",
                columns: table => new
                {
                    IdTipoActividad = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    Eliminado = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_TipoActividad", x => x.IdTipoActividad);
                });

            migrationBuilder.CreateTable(
                name: "Cat_TipoUsuario",
                columns: table => new
                {
                    IdTipoUsuario = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    Eliminado = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat_TipoUsuario", x => x.IdTipoUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Documento",
                columns: table => new
                {
                    IdDocumento = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Eliminado = table.Column<bool>(type: "boolean", nullable: false),
                    NombreArchivo = table.Column<string>(type: "text", nullable: false),
                    TipoContenido = table.Column<string>(type: "text", nullable: false),
                    Contenido = table.Column<byte[]>(type: "bytea", nullable: false),
                    UsuarioCreo = table.Column<string>(type: "text", nullable: false),
                    UsuarioElimino = table.Column<string>(type: "text", nullable: false),
                    UsuarioModifico = table.Column<string>(type: "text", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaEliminacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documento", x => x.IdDocumento);
                });

            migrationBuilder.CreateTable(
                name: "Proyectos",
                columns: table => new
                {
                    IdProyecto = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Eliminado = table.Column<bool>(type: "boolean", nullable: false),
                    Id_TipoConstruccion = table.Column<int>(type: "integer", nullable: false),
                    Encargado = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Nombre = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    IdEstadoProyecto = table.Column<int>(type: "integer", nullable: false),
                    Estado = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    Municipio = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CP = table.Column<int>(type: "integer", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EmpresaEncargada = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    UsuarioCreo = table.Column<string>(type: "text", nullable: false),
                    UsuarioElimino = table.Column<string>(type: "text", nullable: false),
                    UsuarioModifico = table.Column<string>(type: "text", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaEliminacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyectos", x => x.IdProyecto);
                    table.ForeignKey(
                        name: "FK_Proyectos_Cat_EstadoProyecto_IdEstadoProyecto",
                        column: x => x.IdEstadoProyecto,
                        principalTable: "Cat_EstadoProyecto",
                        principalColumn: "IdEstadoProyecto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Proyectos_Cat_TipoActividad_Id_TipoConstruccion",
                        column: x => x.Id_TipoConstruccion,
                        principalTable: "Cat_TipoActividad",
                        principalColumn: "IdTipoActividad",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Eliminado = table.Column<bool>(type: "boolean", nullable: false),
                    Correo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ContraseñaCifrada = table.Column<byte[]>(type: "bytea", nullable: false),
                    Nombre = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Apellido_Paterno = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Apellido_Materno = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Direccion = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Activo = table.Column<bool>(type: "boolean", nullable: false),
                    Edad = table.Column<short>(type: "smallint", nullable: false),
                    IdTipoUsuario = table.Column<int>(type: "integer", nullable: false),
                    EmpresaPertenece = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    UsuarioCreo = table.Column<string>(type: "text", nullable: false),
                    UsuarioElimino = table.Column<string>(type: "text", nullable: false),
                    UsuarioModifico = table.Column<string>(type: "text", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaEliminacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TokenSesion = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Cat_TipoUsuario_IdTipoUsuario",
                        column: x => x.IdTipoUsuario,
                        principalTable: "Cat_TipoUsuario",
                        principalColumn: "IdTipoUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    IdPedido = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Eliminado = table.Column<bool>(type: "boolean", nullable: false),
                    NombreDelPedido = table.Column<string>(type: "character varying(35)", maxLength: 35, nullable: false),
                    EmpresaProveedor = table.Column<string>(type: "character varying(35)", maxLength: 35, nullable: false),
                    CostoDeEnvío = table.Column<decimal>(type: "numeric", nullable: false),
                    Total = table.Column<decimal>(type: "numeric", nullable: false),
                    MétodoDeEnvío = table.Column<string>(type: "character varying(35)", maxLength: 35, nullable: false),
                    MétodoDeCompra = table.Column<string>(type: "character varying(35)", maxLength: 35, nullable: false),
                    SeRegresaMaterial = table.Column<bool>(type: "boolean", nullable: false),
                    CostoRegreso = table.Column<decimal>(type: "numeric", nullable: false),
                    Num_Ticket = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    IdDocumento = table.Column<int>(type: "integer", nullable: false),
                    UsuarioCreo = table.Column<string>(type: "text", nullable: false),
                    UsuarioElimino = table.Column<string>(type: "text", nullable: false),
                    UsuarioModifico = table.Column<string>(type: "text", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaEliminacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.IdPedido);
                    table.ForeignKey(
                        name: "FK_Pedidos_Documento_IdDocumento",
                        column: x => x.IdDocumento,
                        principalTable: "Documento",
                        principalColumn: "IdDocumento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Actividades",
                columns: table => new
                {
                    IdActividad = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Eliminado = table.Column<bool>(type: "boolean", nullable: false),
                    IdEstadoProyecto = table.Column<int>(type: "integer", nullable: false),
                    IdTipoActividad = table.Column<int>(type: "integer", nullable: false),
                    Nombre = table.Column<string>(type: "character varying(35)", maxLength: 35, nullable: false),
                    Encargado = table.Column<string>(type: "character varying(35)", maxLength: 35, nullable: false),
                    Asignado = table.Column<string>(type: "character varying(35)", maxLength: 35, nullable: false),
                    IdPrioridad = table.Column<int>(type: "integer", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EsCompraDeMateriales = table.Column<bool>(type: "boolean", nullable: false),
                    IdPedido = table.Column<int>(type: "integer", nullable: false),
                    Compañia = table.Column<string>(type: "text", nullable: false),
                    FechaDeEntrega = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdProyecto = table.Column<int>(type: "integer", nullable: false),
                    IdDocumento = table.Column<int>(type: "integer", nullable: false),
                    UsuarioCreo = table.Column<string>(type: "text", nullable: false),
                    UsuarioElimino = table.Column<string>(type: "text", nullable: false),
                    UsuarioModifico = table.Column<string>(type: "text", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaEliminacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actividades", x => x.IdActividad);
                    table.ForeignKey(
                        name: "FK_Actividades_Cat_EstadoProyecto_IdEstadoProyecto",
                        column: x => x.IdEstadoProyecto,
                        principalTable: "Cat_EstadoProyecto",
                        principalColumn: "IdEstadoProyecto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Actividades_Cat_Prioridad_IdPrioridad",
                        column: x => x.IdPrioridad,
                        principalTable: "Cat_Prioridad",
                        principalColumn: "IdPrioridad",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Actividades_Cat_TipoActividad_IdTipoActividad",
                        column: x => x.IdTipoActividad,
                        principalTable: "Cat_TipoActividad",
                        principalColumn: "IdTipoActividad",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Actividades_Documento_IdDocumento",
                        column: x => x.IdDocumento,
                        principalTable: "Documento",
                        principalColumn: "IdDocumento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Actividades_Pedidos_IdPedido",
                        column: x => x.IdPedido,
                        principalTable: "Pedidos",
                        principalColumn: "IdPedido",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Actividades_Proyectos_IdProyecto",
                        column: x => x.IdProyecto,
                        principalTable: "Proyectos",
                        principalColumn: "IdProyecto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Materiales",
                columns: table => new
                {
                    Id_Material = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Eliminado = table.Column<bool>(type: "boolean", nullable: false),
                    Id_Pedido = table.Column<int>(type: "integer", nullable: false),
                    NombreMaterial = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Cantidad = table.Column<int>(type: "integer", nullable: false),
                    CostoIndividual = table.Column<decimal>(type: "numeric", nullable: false),
                    Total = table.Column<decimal>(type: "numeric", nullable: false),
                    UsuarioCreo = table.Column<string>(type: "text", nullable: false),
                    UsuarioElimino = table.Column<string>(type: "text", nullable: false),
                    UsuarioModifico = table.Column<string>(type: "text", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaEliminacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Actividades_IdDocumento",
                table: "Actividades",
                column: "IdDocumento");

            migrationBuilder.CreateIndex(
                name: "IX_Actividades_IdEstadoProyecto",
                table: "Actividades",
                column: "IdEstadoProyecto");

            migrationBuilder.CreateIndex(
                name: "IX_Actividades_IdPedido",
                table: "Actividades",
                column: "IdPedido");

            migrationBuilder.CreateIndex(
                name: "IX_Actividades_IdPrioridad",
                table: "Actividades",
                column: "IdPrioridad");

            migrationBuilder.CreateIndex(
                name: "IX_Actividades_IdProyecto",
                table: "Actividades",
                column: "IdProyecto");

            migrationBuilder.CreateIndex(
                name: "IX_Actividades_IdTipoActividad",
                table: "Actividades",
                column: "IdTipoActividad");

            migrationBuilder.CreateIndex(
                name: "IX_Materiales_Id_Pedido",
                table: "Materiales",
                column: "Id_Pedido");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_IdDocumento",
                table: "Pedidos",
                column: "IdDocumento");

            migrationBuilder.CreateIndex(
                name: "IX_Proyectos_Id_TipoConstruccion",
                table: "Proyectos",
                column: "Id_TipoConstruccion");

            migrationBuilder.CreateIndex(
                name: "IX_Proyectos_IdEstadoProyecto",
                table: "Proyectos",
                column: "IdEstadoProyecto");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdTipoUsuario",
                table: "Usuarios",
                column: "IdTipoUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Actividades");

            migrationBuilder.DropTable(
                name: "Cat_EstadoActividad");

            migrationBuilder.DropTable(
                name: "Materiales");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Cat_Prioridad");

            migrationBuilder.DropTable(
                name: "Proyectos");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Cat_TipoUsuario");

            migrationBuilder.DropTable(
                name: "Cat_EstadoProyecto");

            migrationBuilder.DropTable(
                name: "Cat_TipoActividad");

            migrationBuilder.DropTable(
                name: "Documento");
        }
    }
}
