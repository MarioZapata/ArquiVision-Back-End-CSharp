using ArquiVision.Models;
using ArquiVision.Models.Modulo_Actividades;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using ArquiVision.Data;
using Microsoft.AspNetCore.Mvc;
using ArquiVision.Migrations;
using ArquiVision.Models.Modulo_Proyectos;
using AutoMapper;
using System.IdentityModel.Tokens.Jwt;
using Newtonsoft.Json.Linq;
using System.Globalization;
using Newtonsoft.Json;


namespace ArquiVision.Services.Modulo_Actividades
{
    public class ActividadService
    {

     
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly MetodosReutilzables _metodos;
        public ActividadService(AppDbContext context, IMapper mapper, MetodosReutilzables metodos)
        {
            _context = context;
            _mapper = mapper;
            _metodos = metodos;
        }
        public async Task<bool> DeleteActividad(int id, string name)
        {
            var actividadExistencia = await _context.Actividades.FindAsync(id);
            if (actividadExistencia == null || actividadExistencia.Eliminado == true )
            {
                return false;
            }
            else
            {
                actividadExistencia.Eliminado = true;
                actividadExistencia.FechaEliminacion = _metodos.obtenerFecha();
                actividadExistencia.UsuarioElimino = name;
                await _context.SaveChangesAsync();
                return true;
            }
        }
        public async Task<Actividad> updateActividadAsync(int id, string name,ActividadDTO actividad)
        {
            var actividadExistencia = await _context.Actividades.FindAsync(id);
            if (actividadExistencia == null || actividadExistencia.Eliminado == true)
            {
                throw new Exception("Actividad no encontrada.");
            }
          
            try
            {
                _mapper.Map(actividad, actividadExistencia);
                // Aquí deberías mapear propiedades del DTO al modelo
                try
                {
                    var fecha = _metodos.obtenerFecha();
                    var cambio = new
                    {
                        Fecha = fecha,
                        Usuario = name,
                        Cambio = "Edicion"
                    };

                    actividadExistencia.FechaModificacion = fecha;
                    // Convertir el objeto a JSON
                    string cambioJson = JsonConvert.SerializeObject(cambio);

                    // Si ya hay cambios anteriores en UsuarioModifico, agrega el nuevo cambio
                    if (string.IsNullOrEmpty(actividadExistencia.UsuarioModifico))
                    {
                        // Si es el primer cambio, guarda solo este cambio
                        actividadExistencia.UsuarioModifico = cambioJson;
                    }
                    else
                    {
                        // Si ya hay un registro de cambios, combínalo con los cambios previos
                        actividadExistencia.UsuarioModifico = actividadExistencia.UsuarioModifico + "," + cambioJson;
                    }
                    await _context.SaveChangesAsync();
                    return actividadExistencia;

                }
                catch (Exception ex)
                {
                    throw new Exception("Error en subida" + ex.Message);

                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error en el mapperError en el mapper " + ex.Message);
            }

        }
        public async Task<bool> ValidarProyecto(int id)
        {
            var proyecto = await _context.Proyectos.FindAsync(id);
            if (proyecto.Eliminado == true || proyecto.IdEstadoProyecto == 5)
            {
                return false;
            }
            return true;
        }
        public async Task<ActividadDTO> AddActividadAsync(ActividadDTO actividad)
        {
            

            var sql = @"
        INSERT INTO public.""Actividades""(
            ""Eliminado"", ""IdTipoActividad"", ""IdEstadoActividad"",
            ""Nombre"", ""Encargado"", ""Asignado"", ""IdPrioridad"", ""FechaInicio"", ""FechaFin"",
            ""EsCompraDeMateriales"", ""IdPedido"", ""EmpresaEncargada"", ""IdProyecto"",
            ""IdDocumento"", ""UsuarioCreo"", ""FechaCreacion"")
        VALUES (
            @Eliminado, @IdTipoActividad, @IdEstadoActividad,
            @Nombre, @Encargado, @Asignado, @IdPrioridad, @FechaInicio, @FechaFin,
            @EsCompraDeMateriales, @IdPedido, @EmpresaEncargada, @IdProyecto,
            @IdDocumento, @UsuarioCreo,@FechaCreacion);";

            var parameters = new[]
            {
        new Npgsql.NpgsqlParameter("@Eliminado", actividad.Eliminado),
        //new Npgsql.NpgsqlParameter("@IdEstadoProyecto", actividad.IdEstadoProyecto),
        new Npgsql.NpgsqlParameter("@IdTipoActividad", actividad.IdTipoActividad),
        new Npgsql.NpgsqlParameter("@IdEstadoActividad", actividad.IdEstadoActividad),
        new Npgsql.NpgsqlParameter("@Nombre", actividad.Nombre),
        new Npgsql.NpgsqlParameter("@Encargado", actividad.Encargado),
        new Npgsql.NpgsqlParameter("@Asignado", actividad.Asignado),
        new Npgsql.NpgsqlParameter("@IdPrioridad", actividad.IdPrioridad),
        new Npgsql.NpgsqlParameter("@FechaInicio", actividad.FechaInicio),
        new Npgsql.NpgsqlParameter("@FechaFin", actividad.FechaFin),
        new Npgsql.NpgsqlParameter("@EsCompraDeMateriales", actividad.EsCompraDeMateriales),
        new Npgsql.NpgsqlParameter("@IdPedido", actividad.IdPedido ?? (object)DBNull.Value), // Permitir valor nulo
        new Npgsql.NpgsqlParameter("@EmpresaEncargada", actividad.EmpresaEncargada),
       
        new Npgsql.NpgsqlParameter("@IdProyecto", actividad.IdProyecto),
        new Npgsql.NpgsqlParameter("@IdDocumento", actividad.IdDocumento ?? (object)DBNull.Value), // Permitir valor nulo
        new Npgsql.NpgsqlParameter("@UsuarioCreo", actividad.UsuarioCreo),
        new Npgsql.NpgsqlParameter("@FechaCreacion", DateTime.Now),
    };

            try
            {
                // Ejecutar la consulta SQL
                int rowsAffected = await _context.Database.ExecuteSqlRawAsync(sql, parameters);
                return actividad;
            }
            catch (Exception ex)
            {
                // Manejar el error según sea necesario
                Console.WriteLine($"Error al insertar la actividad: {ex.Message}");
                throw; // Opcional: relanzar la excepción para manejarla en niveles superiores
            }
        }
        public async Task<List<Actividad>> GetActividadByEmpresa(string Empresa, int idProyecto)
        {
            return await _context.Actividades
                .Where(p => !p.Eliminado && p.EmpresaEncargada == Empresa && p.IdProyecto == idProyecto )  // Filtrar por Eliminado igual a false
                .ToListAsync();
        }
        public async Task<List<Actividad>> GetActividades(string Empresa)
        {
            return await _context.Actividades
                .Where(p => !p.Eliminado && p.EmpresaEncargada == Empresa )  // Filtrar por Eliminado igual a false
                .ToListAsync();
        }
        public async Task<bool> DarVoBo(int id, string name)
        {
            var actividadExistencia = await _context.Actividades.FindAsync(id);
            if (actividadExistencia == null || actividadExistencia.Eliminado==true 
                || actividadExistencia.IdEstadoActividad==4
                || actividadExistencia.IdEstadoActividad == 5

                )
            {
                return false;
            }
            else
            {
                var fecha = _metodos.obtenerFecha();
                actividadExistencia.IdEstadoActividad = 3;
                actividadExistencia.FechaModificacion = fecha;

                var cambio = new
                {
                    Fecha = fecha,
                    Usuario = name,
                    Cambio = "VOBO"
                };

                // Convertir el objeto a JSON
                string cambioJson = JsonConvert.SerializeObject(cambio);

                // Si ya hay cambios anteriores en UsuarioModifico, agrega el nuevo cambio
                if (string.IsNullOrEmpty(actividadExistencia.UsuarioModifico))
                {
                    // Si es el primer cambio, guarda solo este cambio
                    actividadExistencia.UsuarioModifico = cambioJson;
                }
                else
                {
                    // Si ya hay un registro de cambios, combínalo con los cambios previos
                    actividadExistencia.UsuarioModifico = actividadExistencia.UsuarioModifico + "," + cambioJson;
                }


                await _context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> DarFirma(int id, string name)
        {
            var actividadExistencia = await _context.Actividades.FindAsync(id);
            if (actividadExistencia == null || actividadExistencia.Eliminado == true
                || actividadExistencia.IdEstadoActividad == 4
                || actividadExistencia.IdEstadoActividad == 5
                || actividadExistencia.IdEstadoActividad != 3
                )
            {
                return false;
            }
            else
            {
              
                var fecha = _metodos.obtenerFecha();
                actividadExistencia.IdEstadoActividad = 4;
                actividadExistencia.FechaModificacion = fecha;

                var cambio = new
                {
                    Fecha = fecha,
                    Usuario = name,
                    Cambio = "Firma"
                };

                // Convertir el objeto a JSON
                string cambioJson = JsonConvert.SerializeObject(cambio);

                // Si ya hay cambios anteriores en UsuarioModifico, agrega el nuevo cambio
                if (string.IsNullOrEmpty(actividadExistencia.UsuarioModifico))
                {
                    // Si es el primer cambio, guarda solo este cambio
                    actividadExistencia.UsuarioModifico = cambioJson;
                }
                else
                {
                    // Si ya hay un registro de cambios, combínalo con los cambios previos
                    actividadExistencia.UsuarioModifico = actividadExistencia.UsuarioModifico + "," + cambioJson;
                }


                await _context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> DarCancelacion(int id, string name)
        {
            var actividadExistencia = await _context.Actividades.FindAsync(id);
            if (actividadExistencia == null || actividadExistencia.Eliminado == true)
            {
                return false;
            }
            else
            {

                var fecha = _metodos.obtenerFecha();
                actividadExistencia.IdEstadoActividad = 5;
                actividadExistencia.FechaModificacion = fecha;

                var cambio = new
                {
                    Fecha = fecha,
                    Usuario = name,
                    Cambio = "Cancelar"
                };

                // Convertir el objeto a JSON
                string cambioJson = JsonConvert.SerializeObject(cambio);

                // Si ya hay cambios anteriores en UsuarioModifico, agrega el nuevo cambio
                if (string.IsNullOrEmpty(actividadExistencia.UsuarioModifico))
                {
                    // Si es el primer cambio, guarda solo este cambio
                    actividadExistencia.UsuarioModifico = cambioJson;
                }
                else
                {
                    // Si ya hay un registro de cambios, combínalo con los cambios previos
                    actividadExistencia.UsuarioModifico = actividadExistencia.UsuarioModifico + "," + cambioJson;
                }


                await _context.SaveChangesAsync();
                return true;
            }
        }


        public async Task<ActionResult<List<Actividad>>> getAcividadByFilters(ActividadFilters filtros)
        {
            var query = _context.Actividades.AsQueryable();

            // Filtra por empresa si se proporciona
            if (!string.IsNullOrEmpty(filtros.EmpresaEncargada))
            {
                query = query.Where(p => p.EmpresaEncargada == filtros.EmpresaEncargada);
            }
            if(filtros.IdActividad != null)
            {
                query = query.Where(p => p.IdActividad == filtros.IdActividad);
            }
            // Filtra por nombre si se proporciona
            if (!string.IsNullOrEmpty(filtros.Encargado))
            {
                query = query.Where(p => p.Encargado.Contains(filtros.Encargado));
            }
            if (filtros.IdTipoActividad.HasValue)
            {
                query = query.Where(p => p.IdTipoActividad == filtros.IdTipoActividad.Value);
            }
            // Filtra por nombre si se proporciona
            if (!string.IsNullOrEmpty(filtros.Nombre))
            {
                query = query.Where(p => p.Nombre.Contains(filtros.Nombre));
            }

            // Filtra por idEstadoProyecto si se proporciona
            if (filtros.IdEstadoActividad.HasValue)
            {
                query = query.Where(p => p.IdEstadoActividad == filtros.IdEstadoActividad.Value);
            }

            if (filtros.IdPrioridad.HasValue)
            {
                query = query.Where(p => p.IdPrioridad == filtros.IdPrioridad.Value);
            }

            if (filtros.EsCompraDeMateriales != null)
            {
                query = query.Where(p => p.EsCompraDeMateriales == filtros.EsCompraDeMateriales.Value);
            }

            // Filtra por fechaInicio si se proporciona

            if (filtros.FechaInicio.HasValue)
            {

                query = query.Where(p => p.FechaInicio == filtros.FechaInicio.Value);
            }

            // Filtra por fechaFinal si se proporciona
            if (filtros.FechaFin.HasValue)
            {
                query = query.Where(p => p.FechaFin <= filtros.FechaFin.Value);
            }

            // Filtra por proyectos no eliminados
            query = query.Where(p => p.Eliminado == false);

            return await query.ToListAsync();
        }


    }
   

}
