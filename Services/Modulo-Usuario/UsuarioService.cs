
// UsuarioService.cs
using ArquiVision.Data;
using ArquiVision.Models;
using ArquiVision.Models.Modulo_Usuario;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Npgsql;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Options;
using ArquiVision.Migrations;
using ArquiVision.Models.Modulo_Material;
using System.Reflection.Metadata;
using System;
public class UsuarioService : IUsuarioService
{
    private readonly string _connectionString;
    private readonly IConfiguration _configuration;
    private readonly AppDbContext _context;

    public UsuarioService(IConfiguration configuration, IOptions<SmtpSettings> smtpSettings, AppDbContext context)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
        _configuration = configuration;
        _context = context;
       
    }

 
    public async Task<(UsuarioDTO usuario, int Error)> Register(UsuarioDTO userDto, string confirmationToken)
    {
        
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            
            using (var command = new NpgsqlCommand())
            {
                

                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = @"INSERT INTO public.""Usuarios""(
                    ""Eliminado"", ""Correo"", ""ContraseñaCifrada"", ""Nombre"", ""Apellido_Paterno"", ""Apellido_Materno"", ""Direccion"", ""Activo"", ""Edad"", ""IdTipoUsuario"", ""EmpresaPertenece"", ""UsuarioCreo"", ""FechaCreacion"", ""Intentos"", ""ConfirmationToken"")
                    VALUES (@Eliminado, @Correo, @ContraseñaCifrada, @Nombre, @Apellido_Paterno, @Apellido_Materno, @Direccion, @Activo, @Edad, @IdTipoUsuario, @EmpresaPertenece, @UsuarioCreo, @FechaCreacion, @Intentos, @ConfirmationToken);";

                command.Parameters.AddWithValue("@Eliminado", false);
                command.Parameters.AddWithValue("@Correo", userDto.Correo);
                command.Parameters.AddWithValue("@ContraseñaCifrada", CifrarContraseña(userDto.Contraseña));
                command.Parameters.AddWithValue("@Nombre", userDto.Nombre);
                command.Parameters.AddWithValue("@Apellido_Paterno", userDto.ApellidoPaterno);
                command.Parameters.AddWithValue("@Apellido_Materno", userDto.ApellidoMaterno);
                command.Parameters.AddWithValue("@Direccion", userDto.Direccion);
                command.Parameters.AddWithValue("@Activo", false);
                command.Parameters.AddWithValue("@Edad", userDto.Edad);
                command.Parameters.AddWithValue("@IdTipoUsuario", userDto.IdTipoUsuario); // Ajusta según sea necesario
                command.Parameters.AddWithValue("@EmpresaPertenece", userDto.EmpresaPertenece);
                command.Parameters.AddWithValue("@UsuarioCreo", "System"); // Ajusta según sea necesario
                command.Parameters.AddWithValue("@FechaCreacion", DateTime.Now);
                command.Parameters.AddWithValue("@Intentos", 0);
                command.Parameters.AddWithValue("@ConfirmationToken", confirmationToken);


                await command.ExecuteNonQueryAsync();

            }
           
        }
        
        //await SendConfirmationEmail(userDto.Correo, confirmationToken);

       
        return (userDto, 1);


    }





    public async Task<(Usuario, byte[] miContraseña)> Login(UsuarioLoginDTO loginDto)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            using (var command = new NpgsqlCommand())
            {
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = @"SELECT ""IdUsuario"", ""Correo"", ""Nombre"", ""Apellido_Paterno"", ""Apellido_Materno"", ""Direccion"", ""Edad"", ""IdTipoUsuario"", ""EmpresaPertenece"", ""Activo"", ""Intentos"", ""FechaIntento"", ""ContraseñaCifrada""
                                    FROM public.""Usuarios"" 
                                    WHERE ""Correo"" = @Correo 
                                    
                                    AND ""Eliminado"" = false  
                                    ";

                command.Parameters.AddWithValue("@Correo", loginDto.Correo);
               // command.Parameters.AddWithValue("@ContraseñaCifrada", CifrarContraseña(loginDto.Contraseña));

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        var usuario = new Usuario
                        {
                            IdUsuario = reader.GetInt32(0),
                            Correo = reader.GetString(1),
                            Nombre = reader.GetString(2),
                            Apellido_Paterno = reader.GetString(3),
                            Apellido_Materno = reader.GetString(4),
                            Direccion = reader.GetString(5),
                            Edad = reader.GetInt16(6),
                            IdTipoUsuario = reader.GetInt32(7),
                            EmpresaPertenece = reader.GetString(8),
                            Activo = reader.GetBoolean(9),
                            Intentos =  reader.GetInt32(10),
                            FechaIntento = reader.IsDBNull(11) ? (DateTime?)null : reader.GetDateTime(11),
                            ContraseñaCifrada = reader.GetFieldValue<byte[]>(12)
                        };

                        var miContra = CifrarContraseña(loginDto.Contraseña);
                        return (usuario, miContra);
                        
                       
                    }
                }
            }
        }
        return (null, null);
    }



    public string GenerateJwtToken(Usuario usuario, int userType)
    {
        var secretKey = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
        var securityKey = new SymmetricSecurityKey(secretKey);
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
        new Claim(JwtRegisteredClaimNames.Sub, usuario.Nombre),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        new Claim("userType", userType.ToString()),
        new Claim("nombre", usuario.Nombre+usuario.Apellido_Paterno)
        };
        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(180),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }



    private byte[] CifrarContraseña(string contraseña)
    {
        using (var sha256 = SHA256.Create())
        {
            return sha256.ComputeHash(Encoding.UTF8.GetBytes(contraseña));
        }
    }
    public class UsuarioLoginResponseDTO
    {
        public Usuario Usuario { get; set; }
        public string Token { get; set; }
    }
    public async Task<string[]> GetEmpresas()
    {
        var empresas = new List<string>();

        using (var connection = new NpgsqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            using (var command = new NpgsqlCommand())
            {
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = @"SELECT ""EmpresaPertenece"" FROM public.""Usuarios""
                                        WHERE ""Eliminado"" = false "; // Ajusta el nombre de la tabla y columna según tu esquema

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        empresas.Add(reader.GetString(0));
                    }
                }
            }
        }

        return empresas.ToArray();
    }
    public async Task<List<Usuario>> GetCorreosByEmpresa(string Empresa)
    {

        return  await _context.Usuarios
        .Where(u => u.EmpresaPertenece == Empresa && u.Eliminado==false)
        .ToListAsync();
    }

    public async Task<string[]> GetCorreos()
    {
        var empresas = new List<string>();

        using (var connection = new NpgsqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            using (var command = new NpgsqlCommand())
            {
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = @"SELECT ""Correo"" FROM public.""Usuarios""
                                        WHERE ""Eliminado"" = false "; // Ajusta el nombre de la tabla y columna según tu esquema

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        empresas.Add(reader.GetString(0));
                    }
                }
            }
        }

        return empresas.ToArray();
    }


    public async Task BloquearCuenta(int idUsuario, string token)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            using (var command = new NpgsqlCommand())
            {
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = @"
                UPDATE public.""Usuarios"" 
                SET ""Activo"" = false, 
                ""ConfirmationToken"" = @ConfirmationToken
                WHERE ""IdUsuario"" = @IdUsuario;
                ";
                command.Parameters.AddWithValue("@ConfirmationToken", token);
                command.Parameters.AddWithValue("@IdUsuario", idUsuario);
                await command.ExecuteNonQueryAsync();
            }
        }
    }

    public async Task<int> ValidacionIntentos(Usuario usuario, bool Correcto)
    {
        int intentos = usuario.Intentos;
        int castigo = 0;
        var horaActual = DateTime.Now;
        DateTime? fechaIntento = usuario.FechaIntento;

        if (intentos == 0 && !Correcto)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"
                UPDATE public.""Usuarios"" 
                SET ""Intentos"" = 1, 
                ""FechaIntento"" = @FechaIntento
                WHERE ""IdUsuario"" = @IdUsuario;
                ";
                    command.Parameters.AddWithValue("@FechaIntento", horaActual);
                    command.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                    await command.ExecuteNonQueryAsync();
                }
            }
            return 0;
        }

        if (fechaIntento.HasValue)
        {
            // Calcular el tiempo transcurrido desde el último intento
            TimeSpan tiempoTranscurrido = horaActual - fechaIntento.Value;

            if (intentos >= 3)
            {
                castigo = (intentos - 3) / 2;

                if (castigo == 1 && tiempoTranscurrido.TotalMinutes < 5)
                {
                    return 1; // Castigo de 5 minutos
                }
                if (castigo == 2 && tiempoTranscurrido.TotalMinutes < 10)
                {
                    return 2; // Castigo de 10 minutos
                }
                if (castigo >= 3)
                {
                  
                    return 3; // Castigo de bloqueo de cuenta
                }
            }
        }

        if (Correcto)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"
                UPDATE public.""Usuarios"" 
                SET ""Intentos"" = 0, ""FechaIntento"" = NULL 
                WHERE ""IdUsuario"" = @IdUsuario;
                ";
                    command.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                    await command.ExecuteNonQueryAsync();
                }
            }
            return 0;
        }
        else
        {
            intentos += 1;
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"
                UPDATE public.""Usuarios"" 
                SET ""Intentos"" = @Intentos, ""FechaIntento"" = @Fecha 
                WHERE ""IdUsuario"" = @IdUsuario;
                ";
                    command.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                    command.Parameters.AddWithValue("@Intentos", intentos);
                    command.Parameters.AddWithValue("@Fecha", horaActual);
                    await command.ExecuteNonQueryAsync();
                }
            }
            return 0;
        }
    }


    public async Task<int> GivePermission(int UserID, int Permiso)
    {

        var usuario = await _context.Usuarios
     .Where(u => u.IdUsuario == UserID)
     .FirstOrDefaultAsync();

        // Si el usuario no existe, puedes lanzar una excepción o devolver un valor indicativo
        if (usuario == null)
        {
            throw new Exception("Usuario no encontrado");
        }

        // Actualiza el permiso del usuario
        usuario.IdTipoUsuario = Permiso;
       

        // Guarda los cambios en la base de datos
        return await _context.SaveChangesAsync();
    }
    public async Task<int> EliminarUsuario(int UserID)
    {

        var usuario = await _context.Usuarios
     .Where(u => u.IdUsuario == UserID)
     .FirstOrDefaultAsync();

        // Si el usuario no existe, puedes lanzar una excepción o devolver un valor indicativo
        if (usuario == null)
        {
            throw new Exception("Usuario no encontrado");
        }

        // Actualiza el permiso del usuario
        
        usuario.Eliminado = true;

        // Guarda los cambios en la base de datos
        return await _context.SaveChangesAsync();
    }
    
}


