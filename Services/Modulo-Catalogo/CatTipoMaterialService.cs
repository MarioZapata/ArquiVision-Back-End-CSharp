using ArquiVision.Data;
using ArquiVision.Models.Catalogos;
using Microsoft.EntityFrameworkCore;


namespace ArquiVision.Services.Modulo_Catalogo
{
   
    public interface ICatTipoMaterialService
    {
        Task<List<Cat_TipoMaterial>> ObtenerTodosAsync();
    }

    public class CatTipoMaterialService : ICatTipoMaterialService
    {
        private readonly AppDbContext _context;

        public CatTipoMaterialService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cat_TipoMaterial>> ObtenerTodosAsync()
        {
            return await _context.Cat_TipoMaterials.Where(p => !p.Eliminado)  // Filtrar por Eliminado igual a false
            .ToListAsync();
        }
    }
}
