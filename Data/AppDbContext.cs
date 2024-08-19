using ArquiVision.Models;
using ArquiVision.Models.Catalogos;
using ArquiVision.Models.Modulo_Material;
using Microsoft.EntityFrameworkCore;

namespace ArquiVision.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<Actividad> Actividades { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Cat_TipoUsuario> Cat_TipoUsuario { get; set; }
        public DbSet<Cat_EstadoProyecto> Cat_EstadoProyecto { get; set; }
        public DbSet<Cat_EstadoActividad> Cat_EstadoActividad { get; set; }
        public DbSet<Cat_TipoActividad> Cat_TipoActividad { get; set; }
        public DbSet<Cat_Prioridad> Cat_Prioridad { get; set; }
        public DbSet<Cat_TipoConstruccion> Cat_TipoConstruccions { get; set; }
        public DbSet<Cat_TipoMaterial> Cat_TipoMaterials { get; set; }
        public DbSet<ProductoVenta> ProductoVentas { get; set; }
        public DbSet<Carrito> Carritos { get; set; }
        //public DbSet<Tarea> Tareas { get; set; }



    }
}

