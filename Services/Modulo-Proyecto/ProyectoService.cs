using ArquiVision.Data;
using ArquiVision.Migrations;
using ArquiVision.Models;
using ArquiVision.Models.Modulo_Material;
using ArquiVision.Models.Modulo_Proyectos;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Globalization;
using System.Linq;

namespace ArquiVision.Services
{
    public class ProyectoService
    {

        private readonly AppDbContext _context;
        private readonly MetodosReutilzables _metodos;

        public ProyectoService(AppDbContext context, MetodosReutilzables metodos)
        {
            _context = context;
            _metodos = metodos;
        }

        public async Task<IEnumerable<Proyecto>> GetProyectosByEmpresa(string Empresa)
        {
            return await _context.Proyectos.Where(u => u.EmpresaEncargada == Empresa && u.Eliminado == false)
            .ToListAsync(); ;
        }
        public async Task<bool> cambiarEstado(int id, string name, int idCambio)
        {
            var proyecto = await _context.Proyectos.FindAsync(id);
            if (proyecto == null)
            {
                return false;
            }
            var fecha = _metodos.obtenerFecha();
            proyecto.IdEstadoProyecto = idCambio;
            proyecto.FechaModificacion = fecha;

            var cambio = new
            {
                Fecha = fecha,
                Usuario = name,
                Cambio = "Cambio a:"+idCambio
            };

            proyecto.FechaModificacion = fecha;
            // Convertir el objeto a JSON
            string cambioJson = JsonConvert.SerializeObject(cambio);

            // Si ya hay cambios anteriores en UsuarioModifico, agrega el nuevo cambio
            if (string.IsNullOrEmpty(proyecto.UsuarioModifico))
            {
                // Si es el primer cambio, guarda solo este cambio
                proyecto.UsuarioModifico = cambioJson;
            }
            else
            {
                // Si ya hay un registro de cambios, combínalo con los cambios previos
                proyecto.UsuarioModifico = proyecto.UsuarioModifico + "," + cambioJson;
            }
            _context.Proyectos.Update(proyecto);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<bool> DeleteProyecto(int id, string name)
        {
            var proyecto = await _context.Proyectos.FindAsync(id);
            if (proyecto == null)
            {
                return false;
            }
            proyecto.Eliminado = true;
            proyecto.FechaEliminacion = _metodos.obtenerFecha();
            proyecto.UsuarioElimino = name;
            
            
            _context.Proyectos.Update(proyecto);
            await _context.SaveChangesAsync();
            return true;
        }
        
        public async Task<IEnumerable<Proyecto>> getProyectoByIdName(string Empresa, int? Id, string? Nombre )
        {
            var query = _context.Proyectos
                      .Where(u => u.EmpresaEncargada == Empresa && u.Eliminado == false);

            // Filtrar por id si se proporciona
            if (Id.HasValue)
            {
                query = query.Where(u => u.IdProyecto == Id.Value);
            }

            // Filtrar por nombre si se proporciona
            if (!string.IsNullOrEmpty(Nombre))
            {
                query = query.Where(u => u.Nombre.Contains(Nombre));
            }
            var resultados = await query.ToListAsync();

            // Verificar si se encontraron resultados
            if (resultados.Count == 0)
            {
                return null;
            }

            return resultados;
        }
        public async Task<IEnumerable<Proyecto>> GetProyectosByFiltros(
        string empresa = null,
        string? nombre = null,
        string? encargado = null,
        string? municipio = null,
        string? estado = null,
        int? cp = null,
        int? idEstadoProyecto = null,
        int? idTipoConstruccion =null,
        DateTimeOffset? fechaInicio = null,
        DateTime? fechaFinal = null)
        {
            var query = _context.Proyectos.AsQueryable();

            // Filtra por empresa si se proporciona
            if (!string.IsNullOrEmpty(empresa))
            { 
                query = query.Where(p => p.EmpresaEncargada == empresa);
            }

            // Filtra por nombre si se proporciona
            if (!string.IsNullOrEmpty(encargado))
            {
                query = query.Where(p => p.Encargado.Contains(encargado));
            }
            if (idTipoConstruccion.HasValue)
            {
                query = query.Where(p => p.Id_TipoConstruccion==idTipoConstruccion.Value);
            }
            // Filtra por nombre si se proporciona
            if (!string.IsNullOrEmpty(nombre))
            {
                query = query.Where(p => p.Nombre.Contains(nombre));
            }

            // Filtra por idEstadoProyecto si se proporciona
            if (idEstadoProyecto.HasValue)
            {
                query = query.Where(p => p.IdEstadoProyecto == idEstadoProyecto.Value);
            }

            if (!string.IsNullOrEmpty(estado))
            {
                query = query.Where(p => p.Estado == estado);
            }

            if (!string.IsNullOrEmpty(municipio))
            {
                query = query.Where(p => p.Municipio == municipio);
            }

            if (cp.HasValue)
            {
                query = query.Where(p => p.CP == cp.Value);
            }

            // Filtra por fechaInicio si se proporciona

            if (fechaInicio.HasValue)
            {
                
            query = query.Where(p => p.FechaInicio == fechaInicio.Value);
            }

            // Filtra por fechaFinal si se proporciona
            if (fechaFinal.HasValue)
            {
                query = query.Where(p => p.FechaFin <= fechaFinal.Value);
            }

            // Filtra por proyectos no eliminados
            query = query.Where(p => p.Eliminado == false);

            return await query.ToListAsync();
        }
        public async Task<bool> ActulizarProyecto(ProyectoDTOM proyectoDto)
        {
            var proyectoExistente = await _context.Proyectos.FindAsync(proyectoDto.IdProyecto);

            if (proyectoExistente == null)
            {
                return false;
            }

            // Actualizar las propiedades del proyecto existente con los valores del DTO
            proyectoExistente.Nombre = proyectoDto.Nombre;
            proyectoExistente.Id_TipoConstruccion = proyectoDto.Id_TipoConstruccion;
            proyectoExistente.Encargado = proyectoDto.Encargado;
            proyectoExistente.Estado = proyectoDto.Estado;
            proyectoExistente.Municipio = proyectoDto.Municipio;
            proyectoExistente.CP = proyectoDto.CP;
            proyectoExistente.FechaInicio = proyectoDto.FechaInicio;
            proyectoExistente.FechaFin = proyectoDto.FechaFin;
            proyectoExistente.IdEstadoProyecto = proyectoDto.IdEstadoProyecto;
           // proyectoExistente.EmpresaEncargada = proyectoDto.EmpresaEncargada;
            proyectoExistente.UsuarioCreo = proyectoDto.UsuarioCreo;
           // proyectoExistente.UsuarioElimino = proyectoDto.UsuarioElimino;
            proyectoExistente.UsuarioModifico = proyectoDto.UsuarioModifico;
          //  proyectoExistente.FechaCreacion = proyectoDto.FechaCreacion;
           // proyectoExistente.FechaEliminacion = proyectoDto.FechaEliminacion;
            proyectoExistente.FechaModificacion = _metodos.obtenerFecha();

            _context.Proyectos.Update(proyectoExistente);
            await _context.SaveChangesAsync();

            return true;
        }


        public async Task<ProyectoDTO> AddProyectoAsync(ProyectoDTO proyecto)
        {
            var sql = @"
              INSERT INTO public.""Proyectos""(
                  ""Eliminado"", ""Id_TipoConstruccion"", ""Encargado"", ""Nombre"", 
                  ""IdEstadoProyecto"", ""Estado"", ""Municipio"", ""CP"", ""FechaInicio"", ""FechaFin"", 
                  ""EmpresaEncargada"", ""UsuarioCreo"", ""FechaCreacion"")
              VALUES (@Eliminado, @Id_TipoConstruccion, @Encargado, @Nombre, 
                      @IdEstadoProyecto, @Estado, @Municipio, @CP, @FechaInicio, @FechaFin, 
                      @EmpresaEncargada, @UsuarioCreo, @FechaCreacion);"; // Cierra el paréntesis y añade un punto y coma

            var parameters = new[]
            {
                new Npgsql.NpgsqlParameter("@Eliminado", proyecto.Eliminado),
                new Npgsql.NpgsqlParameter("@Id_TipoConstruccion", proyecto.Id_TipoConstruccion),
                new Npgsql.NpgsqlParameter("@Encargado", proyecto.Encargado),
                new Npgsql.NpgsqlParameter("@Nombre", proyecto.Nombre),
                new Npgsql.NpgsqlParameter("@IdEstadoProyecto", proyecto.IdEstadoProyecto),
                new Npgsql.NpgsqlParameter("@Estado", proyecto.Estado),
                new Npgsql.NpgsqlParameter("@Municipio", proyecto.Municipio),
                new Npgsql.NpgsqlParameter("@CP", proyecto.CP),
                new Npgsql.NpgsqlParameter("@FechaInicio", proyecto.FechaInicio),
                new Npgsql.NpgsqlParameter("@FechaFin", proyecto.FechaFin),
                new Npgsql.NpgsqlParameter("@EmpresaEncargada", proyecto.EmpresaEncargada),
                new Npgsql.NpgsqlParameter("@UsuarioCreo", proyecto.UsuarioCreo),
                new Npgsql.NpgsqlParameter("@FechaCreacion", DateTime.Now)
            
            };

            try
            {
                // Ejecutar la consulta SQL
                int rowsAffected = await _context.Database.ExecuteSqlRawAsync(sql, parameters);
                return proyecto;
            }
            catch (Exception ex)
            {
                // Manejar el error según sea necesario
                Console.WriteLine($"Error al insertar el proyecto: {ex.Message}");
                throw; // Opcional: relanzar la excepción para manejarla en niveles superiores
                
            }
        }





    }


}