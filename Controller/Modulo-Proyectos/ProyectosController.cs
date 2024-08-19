using ArquiVision.Models;
using ArquiVision.Models.Modulo_Proyectos;
using ArquiVision.Models.Modulo_Usuario;
using ArquiVision.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;

namespace ArquiVision.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectosController : ControllerBase
    {
        private readonly ProyectoService _proyectoService;

        public ProyectosController(ProyectoService proyectoService)
        {
            _proyectoService = proyectoService;
        }
        public class changeStatusDTO
        {
            public int Id { get; set; }
            public int IdCambio { get; set; }
        }

        [Authorize]
        [HttpPatch("actulizarProyecto")]
        public async Task<ActionResult> actulizarProyecto(ProyectoDTOM proyecto)
        {
            try
            {
                var name = User.Claims.FirstOrDefault(c => c.Type == "nombre")?.Value;
                proyecto.UsuarioModifico=name;
                bool actualizacionExitosa = await _proyectoService.ActulizarProyecto(proyecto);
                if (actualizacionExitosa == false)
                {
                    return BadRequest("No existe registro");

                }
                return Ok(actualizacionExitosa);
            }catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [Authorize]
        [HttpGet("getProyectosByFiltros")]
        public async Task<ActionResult<IEnumerable<Proyecto>>> GetProyectosByFiltros(
        [FromQuery] string empresa = null,
        [FromQuery] string? nombre = null,
        [FromQuery] int? idTipoConstruccion = null,
        [FromQuery] int? idEstadoProyecto = null,
        [FromQuery] DateTime? fechaInicio = null,
        [FromQuery] DateTime? fechaFinal = null,
        [FromQuery] string? encargado = null,
        [FromQuery] string? municipio = null,
        [FromQuery] string? estado = null,
        [FromQuery] int? cp = null)
        {

            try
            {
                var proyectos = await _proyectoService.GetProyectosByFiltros(
                  empresa: empresa,
                  nombre: nombre,
                  idEstadoProyecto: idEstadoProyecto,
                  fechaInicio: fechaInicio,
                  fechaFinal: fechaFinal,
                  encargado: encargado,
                  municipio: municipio,
                  estado: estado,
                  cp: cp,
                  idTipoConstruccion: idTipoConstruccion
              );
                return Ok(proyectos);
            }
            catch (Exception ex)
            {
                return BadRequest("Error en el sistema, por favor de hablar con soporte");
            }
         

        }
        [Authorize]
        [HttpGet("getProyectosByEmpresa")]
        public async Task<ActionResult<IEnumerable<Proyecto>>> GetProyectosByEmpresa(string Empresa)
        {
            
            try
            {
                var proyectos = await _proyectoService.GetProyectosByEmpresa(Empresa);
                return Ok(proyectos);
            }
            catch (Exception ex)
            {
                return BadRequest("Error en el sistema, por favor de hablar con soporte");
            }
        }
        [Authorize]
        [HttpGet("getProyectoByIdName")]
        public async Task<ActionResult<IEnumerable<Proyecto>>> getProyectoByIdName(string Empresa, int? Id, string? Nombre)
        {
            try
            {
                var proyectos = await _proyectoService.getProyectoByIdName( Empresa,  Id,  Nombre);
                if(proyectos == null)
                {
                    return BadRequest("No se encontro ningun registro");

                }
                return Ok(proyectos);
            }
            catch (Exception ex)
            {
                return BadRequest("Error en el sistema, por favor de hablar con soporte");
            }
        }

        [Authorize]
        [HttpPost("crearProyecto")]
        public async Task<ActionResult> CreateProyecto(ProyectoDTO proyectoDTO)
        {
            try
            {
                var proyecto = await _proyectoService.AddProyectoAsync(proyectoDTO);

                return Ok(proyecto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            
        }
        [Authorize]
        [HttpPatch("deleteProyecto")]
        public async Task<ActionResult<bool>> DeleteProyecto([FromBody]int id)
        {
            if(id == 0)
            {
                return BadRequest("Error en el servidor, favor de comunicarse con equipo ");
            }
            try
            {
                var name = User.Claims.FirstOrDefault(c => c.Type == "nombre")?.Value;
                var proyecto = await _proyectoService.DeleteProyecto(id,name);

                return Ok(proyecto);
            }
            catch (Exception ex)
            {
                return BadRequest("Error en el servidor, favor de comunicarse con equipo ");
            }


        }
        [HttpPatch("changeStatus")]
        public async Task<ActionResult<bool>> cambarEstado([FromBody] changeStatusDTO change) 
        {
            try
            {
                var name = "atom";
                //var name = User.Claims.FirstOrDefault(c => c.Type == "nombre")?.Value;
                var proyecto = await _proyectoService.cambiarEstado(change.Id, name, change.IdCambio);
                if (proyecto == false)
                {
                    return BadRequest("Error en el servidor, favor de comunicarse con equipo ");
                }
                return Ok(proyecto);
            }
            catch (Exception ex)
            {
                return BadRequest("Error en el servidor, favor de comunicarse con equipo ");
            }
        }
    }
}
