using ArquiVision.Models.Catalogos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArquiVision.Models
{
    public class Proyecto
    {
        [Key]
        public int IdProyecto { get; set; }
        public bool Eliminado { get; set; }

        [ForeignKey("Cat_TipoConstruccion")]
        public int Id_TipoConstruccion { get; set; }

        [MaxLength(50)]
        public string Encargado { get; set; }
        
        [MaxLength(50)]
        public string Nombre { get; set; }

        [ForeignKey("Cat_EstadoProyecto")]
        public int IdEstadoProyecto { get; set; }

        [MaxLength(40)]
        public string Estado { get; set; }
        [MaxLength(40)]
        public string Municipio { get; set; }
      
        public int CP { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        [MaxLength(50)]
        public string EmpresaEncargada { get; set; }
        [MaxLength]
        public string UsuarioCreo { get; set; }
        [MaxLength]
        public string? UsuarioElimino { get; set; }
        [MaxLength]
        public string? UsuarioModifico { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaEliminacion { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public Cat_EstadoProyecto Cat_EstadoProyecto { get; set; }
        public Cat_TipoConstruccion Cat_TipoConstruccion { get; set; }
        
    }

}
