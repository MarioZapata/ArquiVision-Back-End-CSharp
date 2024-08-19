using ArquiVision.Data;
using ArquiVision.Migrations;
using ArquiVision.Models.Catalogos;
using Microsoft.EntityFrameworkCore;


namespace ArquiVision.Services.Modulo_Catalogo
{
 
    public interface ICatTipoActividadService { 
        Task<List<Cat_TipoActividad>> ObtenerTodosAsync();
    }

    public class CatTipoActividadService : ICatTipoActividadService
{
        private readonly AppDbContext _context;

        public CatTipoActividadService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cat_TipoActividad>> ObtenerTodosAsync()
        {
            //return await _context.Cat_TipoActividad.ToListAsync();
            return await _context.Cat_TipoActividad
            .Where(p => !p.Eliminado && p.EsPedido == false)  // Filtrar por Eliminado igual a false
            .ToListAsync();
        }
    }

}
