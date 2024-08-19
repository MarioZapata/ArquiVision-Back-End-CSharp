using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ArquiVision.Models.Modulo_Pedido
{
    public class PedidoDTO
    {
    
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

        public string UsuarioCreo { get; set; }
        public DateTime FechaCreacion { get; set; }


    }
}
