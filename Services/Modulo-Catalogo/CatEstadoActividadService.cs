using ArquiVision.Data;
using ArquiVision.Models.Catalogos;
using Microsoft.EntityFrameworkCore;

namespace ArquiVision.Services.Modulo_Catalogo
{

    public interface ICat_EstadoActividad
    {
        Task<List<Cat_EstadoActividad>> ObtenerTodosAsync();
    }

    public class CatEstadoActividadService : ICat_EstadoActividad
    {
        private readonly AppDbContext _context;

        public CatEstadoActividadService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cat_EstadoActividad>> ObtenerTodosAsync()
        {
            return await _context.Cat_EstadoActividad.Where(p => !p.Eliminado )  // Filtrar por Eliminado igual a false
            .ToListAsync();
        }
    }
}
