using ArquiVision.Data;
using ArquiVision.Models.Catalogos;
using Microsoft.EntityFrameworkCore;

namespace ArquiVision.Services.Modulo_Catalogo
{

    public interface ICatTipoUsuarioService
    {
        Task<List<Cat_TipoUsuario>> ObtenerTodosAsync();
    }

    public class CatTipoUsuarioService : ICatTipoUsuarioService
    {
        private readonly AppDbContext _context;

        public CatTipoUsuarioService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cat_TipoUsuario>> ObtenerTodosAsync()
        {
            return await _context.Cat_TipoUsuario.Where(p => !p.Eliminado).ToListAsync();
        }
    }

}
