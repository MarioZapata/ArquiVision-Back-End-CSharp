using System.ComponentModel.DataAnnotations;

namespace ArquiVision.Models.Catalogos
{
    public class Cat_TipoActividad
    {
        [Key]
        public int IdTipoActividad { get; set; }
        [MaxLength(40)]
        public string Nombre { get; set; }
        public bool Eliminado { get; set; }
        public bool EsPedido {  get; set; }

    }
}
