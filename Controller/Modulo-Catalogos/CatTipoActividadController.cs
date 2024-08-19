using ArquiVision.Models.Catalogos;
using ArquiVision.Services;
using ArquiVision.Services.Modulo_Catalogo;
using Microsoft.AspNetCore.Mvc;

namespace ArquiVision.Controller.Modulo_Catalogos
{
   
    namespace ArquiVision.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class CatTipoActividadController : ControllerBase
        {
            private readonly ICatTipoActividadService _catTipoConstruccionService;

            public CatTipoActividadController(ICatTipoActividadService catTipoConstruccionService)
            {
                _catTipoConstruccionService = catTipoConstruccionService;
            }

            [HttpGet]
            public async Task<ActionResult<List<Cat_TipoActividad>>> GetCatTipoConstrucciones()
            {
                var tiposConstruccion = await _catTipoConstruccionService.ObtenerTodosAsync();
                return Ok(tiposConstruccion);
            }
        }
    }
}
