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
            public class CatEstadoActividadController : ControllerBase
            {
                private readonly ICat_EstadoActividad _catTipoConstruccionService;

                public CatEstadoActividadController(ICat_EstadoActividad catTipoConstruccionService)
                {
                    _catTipoConstruccionService = catTipoConstruccionService;
                }

                [HttpGet]
                public async Task<ActionResult<List<Cat_EstadoActividad>>> GetCatTipoConstrucciones()
                {
                    var tiposConstruccion = await _catTipoConstruccionService.ObtenerTodosAsync();
                    return Ok(tiposConstruccion);
                }
            }
        }

 }


