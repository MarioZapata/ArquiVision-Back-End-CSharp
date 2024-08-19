using ArquiVision.Models.Catalogos;
using ArquiVision.Services.Modulo_Catalogo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArquiVision.Controller.Modulo_Catalogos
{

    namespace ArquiVision.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class CatEstadoProyectoController : ControllerBase
        {
            private readonly ICatEstadoProyectoService _catEstadoProyectoService;

            public CatEstadoProyectoController(ICatEstadoProyectoService catEstadoProyectoService)
            {
                _catEstadoProyectoService = catEstadoProyectoService;
            }
            [Authorize]
            [HttpGet]
            public async Task<ActionResult<List<Cat_EstadoProyecto>>> GetCatTipoConstrucciones()
            {
                var tiposConstruccion = await _catEstadoProyectoService.ObtenerTodosAsync();
                return Ok(tiposConstruccion);
            }
        }
    }
}
