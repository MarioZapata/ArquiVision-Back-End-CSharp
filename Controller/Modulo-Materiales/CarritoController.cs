using ArquiVision.Models.Modulo_Material;
using ArquiVision.Services.Modulo_Materiales;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArquiVision.Controller.Modulo_Materiales
{
    
    public class UpdateCarritoRequest
    {
        public int IdCarrito { get; set; }
        public int Cantidad { get; set; }
    }
    [Route("api/carrito")]
    [ApiController]
    public class CarritoController : ControllerBase
    {
        private readonly ICarritoService _carritoService;

        public CarritoController(ICarritoService carritoService)
        {
            _carritoService = carritoService;
        }

        [Authorize]
        [HttpPatch("updateCarrito")]
        public async Task<ActionResult<bool>> UpdateCarrito([FromBody] UpdateCarritoRequest request)
        {
            try
            {
                var seActualizo = await _carritoService.updateCarrito(request.IdCarrito, request.Cantidad);
                if (!seActualizo)
                {
                    return BadRequest("No existe el artículo en el carrito");
                }
                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest("Error en el servidor, favor de hablar con el equipo de soporte");
            }
        }

        [HttpPatch("eliminarCarrito")]
        public async Task<ActionResult<bool>> eliminarCarrito([FromBody] UpdateCarritoRequest request)
        {
            try
            {
                var seActualizo = await _carritoService.eliminarCarrito(request.IdCarrito);
                if (!seActualizo)
                {
                    return BadRequest("No existe el artículo en el carrito");
                }
                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest("Error en el servidor, favor de hablar con el equipo de soporte");
            }
        }

        [Authorize]
        [HttpPost("agregar")]
        public async Task<ActionResult<CarritoDTO>> AgregarAlCarrito(CarritoDTO carritoDto)
        {
            try
            {
                var carrito = await _carritoService.AgregarAlCarrito(carritoDto);
                if (carrito == null)
                {
                    return BadRequest("No se puede agregar el mismo producto, si desea aumentar la cantidad, favor de dar clic en +");

                }
                return Ok(carrito);
            }
            catch (Exception ex)
            {
                return BadRequest("Error al agregar al carrito");
            }
        }
        [Authorize]
        [HttpGet("obtener/{idUsuario}")]
        public async Task<ActionResult<List<Carrito>>> ObtenerCarritosPorUsuario(int idUsuario)
        {
            try
            {
                var carritos = await _carritoService.ObtenerCarritosPorUsuarioAsync(idUsuario);
                return Ok(carritos);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al obtener carritos: {ex.Message}");
            }
        }
    }
}
