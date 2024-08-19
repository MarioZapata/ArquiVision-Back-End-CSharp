using ArquiVision.Migrations;
using ArquiVision.Models;
using ArquiVision.Models.Modulo_Actividades;
using ArquiVision.Models.Modulo_Proyectos;
using ArquiVision.Services;
using ArquiVision.Services.Modulo_Actividades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using static ArquiVision.Controllers.ActividadesController;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ArquiVision.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActividadesController : ControllerBase
    {

        private readonly ActividadService _actividadService;

        public ActividadesController(ActividadService actividadService)
        {
            _actividadService = actividadService;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> CreateActividad(ActividadDTO actividadDTO)
        {
            try
            {
                var validarProyecto = await _actividadService.ValidarProyecto(actividadDTO.IdProyecto);
                if(validarProyecto==false)
                {
                    return BadRequest("EL proyecto esta cancelado o eliminado");
                }
                var actividad = await _actividadService.AddActividadAsync(actividadDTO);
                return Ok(actividad);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpPost("updateActividad")]
        public async Task<ActionResult> UpdateActividad([FromBody] ActividadDTO  update)
        {
            try
            {
                var name = User.Claims.FirstOrDefault(c => c.Type == "nombre")?.Value;
                if (name == null)
                {
                    return BadRequest("Existe un problema con su usuario, favor de comunicarse con equipo de soporte");
                }
                else
                {
                    var actividad = await _actividadService.updateActividadAsync(update.IdActividad, name, update);
                    return Ok(actividad);
                }
            
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpPatch("deleteActividad")]
        public async Task<ActionResult> DeleteActividad([FromBody] int id)
        {
            try
            {
                var name = User.Claims.FirstOrDefault(c => c.Type == "nombre")?.Value;
                if (name == null)
                {
                    return BadRequest("Existe un problema con su usuario, favor de comunicarse con equipo de soporte");
                }
                else
                {
                    var actividad = await _actividadService.DeleteActividad(id, name);
                    if (actividad == false)
                    {
                        return BadRequest("No existe la actividad");

                    }
                    if (actividad == null)
                    {

                        return BadRequest("No existe un errror en el serivicio, favor de comunicarse con equipo de soporte");
                    }
                    return Ok(actividad);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("getActividadByEmpresa")]
        public async Task<ActionResult<List<Actividad>>> getActividadByEmpresa(string Empresa, int idProyecto)
        {
            try
            {
                var actividad = await _actividadService.GetActividadByEmpresa(Empresa, idProyecto);
                return Ok(actividad);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpGet("getActividades")]
        public async Task<ActionResult<List<Actividad>>> getActividades (string Empresa)
        {
            try
            {
                var actividad = await _actividadService.GetActividades(Empresa);
                return Ok(actividad);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpGet("getActividadesByFilters")]
        public async Task<ActionResult<List<Actividad>>> getAcividadByFilters([FromQuery]ActividadFilters filtros)
        {
            try
            {
                var actividades = await _actividadService.getAcividadByFilters(filtros);
                return actividades;
            }
            catch (Exception ex)
            {
                return BadRequest("Error en el servidor, favor de comunicarse con equipo");
            }
        }
        [Authorize]
        [HttpPatch("giveVoBo")]
        public async Task<ActionResult<bool>> darVoBO([FromBody] int id)
        {
            var name = User.Claims.FirstOrDefault(c => c.Type == "nombre")?.Value;
            //var name = "Rio";
            if (name == null)
            {
                return BadRequest("Existe un problema con su usuario, favor de comunicarse con equipo de soporte");
            }
            try
            {
                var actividades = await _actividadService.DarVoBo(id, name);
                if (actividades == false)
                {
                    return BadRequest("Existe un problema con la actividad, no se puede dar vobo cuando se ha firmado o no se encontro");
                }
                return actividades;
            }
            catch (Exception ex)
            {
                return BadRequest("Error en el servidor, favor de comunicarse con equipo");
            }
        }

        [Authorize]
        [HttpPatch("giveFirma")]
        public async Task<ActionResult<bool>> darFirma([FromBody] int id)
        {
            var name = User.Claims.FirstOrDefault(c => c.Type == "nombre")?.Value;
            //var name = "Rio";
            if (name == null)
            {
                return BadRequest("Existe un problema con su usuario, favor de comunicarse con equipo de soporte");
            }
            
            try
            {
                var actividades = await _actividadService.DarFirma(id, name);
                if (actividades == false)
                {
                    return BadRequest("Existe un problema con la actividad, no puede ser firmada mas de una vez o no se encontro");
                }
                return actividades;
            }
            catch (Exception ex)
            {
                return BadRequest("Error en el servidor, favor de comunicarse con equipo");
            }
        }
        [Authorize]
        [HttpPatch("giveCancelacion")]
        public async Task<ActionResult<bool>> darCancelacion([FromBody] int id)
        {
            var name = User.Claims.FirstOrDefault(c => c.Type == "nombre")?.Value;
            //var name = "Rio";
            if (name == null)
            {
                return BadRequest("Existe un problema con su usuario, favor de comunicarse con equipo de soporte");
            }
              
            try
            {
                var actividades = await _actividadService.DarCancelacion(id, name);
                if (actividades == false)
                {
                    return BadRequest("Existe un problema con la actividad, no puede ser firmada mas de una vez o no se encontro");
                }
                return actividades;
            }
            catch (Exception ex)
            {
                return BadRequest("Error en el servidor, favor de comunicarse con equipo");
            }
        }




    }
}
