using ArquiVision.Models.Catalogos;
using ArquiVision.Services;
using ArquiVision.Services.Modulo_Catalogo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArquiVision.Controller.Modulo_Catalogos
{
   
    namespace ArquiVision.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class CatTipoConstruccionController : ControllerBase
        {
            private readonly ICatTipoConstruccionService _catTipoConstruccionService;

            public CatTipoConstruccionController(ICatTipoConstruccionService catTipoConstruccionService)
            {
                _catTipoConstruccionService = catTipoConstruccionService;
            }

            [HttpGet]
            [Authorize]

            public async Task<ActionResult<List<Cat_TipoConstruccion>>> GetCatTipoConstrucciones()
            {
                var tiposConstruccion = await _catTipoConstruccionService.ObtenerTodosAsync();
                return Ok(tiposConstruccion);
            }
        }
    }

}

