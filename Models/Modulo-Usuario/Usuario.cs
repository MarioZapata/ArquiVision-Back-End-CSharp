using ArquiVision.Models.Catalogos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArquiVision.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        public bool Eliminado { get; set; }


        [MaxLength(100)]
        public string Correo { get; set; }
        [MaxLength]
        public byte[] ContraseñaCifrada { get; set; }
        [MaxLength(20)]
        public string Nombre { get; set; }
        [MaxLength(20)]
        public string Apellido_Paterno { get; set; }
        [MaxLength(20)]
        public string Apellido_Materno { get; set; }
        [MaxLength(50)]
        public string Direccion { get; set; }
        public bool Activo { get; set; }
        public short Edad { get; set; }

        [ForeignKey("Cat_TipoUsuario")]
        public int IdTipoUsuario { get; set; }

        [MaxLength(50)]
        public string EmpresaPertenece { get; set; }
        [MaxLength]
        public string UsuarioCreo { get; set; }
        [MaxLength]
        public string? UsuarioElimino { get; set; }
        [MaxLength]
        public string? UsuarioModifico { get; set; }
        [MaxLength]
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaEliminacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        [MaxLength]
        public string? ConfirmationToken { get; set; }
        public int Intentos {  get; set; }

        public DateTime? FechaIntento { get; set; }

        public Cat_TipoUsuario Cat_TipoUsuario { get; set; }
    }

}
