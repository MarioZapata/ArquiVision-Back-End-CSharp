using ArquiVision.Migrations;
using ArquiVision.Models;
using ArquiVision.Models.Modulo_Pedido;
using ArquiVision.Services.Modulo_Materiales;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography.X509Certificates;

namespace ArquiVision.Controller.Modulo_Materiales
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        public class PedidoCTO
        {
            public int? idPedido { get; set; }
            public string? nombre { get; set; }
        }
    
        
        private readonly IPedidoService _pedidoService;
        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }
   
        [Authorize]
        [HttpPost("crearPedido")]
        public async Task<ActionResult<Pedido>> Pedido([FromBody]PedidoDTO pedidodto)
        {
            try
            {

                var pedidoR = await _pedidoService.CrearPedido(pedidodto);
                if (pedidoR == null)
                {
                    return BadRequest($"Error nulo:");
                }
                return Ok(pedidoR);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [Authorize]
        [HttpGet("obtenerPedido")]
        public async Task<ActionResult<Pedido>> obtenerPedido(string Empresa)
        {
            try
            {

                var pedidoR = await _pedidoService.ObtenerTodosAsync(Empresa);
                if (pedidoR == null)
                {
                    return BadRequest($"Error nulo:");
                }
                return Ok(pedidoR);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Authorize]
        [HttpGet("getPedidoNameORId")]
        public async Task<ActionResult<List<Pedido>>> obtenerPedidoPorEmpresaOId([FromQuery]PedidoCTO cto)
        {
            if(cto.idPedido == null && cto.nombre.IsNullOrEmpty()==true)
            {
                return BadRequest("No ingreso ningun parametro");
            }
            else
            {
                try
                {

                    var pedidoR = await _pedidoService.obtenerPedidoPorEmpresaOId(cto);
                    if (pedidoR == null || !pedidoR.Any())
                    {
                        return BadRequest("No se encontraron pedidos con los parámetros especificados.");
                    }

                    return Ok(pedidoR);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }
            }
        }
        [Authorize]
        [HttpGet("validar")]
        public async Task<ActionResult<Actividad>> validarPedido(int id)
        {
            try
            {
                var actividades = await _pedidoService.validarPedidoAct(id);
                return Ok(actividades);
            }catch (Exception ex)
            {
                return BadRequest("Favor, de comunicarse con equipo de soporte");
            }
        }
        //[Authorize]
        [HttpPatch("deletePedido")]
        public async Task<ActionResult<bool>> eliminarPedido([FromBody] int id )
        {
            //var name = User.Claims.FirstOrDefault(c => c.Type == "nombre")?.Value;
            var name = "Rio";
            try
            {

                var pedidoR = await _pedidoService.deletePedido(id, name);
                if (pedidoR == null || pedidoR ==false)
                {
                    return BadRequest("Favor, de comunicarse con equipo de soporte");
                }

                return Ok(pedidoR);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}

