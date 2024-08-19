using ArquiVision.Data;
using ArquiVision.Migrations;
using ArquiVision.Models;
using ArquiVision.Models.Modulo_Material;
using ArquiVision.Models.Modulo_Pedido;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using static ArquiVision.Controller.Modulo_Materiales.PedidoController;

namespace ArquiVision.Services.Modulo_Materiales
{
    public interface IPedidoService
    {

        Task<Pedido> CrearPedido(PedidoDTO pedidoDto);
        Task<List<Pedido>> ObtenerTodosAsync(string Empresa);
        Task<List<Pedido>> obtenerPedidoPorEmpresaOId(PedidoCTO cto);
        Task<List<Actividad>> validarPedidoAct(int id);
        Task<bool> deletePedido(int id, string name);

    }
    public class PedidoService : IPedidoService
    {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly MetodosReutilzables _metodos;

        public PedidoService(AppDbContext context, IMapper mapper, MetodosReutilzables metodos)
        {
              _context = context;
              _mapper = mapper;
            _metodos = metodos;

        }
        public async Task<List<Actividad>> validarPedidoAct(int id)
        {
            try
            {
                return await _context.Actividades
               .Where(p => !p.Eliminado && p.IdPedido == id)  // Filtrar por Eliminado igual a false
               .ToListAsync();
            }
            catch
            {
                throw new Exception("Ocurrió un error al crear el pedido.");
            }
        }
        public async Task<bool> deletePedido(int id, string name)
        {
            var pedidoExistente = await _context.Pedidos.FindAsync(id);

            if (pedidoExistente == null || pedidoExistente.Eliminado==true)
            {
                return false;
            }
            else
            {
                var actividads = await _context.Actividades
               .Where(p => !p.Eliminado && p.IdPedido == id)  // Filtrar por Eliminado igual a false
               .ToListAsync();

                if (actividads != null)
                {
                    foreach (var item in actividads)
                    {
                        item.IdEstadoActividad = 5;
                        _context.Update(item);
                    }
                }
                pedidoExistente.Eliminado = true;
                pedidoExistente.UsuarioElimino = name;
                pedidoExistente.FechaEliminacion = _metodos.obtenerFecha();
                try
                {
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
        }
        public async Task<Pedido> CrearPedido(PedidoDTO pedido)
        {


       

            pedido.FechaCreacion = _metodos.obtenerFecha();

            if (pedido == null)
            {
                throw new ArgumentNullException(nameof(pedido), "El pedido no puede ser nulo.");
            }


            try
            {
                var pedidoR = _mapper.Map<Pedido>(pedido);

                // Agregar el pedido al contexto
                _context.Pedidos.Add(pedidoR);
                await _context.SaveChangesAsync();
                return pedidoR;
            }
            catch (Exception ex)
            {
                // Manejar otras excepciones generales
                throw new Exception("Ocurrió un error al crear el pedido.", ex);
            }


        }
        public async Task<List<Pedido>> ObtenerTodosAsync(string Empresa)
        {
            return await _context.Pedidos
                .Where(p => !p.Eliminado && p.EmpresaEncargada==Empresa)  // Filtrar por Eliminado igual a false
                .ToListAsync();
        }
        public async Task<List<Pedido>> obtenerPedidoPorEmpresaOId(PedidoCTO cto)
        {
            
            var query = _context.Pedidos.AsQueryable();

            // Filtra por empresa si se proporciona
            if (!string.IsNullOrEmpty(cto.nombre))
            {
                query = query.Where(p => p.NombreDelPedido.Contains(cto.nombre));
            }
            if (cto.idPedido.HasValue)
            {
                query = query.Where(p => p.IdPedido == cto.idPedido);
            }
            query = query.Where(p => p.Eliminado == false);

            return await query.ToListAsync();

        }



    }


}

