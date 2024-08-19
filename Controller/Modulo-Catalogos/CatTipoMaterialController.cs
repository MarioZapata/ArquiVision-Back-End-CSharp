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
        public class CatTipoMaterialController : ControllerBase
        {
            private readonly ICatTipoMaterialService _catTipoConstruccionService;

            public CatTipoMaterialController(ICatTipoMaterialService catTipoConstruccionService)
            {
                _catTipoConstruccionService = catTipoConstruccionService;
            }

            [HttpGet]
       

            public async Task<ActionResult<List<Cat_TipoMaterial>>> GetCatTipoConstrucciones()
            {
                var tiposConstruccion = await _catTipoConstruccionService.ObtenerTodosAsync();
                return Ok(tiposConstruccion);
            }
        }
    }
}
