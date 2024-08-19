using ArquiVision.Data;
using ArquiVision.Models;
using ArquiVision.Models.Modulo_Material;
using ArquiVision.Models.Modulo_Pedido;
using ArquiVision.Models.Modulo_Proyectos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;


namespace ArquiVision.Services.Modulo_Materiales
{
  
    public interface IProductoService
    {
       
        Task<List<Producto>> ObtenerTodosAsync();
        Task<List<Producto>> ObtenerProductosUsuario(int IdUsuario);
        Task<bool> ProductoVenta(ProductoVentaDTO ventaDTO);
        Task<bool> hacerVenta(int idUsuario, int idPedido);
        Task<List<ProductoVenta>> getProductoByPedido(int id);
    }
   

    public class ProductoService : IProductoService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly MetodosReutilzables _metodos;

        public ProductoService(AppDbContext context, IMapper mapper, MetodosReutilzables metodos)
        {
            _context = context;
            _mapper = mapper;
            _metodos = metodos;
        }

        public async Task<bool> hacerVenta(int idUsuario, int idPedido)
        {
         
            var carritos = await _context.Carritos
               .Where(p => !p.Eliminado && p.IdUsuario == idUsuario)
               .ToListAsync();


            //ventaDTO.FechaCreacion = dateTime;
            for (int i = 0; i < carritos.Count; i++)
            {
                var vto = new ProductoVentaDTO();
                vto.Eliminado = false;
                vto.IdPedido = idPedido;
                vto.NombreMaterial = carritos[i].Nombre;
                vto.Cantidad = carritos[i].Cantidad;
                vto.CostoIndividual = carritos[i].CostoIndividual;
                vto.Total = carritos[i].Total;
                vto.FechaCreacion = _metodos.obtenerFecha();
                vto.UsuarioCreo = carritos[i].UsuarioCreo;
                try
                {
                    var pedidoR = _mapper.Map<ProductoVenta>(vto);

                    // Agregar el pedido al contexto
                    _context.ProductoVentas.Add(pedidoR);
                    await _context.SaveChangesAsync();
                    
                }
                catch (Exception ex)
                {
                    // Manejar otras excepciones generales
                    throw new Exception("Ocurrió un error al crear el pedido.", ex);
                }
            }
            // Guardar los cambios en ProductoVentas
            await _context.SaveChangesAsync();

            // Eliminar los elementos del carrito
            foreach (var carrito in carritos)
            {
                carrito.Eliminado = true; 
            }

            // Guardar los cambios en Carritos
            await _context.SaveChangesAsync();

            return true;
        }
        


          


        public async Task<bool> ProductoVenta([FromBody]ProductoVentaDTO ventaDTO)
        {


            
            ventaDTO.FechaCreacion = _metodos.obtenerFecha();

            if (ventaDTO == null)
            {
                throw new ArgumentNullException(nameof(ventaDTO), "El pedido no puede ser nulo.");
            }


            try
            {
                var pedidoR = _mapper.Map<ProductoVenta>(ventaDTO);

                // Agregar el pedido al contexto
                _context.ProductoVentas.Add(pedidoR);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Manejar otras excepciones generales
                throw new Exception("Ocurrió un error al crear el pedido.", ex);
            }
        }
        public async Task<List<Producto>> ObtenerTodosAsync()
        {
            return await _context.Productos
                .Where(p => !p.Eliminado)  // Filtrar por Eliminado igual a false
                .ToListAsync();
        }

        public async Task<List<Producto>> ObtenerProductosUsuario(int IdUsuario)
        {
            var productos = await _context.Productos
               .Where(p => !p.Eliminado)
               .ToListAsync();

            var productosEnCarrito = await _context.Carritos
                .Where(c => c.IdUsuario == IdUsuario && !c.Eliminado)
                .Select(c => c.IdProducto)
                .ToListAsync();

            var productosNoEnCarrito = productos
                .Where(p => !productosEnCarrito.Contains(p.IdProducto))
                .ToList();


            return productosNoEnCarrito;
        }
        public async Task<List<ProductoVenta>> getProductoByPedido(int id)
        {
            var productos = await _context.ProductoVentas
                .Where (p => !p.Eliminado && p.IdPedido == id) 
                .ToListAsync();
            return productos;
        }
    }
}
