using System.ComponentModel.DataAnnotations;

namespace ArquiVision.Models.Catalogos
{
    public class Cat_TipoConstruccion
    {
        [Key]
        public int IdTipoConstruccion { get; set; }
        [MaxLength(40)]
        public string Nombre { get; set; }
        public bool Eliminado { get; set; }

    }
}
