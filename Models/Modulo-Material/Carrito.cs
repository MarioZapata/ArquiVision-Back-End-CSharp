using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArquiVision.Models.Modulo_Material
{
    public class Carrito
    {
        [Key]
        public int IdCarrito { get; set; }
        public bool Eliminado { get; set; }

        [ForeignKey("Producto")]
        public int IdProducto { get; set; }
        public string Nombre { get; set; } 
        public int Cantidad { get; set; }
        public decimal CostoIndividual { get; set; }
        public decimal Total { get; set; }
        public string UsuarioCreo { get; set; }

        [MaxLength]
        public string? UsuarioElimino { get; set; }

        [MaxLength]
        public string? UsuarioModifico { get; set; }

        [MaxLength]
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaEliminacion { get; set; }
        public DateTime? FechaModificacion { get; set; }

        [ForeignKey("Usuario")]
        public int IdUsuario {  get; set; }
        public Usuario Usuario { get; set; }
        public Producto Producto { get; set; }

    }
}
