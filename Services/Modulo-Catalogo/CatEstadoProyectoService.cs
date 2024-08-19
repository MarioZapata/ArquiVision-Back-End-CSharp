using ArquiVision.Data;
using ArquiVision.Models.Catalogos;
using Microsoft.EntityFrameworkCore;

namespace ArquiVision.Services.Modulo_Catalogo
{
   
    public interface ICatEstadoProyectoService
    {
        Task<List<Cat_EstadoProyecto>> ObtenerTodosAsync();
    }

    public class CatEstadoProyectoService : ICatEstadoProyectoService
    {
        private readonly AppDbContext _context;

        public CatEstadoProyectoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cat_EstadoProyecto>> ObtenerTodosAsync()
        {
            return await _context.Cat_EstadoProyecto.Where(p => !p.Eliminado)  // Filtrar por Eliminado igual a false
            .ToListAsync();
        }
    }
}
