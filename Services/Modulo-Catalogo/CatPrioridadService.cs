using ArquiVision.Data;
using ArquiVision.Models.Catalogos;
using Microsoft.EntityFrameworkCore;

namespace ArquiVision.Services.Modulo_Catalogo
{
   
    public interface ICatPrioridadService
    {
        Task<List<Cat_Prioridad>> ObtenerTodosAsync();
    }

    public class CatPrioridadService : ICatPrioridadService
    {
        private readonly AppDbContext _context;

        public CatPrioridadService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cat_Prioridad>> ObtenerTodosAsync()
        {
            return await _context.Cat_Prioridad.Where(p => !p.Eliminado)  // Filtrar por Eliminado igual a false
            .ToListAsync();
        }
    }
}
