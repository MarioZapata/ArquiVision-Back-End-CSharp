using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArquiVision.Models.Modulo_Material
{
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }
        public bool Eliminado { get; set; }
        public string NombreMaterial { get; set; }
        public decimal Costo { get; set; }

        public int TipoMaterial { get; set; }

        public string? UsuarioCreo { get; set; }

        [MaxLength]
        public string? UsuarioElimino { get; set; }

        [MaxLength]
        public string? UsuarioModifico { get; set; }

        [MaxLength]
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaEliminacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
