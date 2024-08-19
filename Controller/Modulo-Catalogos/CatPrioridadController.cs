using ArquiVision.Models.Catalogos;
using ArquiVision.Services.Modulo_Catalogo;
using Microsoft.AspNetCore.Mvc;

namespace ArquiVision.Controller.Modulo_Catalogos
{
   
    namespace ArquiVision.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class CatPrioridadController : ControllerBase
        {
            private readonly ICatPrioridadService _ICatPrioridadService;

            public CatPrioridadController(ICatPrioridadService iCatPrioridadService)
            {
                _ICatPrioridadService = iCatPrioridadService;
            }

            [HttpGet]
            public async Task<ActionResult<List<Cat_EstadoProyecto>>> GetCatTipoConstrucciones()
            {
                var tiposConstruccion = await _ICatPrioridadService.ObtenerTodosAsync();
                return Ok(tiposConstruccion);
            }
        }
    }
}
