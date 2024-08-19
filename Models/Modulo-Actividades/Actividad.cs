using ArquiVision.Models.Catalogos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Tracing;

namespace ArquiVision.Models
{
    public class Actividad
    {
        [Key]     
        
        public int IdActividad{ get; set; }

        public bool Eliminado { get; set; }

        //[ForeignKey("Cat_EstadoProyecto")]
        //public int IdEstadoProyecto { get; set; }

        [ForeignKey("Cat_TipoActividad")]
        public int IdTipoActividad { get; set; }

        [ForeignKey("Cat_EstadoActividad")]
        public int IdEstadoActividad { get; set; }

        [MaxLength(35)]
        public string Nombre { get; set; }

        [MaxLength(35)]
        public string Encargado { get; set; }

        [MaxLength(35)]
        public string Asignado { get; set; }

        [ForeignKey("Cat_Prioridad")] 
        public int IdPrioridad { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public bool EsCompraDeMateriales { get; set; }

        [ForeignKey("Pedido")]
        public int? IdPedido { get; set; }

        public string EmpresaEncargada { get; set; }

        [ForeignKey("Proyecto")] 
        public int IdProyecto { get; set; }

        [ForeignKey("Documento")]
       
        public int? IdDocumento { get; set; }

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

        public Cat_EstadoActividad Cat_EstadoActividad { get; set; }
        //public Cat_EstadoProyecto Cat_EstadoProyecto { get; set; }
        public Cat_Prioridad Cat_Prioridad { get; set; }
        public Cat_TipoActividad Cat_TipoActividad { get; set; }
        public Pedido Pedido { get; set; }
        public Proyecto Proyecto {  get; set; }
        public Documento Documento { get; set; }

    }

}
