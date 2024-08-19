using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArquiVision.Models.Modulo_Material
{
    public class ProductoVentaDTO
    {
 
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
        public DateTime FechaCreacion { get; set; }
    }
}
