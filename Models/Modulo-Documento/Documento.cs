using System.ComponentModel.DataAnnotations;

namespace ArquiVision.Models
{
    public class Documento
    {

        [Key] public int IdDocumento { get; set; }

        public bool Eliminado { get; set; }

        [MaxLength]
        public string NombreArchivo { get; set; }
        [MaxLength]
        public string TipoContenido { get; set; }
        [MaxLength]
        public byte[] Contenido { get; set; }

        public string UsuarioCreo { get; set; }

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
