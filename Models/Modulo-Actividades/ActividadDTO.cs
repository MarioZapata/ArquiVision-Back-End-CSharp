using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ArquiVision.Models.Modulo_Actividades
{
    public class ActividadDTO
    {
        [Key]
        public int IdActividad { get; set; }
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
    }
}
