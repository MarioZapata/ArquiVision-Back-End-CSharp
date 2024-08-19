using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArquiVision.Models.Modulo_Proyectos
{
    public class ProyectoDTO
    {
        public bool Eliminado { get; set; }
        public int Id_TipoConstruccion { get; set; }

        [MaxLength(50)]
        public string Encargado { get; set; }

        [MaxLength(50)]
        public string Nombre { get; set; }

   
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
      
    

    }
}
