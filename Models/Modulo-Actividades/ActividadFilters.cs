using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArquiVision.Models.Modulo_Actividades
{
    public class ActividadFilters
    {
        public int? IdActividad { get; set; }
        public int? IdTipoActividad { get; set; }
        public int? IdEstadoActividad { get; set; }
        public int? IdPrioridad { get; set; }
        public string? Nombre { get; set; }
        public string? Encargado { get; set; }
        public string? Asignado { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public bool? EsCompraDeMateriales { get; set; }

        public string EmpresaEncargada { get; set; }
    }
}
