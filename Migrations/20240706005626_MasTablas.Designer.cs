﻿// <auto-generated />
using System;
using ArquiVision.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ArquiVision.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240706005626_MasTablas")]
    partial class MasTablas
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.31")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ArquiVision.Models.Actividad", b =>
                {
                    b.Property<int>("IdActividad")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdActividad"));

                    b.Property<string>("Asignado")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("character varying(35)");

                    b.Property<string>("Compañia")
                        .HasColumnType("text");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("boolean");

                    b.Property<string>("Encargado")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("character varying(35)");

                    b.Property<bool>("EsCompraDeMateriales")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("FechaDeEntrega")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("FechaEliminacion")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("IdDocumento")
                        .HasColumnType("integer");

                    b.Property<int>("IdEstadoActividad")
                        .HasColumnType("integer");

                    b.Property<int>("IdEstadoProyecto")
                        .HasColumnType("integer");

                    b.Property<int?>("IdPedido")
                        .HasColumnType("integer");

                    b.Property<int>("IdPrioridad")
                        .HasColumnType("integer");

                    b.Property<int>("IdProyecto")
                        .HasColumnType("integer");

                    b.Property<int>("IdTipoActividad")
                        .HasColumnType("integer");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("character varying(35)");

                    b.Property<string>("UsuarioCreo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UsuarioElimino")
                        .HasColumnType("text");

                    b.Property<string>("UsuarioModifico")
                        .HasColumnType("text");

                    b.HasKey("IdActividad");

                    b.HasIndex("IdDocumento");

                    b.HasIndex("IdEstadoActividad");

                    b.HasIndex("IdEstadoProyecto");

                    b.HasIndex("IdPedido");

                    b.HasIndex("IdPrioridad");

                    b.HasIndex("IdProyecto");

                    b.HasIndex("IdTipoActividad");

                    b.ToTable("Actividades");
                });

            modelBuilder.Entity("ArquiVision.Models.Catalogos.Cat_EstadoActividad", b =>
                {
                    b.Property<int>("IdEstadoActividad")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdEstadoActividad"));

                    b.Property<bool>("Eliminado")
                        .HasColumnType("boolean");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.HasKey("IdEstadoActividad");

                    b.ToTable("Cat_EstadoActividad");
                });

            modelBuilder.Entity("ArquiVision.Models.Catalogos.Cat_EstadoProyecto", b =>
                {
                    b.Property<int>("IdEstadoProyecto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdEstadoProyecto"));

                    b.Property<bool>("Eliminado")
                        .HasColumnType("boolean");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.HasKey("IdEstadoProyecto");

                    b.ToTable("Cat_EstadoProyecto");
                });

            modelBuilder.Entity("ArquiVision.Models.Catalogos.Cat_Prioridad", b =>
                {
                    b.Property<int>("IdPrioridad")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdPrioridad"));

                    b.Property<bool>("Eliminado")
                        .HasColumnType("boolean");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.HasKey("IdPrioridad");

                    b.ToTable("Cat_Prioridad");
                });

            modelBuilder.Entity("ArquiVision.Models.Catalogos.Cat_TipoActividad", b =>
                {
                    b.Property<int>("IdTipoActividad")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdTipoActividad"));

                    b.Property<bool>("Eliminado")
                        .HasColumnType("boolean");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.HasKey("IdTipoActividad");

                    b.ToTable("Cat_TipoActividad");
                });

            modelBuilder.Entity("ArquiVision.Models.Catalogos.Cat_TipoConstruccion", b =>
                {
                    b.Property<int>("IdTipoConstruccion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdTipoConstruccion"));

                    b.Property<bool>("Eliminado")
                        .HasColumnType("boolean");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.HasKey("IdTipoConstruccion");

                    b.ToTable("Cat_TipoConstruccions");
                });

            modelBuilder.Entity("ArquiVision.Models.Catalogos.Cat_TipoMaterial", b =>
                {
                    b.Property<int>("IdTipoMaterial")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdTipoMaterial"));

                    b.Property<bool>("Eliminado")
                        .HasColumnType("boolean");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.HasKey("IdTipoMaterial");

                    b.ToTable("Cat_TipoMaterials");
                });

            modelBuilder.Entity("ArquiVision.Models.Catalogos.Cat_TipoUsuario", b =>
                {
                    b.Property<int>("IdTipoUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdTipoUsuario"));

                    b.Property<bool>("Eliminado")
                        .HasColumnType("boolean");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.HasKey("IdTipoUsuario");

                    b.ToTable("Cat_TipoUsuario");
                });

            modelBuilder.Entity("ArquiVision.Models.Documento", b =>
                {
                    b.Property<int>("IdDocumento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdDocumento"));

                    b.Property<byte[]>("Contenido")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("FechaEliminacion")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NombreArchivo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TipoContenido")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UsuarioCreo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UsuarioElimino")
                        .HasColumnType("text");

                    b.Property<string>("UsuarioModifico")
                        .HasColumnType("text");

                    b.HasKey("IdDocumento");

                    b.ToTable("Documento");
                });

            modelBuilder.Entity("ArquiVision.Models.Material", b =>
                {
                    b.Property<int>("Id_Material")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id_Material"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("integer");

                    b.Property<decimal>("CostoIndividual")
                        .HasColumnType("numeric");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("FechaEliminacion")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Id_Pedido")
                        .HasColumnType("integer");

                    b.Property<string>("NombreMaterial")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<decimal>("Total")
                        .HasColumnType("numeric");

                    b.Property<string>("UsuarioCreo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UsuarioElimino")
                        .HasColumnType("text");

                    b.Property<string>("UsuarioModifico")
                        .HasColumnType("text");

                    b.HasKey("Id_Material");

                    b.HasIndex("Id_Pedido");

                    b.ToTable("Materiales");
                });

            modelBuilder.Entity("ArquiVision.Models.Modulo_Material.Carrito", b =>
                {
                    b.Property<int>("IdCarrito")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdCarrito"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("integer");

                    b.Property<decimal>("CostoIndividual")
                        .HasColumnType("numeric");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("boolean");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("integer");

                    b.Property<decimal>("Total")
                        .HasColumnType("numeric");

                    b.HasKey("IdCarrito");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Carritos");
                });

            modelBuilder.Entity("ArquiVision.Models.Modulo_Material.MaterialVenta", b =>
                {
                    b.Property<int>("Id_MaterialVenta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id_MaterialVenta"));

                    b.Property<decimal>("Costo")
                        .HasColumnType("numeric");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("FechaEliminacion")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NombreMaterial")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TipoMaterial")
                        .HasColumnType("integer");

                    b.Property<string>("UsuarioCreo")
                        .HasColumnType("text");

                    b.Property<string>("UsuarioElimino")
                        .HasColumnType("text");

                    b.Property<string>("UsuarioModifico")
                        .HasColumnType("text");

                    b.HasKey("Id_MaterialVenta");

                    b.ToTable("MaterialVentas");
                });

            modelBuilder.Entity("ArquiVision.Models.Pedido", b =>
                {
                    b.Property<int>("IdPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdPedido"));

                    b.Property<decimal>("CostoDeEnvío")
                        .HasColumnType("numeric");

                    b.Property<decimal>("CostoRegreso")
                        .HasColumnType("numeric");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("boolean");

                    b.Property<string>("EmpresaProveedor")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("character varying(35)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("FechaEliminacion")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("IdDocumento")
                        .HasColumnType("integer");

                    b.Property<string>("MétodoDeCompra")
                        .HasMaxLength(35)
                        .HasColumnType("character varying(35)");

                    b.Property<string>("MétodoDeEnvío")
                        .HasMaxLength(35)
                        .HasColumnType("character varying(35)");

                    b.Property<string>("NombreDelPedido")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("character varying(35)");

                    b.Property<string>("Num_Ticket")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<bool>("SeRegresaMaterial")
                        .HasColumnType("boolean");

                    b.Property<decimal>("Total")
                        .HasColumnType("numeric");

                    b.Property<string>("UsuarioCreo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UsuarioElimino")
                        .HasColumnType("text");

                    b.Property<string>("UsuarioModifico")
                        .HasColumnType("text");

                    b.HasKey("IdPedido");

                    b.HasIndex("IdDocumento");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("ArquiVision.Models.Proyecto", b =>
                {
                    b.Property<int>("IdProyecto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdProyecto"));

                    b.Property<int>("CP")
                        .HasColumnType("integer");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("boolean");

                    b.Property<string>("EmpresaEncargada")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Encargado")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("FechaEliminacion")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("IdEstadoProyecto")
                        .HasColumnType("integer");

                    b.Property<int>("Id_TipoConstruccion")
                        .HasColumnType("integer");

                    b.Property<string>("Municipio")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("UsuarioCreo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UsuarioElimino")
                        .HasColumnType("text");

                    b.Property<string>("UsuarioModifico")
                        .HasColumnType("text");

                    b.HasKey("IdProyecto");

                    b.HasIndex("IdEstadoProyecto");

                    b.HasIndex("Id_TipoConstruccion");

                    b.ToTable("Proyectos");
                });

            modelBuilder.Entity("ArquiVision.Models.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdUsuario"));

                    b.Property<bool>("Activo")
                        .HasColumnType("boolean");

                    b.Property<string>("Apellido_Materno")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("Apellido_Paterno")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<byte[]>("ContraseñaCifrada")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<short>("Edad")
                        .HasColumnType("smallint");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("boolean");

                    b.Property<string>("EmpresaPertenece")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("FechaEliminacion")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("IdTipoUsuario")
                        .HasColumnType("integer");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("TokenSesion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UsuarioCreo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UsuarioElimino")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UsuarioModifico")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IdUsuario");

                    b.HasIndex("IdTipoUsuario");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("ArquiVision.Models.Actividad", b =>
                {
                    b.HasOne("ArquiVision.Models.Documento", "Documento")
                        .WithMany()
                        .HasForeignKey("IdDocumento");

                    b.HasOne("ArquiVision.Models.Catalogos.Cat_EstadoActividad", "Cat_EstadoActividad")
                        .WithMany()
                        .HasForeignKey("IdEstadoActividad")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ArquiVision.Models.Catalogos.Cat_EstadoProyecto", "Cat_EstadoProyecto")
                        .WithMany()
                        .HasForeignKey("IdEstadoProyecto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ArquiVision.Models.Pedido", "Pedido")
                        .WithMany()
                        .HasForeignKey("IdPedido");

                    b.HasOne("ArquiVision.Models.Catalogos.Cat_Prioridad", "Cat_Prioridad")
                        .WithMany()
                        .HasForeignKey("IdPrioridad")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ArquiVision.Models.Proyecto", "Proyecto")
                        .WithMany()
                        .HasForeignKey("IdProyecto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ArquiVision.Models.Catalogos.Cat_TipoActividad", "Cat_TipoActividad")
                        .WithMany()
                        .HasForeignKey("IdTipoActividad")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cat_EstadoActividad");

                    b.Navigation("Cat_EstadoProyecto");

                    b.Navigation("Cat_Prioridad");

                    b.Navigation("Cat_TipoActividad");

                    b.Navigation("Documento");

                    b.Navigation("Pedido");

                    b.Navigation("Proyecto");
                });

            modelBuilder.Entity("ArquiVision.Models.Material", b =>
                {
                    b.HasOne("ArquiVision.Models.Pedido", "Pedido")
                        .WithMany()
                        .HasForeignKey("Id_Pedido")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("ArquiVision.Models.Modulo_Material.Carrito", b =>
                {
                    b.HasOne("ArquiVision.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ArquiVision.Models.Pedido", b =>
                {
                    b.HasOne("ArquiVision.Models.Documento", "Documento")
                        .WithMany()
                        .HasForeignKey("IdDocumento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Documento");
                });

            modelBuilder.Entity("ArquiVision.Models.Proyecto", b =>
                {
                    b.HasOne("ArquiVision.Models.Catalogos.Cat_EstadoProyecto", "Cat_EstadoProyecto")
                        .WithMany()
                        .HasForeignKey("IdEstadoProyecto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ArquiVision.Models.Catalogos.Cat_TipoConstruccion", "Cat_TipoConstruccion")
                        .WithMany()
                        .HasForeignKey("Id_TipoConstruccion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cat_EstadoProyecto");

                    b.Navigation("Cat_TipoConstruccion");
                });

            modelBuilder.Entity("ArquiVision.Models.Usuario", b =>
                {
                    b.HasOne("ArquiVision.Models.Catalogos.Cat_TipoUsuario", "Cat_TipoUsuario")
                        .WithMany()
                        .HasForeignKey("IdTipoUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cat_TipoUsuario");
                });
#pragma warning restore 612, 618
        }
    }
}
