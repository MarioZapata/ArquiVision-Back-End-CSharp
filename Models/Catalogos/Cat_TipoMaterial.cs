using System.ComponentModel.DataAnnotations;

namespace ArquiVision.Models.Catalogos
{
    public class Cat_TipoMaterial
    {
        [Key]
        public int IdTipoMaterial { get; set; }
        [MaxLength(40)]
        public string Nombre { get; set; }
        public bool Eliminado { get; set; }
    }
}
