using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ArquiVision.Models
{
    public class ProductoVenta
    {
        [Key]
        public int IdProductoVenta { get; set; }
        public bool Eliminado { get; set; }

        [ForeignKey("Pedido")]
        public int IdPedido { get; set; }

        [MaxLength(50)]
        public string NombreMaterial { get; set; }
        public int Cantidad { get; set; }
        public decimal CostoIndividual { get; set; }
        public decimal Total { get; set; }

        [MaxLength]
        public string UsuarioCreo { get; set; }

        [MaxLength]
        public string? UsuarioElimino { get; set; }

        [MaxLength]
        public string? UsuarioModifico { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaEliminacion { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public Pedido Pedido { get; set; }

    }
}
