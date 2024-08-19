using System.ComponentModel.DataAnnotations;

namespace ArquiVision.Models.Catalogos
{
    public class Cat_Prioridad
    {
        [Key]
        public int IdPrioridad { get; set; }
        [MaxLength(40)]
        public string Nombre { get; set; }
        public bool Eliminado { get; set; }

    }
}
