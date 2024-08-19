using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ArquiVision.Models
{
    public class Pedido
    {
        [Key]
        public int IdPedido { get; set; }
        public bool Eliminado { get; set; }

        [MaxLength(35)]
        public string NombreDelPedido { get; set; }

        [MaxLength(35)]
        public string EmpresaEncargada { get; set; }
        public decimal CostoDeEnvio { get; set; }
        public decimal Total { get; set; }

        [MaxLength(35)]
        public string MetodoDeEnvio { get; set; }

        [MaxLength(35)]
        public string? MetodoDeCompra { get; set; }

        public bool SeRegresaMaterial { get; set; }
        public decimal? CostoRegreso { get; set; }
        [MaxLength(30)]
        public string? Num_Ticket { get; set; }

        /// <summary>
        /// [ForeignKey("Documento")]
        /// </summary>
        ///    public int? IdDocumento { get; set; }

        [MaxLength]
        public string UsuarioCreo { get; set; }

        [MaxLength]
        public string? UsuarioElimino { get; set; }

        [MaxLength]
        public string? UsuarioModifico { get; set; }

        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaEliminacion { get; set; }
        public DateTime? FechaModificacion { get; set; }




    }

}
