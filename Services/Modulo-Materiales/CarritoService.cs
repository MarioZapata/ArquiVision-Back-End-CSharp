using ArquiVision.Data;
using ArquiVision.Models.Modulo_Material;
using ArquiVision.Models.Modulo_Proyectos;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace ArquiVision.Services.Modulo_Materiales
{
    public interface ICarritoService
    {
        Task<CarritoDTO> AgregarAlCarritoAsync(CarritoDTO carritoDto);
        Task<List<Carrito>> ObtenerCarritosPorUsuarioAsync(int idUsuario);
        Task<CarritoDTO> AgregarAlCarrito(CarritoDTO carritoDto);
        Task<bool> updateCarrito(int idCarrito, int cantidad);
        Task<bool> eliminarCarrito(int idCarrito);
    }
    public class CarritoService : ICarritoService
    {
        private readonly AppDbContext _context;

        public CarritoService(AppDbContext context)
        {
            _context = context;
           
        }
        public async Task<bool> updateCarrito(int idCarrito, int cantidad)
        {
            var carritoExistente = await _context.Carritos.FindAsync(idCarrito);

            if (carritoExistente == null)
            {
              return false;
            }
            carritoExistente.Cantidad = cantidad;
            carritoExistente.Total = cantidad * carritoExistente.CostoIndividual;
            _context.Carritos.Update(carritoExistente);
            await _context.SaveChangesAsync();

            // Actualizar las propiedades del proyecto existente con los valores del DTO 
            return true;
        }
        public async Task<bool> eliminarCarrito(int idCarrito)
        {
            var carritoExistente = await _context.Carritos.FindAsync(idCarrito);

            if (carritoExistente == null)
            {
                return false;
            }
            carritoExistente.Eliminado = true;
            _context.Carritos.Update(carritoExistente);
            await _context.SaveChangesAsync();

            // Actualizar las propiedades del proyecto existente con los valores del DTO 
            return true;
        }
        public async Task<CarritoDTO> AgregarAlCarrito(CarritoDTO carritoDto)
        {
            Console.WriteLine(carritoDto);
            Console.WriteLine(carritoDto);
            Console.WriteLine(carritoDto);
            Console.WriteLine(carritoDto);
            Console.WriteLine(carritoDto);

            var resultados = await _context.Carritos
                .Where(p => p.IdUsuario == carritoDto.IdUsuario && p.Eliminado==false && p.IdProducto==carritoDto.IdProducto)
                .ToListAsync();
            if (resultados.Count!=0)
            {
                return null;
            }
         

            var sql = @"
            INSERT INTO public.""Carritos""(
                ""Eliminado"", ""IdProducto"", ""Nombre"", ""Cantidad"", ""CostoIndividual"", 
                ""Total"", ""UsuarioCreo"", ""FechaCreacion"", ""IdUsuario"")
            VALUES (
                @Eliminado, @IdProducto, @Nombre, @Cantidad, @CostoIndividual, 
                @Total, @UsuarioCreo, @FechaCreacion, @IdUsuario);";

            var parameters = new[]
            {
                new NpgsqlParameter("@Eliminado", carritoDto.Eliminado),
                new NpgsqlParameter("@IdProducto", carritoDto.IdProducto),
                new NpgsqlParameter("@Nombre", carritoDto.Nombre),
                new NpgsqlParameter("@Cantidad", carritoDto.Cantidad),
                new NpgsqlParameter("@CostoIndividual", carritoDto.CostoIndividual),
                new NpgsqlParameter("@Total", carritoDto.Total),
                new NpgsqlParameter("@UsuarioCreo", carritoDto.UsuarioCreo),
                new NpgsqlParameter("@FechaCreacion", DateTime.Now),
                new NpgsqlParameter("@IdUsuario", carritoDto.IdUsuario)
            };

            try
            {
                int rowsAffected = await _context.Database.ExecuteSqlRawAsync(sql, parameters);
                return carritoDto;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al agregar al carrito ");
            }


        }

        public async Task<CarritoDTO> AgregarAlCarritoAsync(CarritoDTO carritoDto)
        {
            var sql = @"
            INSERT INTO public.""Carritos""(
                ""Eliminado"", ""IdProducto"", ""Nombre"", ""Cantidad"", ""CostoIndividual"", 
                ""Total"", ""UsuarioCreo"", ""FechaCreacion"", ""IdUsuario"")
            VALUES (
                @Eliminado, @IdProducto, @Nombre, @Cantidad, @CostoIndividual, 
                @Total, @UsuarioCreo, @FechaCreacion, @IdUsuario);";

            var parameters = new[]
            {
                new NpgsqlParameter("@Eliminado", carritoDto.Eliminado),
                new NpgsqlParameter("@IdProducto", carritoDto.IdProducto),
                new NpgsqlParameter("@Nombre", carritoDto.Nombre),
                new NpgsqlParameter("@Cantidad", carritoDto.Cantidad),
                new NpgsqlParameter("@CostoIndividual", carritoDto.CostoIndividual),
                new NpgsqlParameter("@Total", carritoDto.Total),
                new NpgsqlParameter("@UsuarioCreo", carritoDto.UsuarioCreo),
                new NpgsqlParameter("@FechaCreacion", DateTime.Now),
                new NpgsqlParameter("@IdUsuario", carritoDto.IdUsuario)
            };

            try
            {
                int rowsAffected = await _context.Database.ExecuteSqlRawAsync(sql, parameters);
                return carritoDto;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al agregar al carrito: {ex.Message}");
            }
        }



        public async Task<List<Carrito>> ObtenerCarritosPorUsuarioAsync(int IdUsuario)
        {
            return await _context.Carritos
                .Where(c => c.IdUsuario == IdUsuario && c.Eliminado==false)
                .Select(c => new Carrito
                {
                    IdCarrito = c.IdCarrito,
                    Eliminado = c.Eliminado,
                    IdProducto = c.IdProducto,
                    Nombre = c.Nombre,
                    Cantidad = c.Cantidad,
                    CostoIndividual = c.CostoIndividual,
                    Total = c.Total,
                    UsuarioCreo = c.UsuarioCreo,
                    FechaCreacion = c.FechaCreacion,
                    IdUsuario = c.IdUsuario
                })
                .ToListAsync();
        }

    }
}
    