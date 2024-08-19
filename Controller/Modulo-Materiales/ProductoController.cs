using ArquiVision.Data;
using ArquiVision.Models;
using ArquiVision.Models.Catalogos;
using ArquiVision.Models.Modulo_Material;
using ArquiVision.Models.Modulo_Proyectos;
using ArquiVision.Services.Modulo_Catalogo;
using ArquiVision.Services.Modulo_Materiales;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArquiVision.Controller.Modulo_Materiales
{


    namespace ArquiVision.Controllers
    {

        [Route("api/[controller]")]
        [ApiController]
        public class ProductoController : ControllerBase
        {
            private readonly IProductoService _productoService;
            public class HacerVentaDTO
            {
                public int idUsuario { get; set; }
                public int idPedido { get; set; }
            }

            public ProductoController(IProductoService productoService)
            {
                _productoService = productoService;
            }
            [Authorize]
            [HttpGet]
            public async Task<ActionResult<List<Producto>>> GetCatTipoConstrucciones()
            {
                var tiposConstruccion = await _productoService.ObtenerTodosAsync();
                return Ok(tiposConstruccion);
            }
            [Authorize]
            [HttpGet("obtener/{idUsuario}")]
            public async Task<ActionResult<List<Producto>>> ObtenerProductosPorUsuario(int idUsuario)
            {
                try
                {
                    var productosF = await _productoService.ObtenerProductosUsuario(idUsuario);
                    return Ok(productosF);
                }
                catch (Exception ex)
                {
                    return BadRequest($"Error al obtener Productos: {ex.Message}");
                }
            }


            [Authorize]
            [HttpPost("hacerVenta")]
            public async Task<ActionResult<bool>> hacerVenta([FromBody] HacerVentaDTO request)
            {

                try
                {
                    var productosF = await _productoService.hacerVenta(request.idUsuario, request.idPedido);
                    return Ok(productosF);
                }
                catch (Exception ex)
                {
                    return BadRequest($"Error al obtener Productos: {ex.Message}");
                }
            }

            [HttpGet("getProductoByPedido")]
            public async Task<ActionResult<List<Producto>>> getProductoByPedido(int id)
            {

                try
                {
                    var productosF = await _productoService.getProductoByPedido(id);
                    return Ok(productosF);
                }
                catch (Exception ex)
                {
                    return BadRequest($"Error al obtener Productos: {ex.Message}");
                }
            }






        }
        


    }
}
