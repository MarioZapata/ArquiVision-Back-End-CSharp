using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArquiVision.Models.Modulo_Material
{
    public class CarritoDTO
    {
 
        public bool Eliminado { get; set; }
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public decimal CostoIndividual { get; set; }
        public decimal Total { get; set; }
        public string UsuarioCreo { get; set; }
        public int IdUsuario { get; set; }


    }
}
