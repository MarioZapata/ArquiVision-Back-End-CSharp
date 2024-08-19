using ArquiVision.Models.Catalogos;
using ArquiVision.Services;
using ArquiVision.Services.Modulo_Catalogo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArquiVision.Controller.Modulo_Catalogos
{
 
    [Route("api/[controller]")]
   

    [ApiController]
    public class CatTipoUsuarioController : ControllerBase
    {
        private readonly ICatTipoUsuarioService _catTipoConstruccionService;

        public CatTipoUsuarioController(ICatTipoUsuarioService catTipoConstruccionService)
        {
            _catTipoConstruccionService = catTipoConstruccionService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<Cat_TipoUsuario>>> GetCatTipoConstrucciones()
        {
            var tiposConstruccion = await _catTipoConstruccionService.ObtenerTodosAsync();
            return Ok(tiposConstruccion);
        }
    }
}

