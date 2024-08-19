using ArquiVision.Data;
using ArquiVision.Models;
using ArquiVision.Models.Catalogos;
using Microsoft.EntityFrameworkCore;


namespace ArquiVision.Services
{
    public interface ICatTipoConstruccionService
    {
        Task<List<Cat_TipoConstruccion>> ObtenerTodosAsync();
    }

    public class CatTipoConstruccionService : ICatTipoConstruccionService
    {
        private readonly AppDbContext _context;

        public CatTipoConstruccionService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cat_TipoConstruccion>> ObtenerTodosAsync()
        {
            return await _context.Cat_TipoConstruccions.Where(p => !p.Eliminado)  // Filtrar por Eliminado igual a false
            .ToListAsync();
        }
    }


}
