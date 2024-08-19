// UsuarioController.cs
using ArquiVision.Migrations;
using ArquiVision.Models;
using ArquiVision.Models.Modulo_Usuario;
using ArquiVision.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly UsuarioService _usuarioService;
    public readonly CorreoService _correoService;
    public class Mensaje
    {
        public int TipoMensaje { get; set; }
        public string TextoMensaje { get; set; }
    }
    public UsuariosController(UsuarioService usuarioService, CorreoService correoService)
    {
        _usuarioService = usuarioService;
        _correoService = correoService;
    }

    [Authorize(Policy = "UserTypePolicy")]
    [HttpGet("getUsuarioByEmpresa")]
    public async Task<ActionResult<List<Usuario>>> GetCorreosByEmpresa(string Empresa)
    {
        var usuarioEmpresas= await _usuarioService.GetCorreosByEmpresa(Empresa);
        return Ok(usuarioEmpresas);
    }


    [Authorize(Policy = "UserTypePolicy")]
    [HttpPatch("DarPermiso")]
    public async Task<IActionResult> GivePermission(int userID, int permiso)
    {
        try
        {
            var result = await _usuarioService.GivePermission(userID, permiso);
            if (result > 0)
            {
                var mensaje = new Mensaje
                {
                    TextoMensaje = "Se ha dado permiso de manera correcta."
                };
                return Ok(mensaje);
            }
            else
            {
                return StatusCode(500, "Se dio un error en el servidor");
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Se dio un error en el servidor");
        }
    }

    [Authorize(Policy = "UserTypePolicy")]
    [HttpPatch("EliminarUsuario")]
    public async Task<IActionResult> Eliminar(int userID)
    {
        try
        {
            var result = await _usuarioService.EliminarUsuario(userID);
            if (result > 0)
            {
                
                return Ok("Se elimino el usuario de manera correcta.");
            }
            else
            {
                return StatusCode(500, "Se dio un error en el servidor");
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Se dio un error en el servidor");
        }
    }



    [HttpGet("confirm")]
    public async Task<IActionResult> ConfirmEmail(string token)
    {
        try
        {
            var result = await _correoService.ConfirmEmail(token);
            if (result)
            {
                return Ok(new { message = "Correo electrónico confirmado exitosamente." });
            }
            else
            {
                return BadRequest("Token de confirmación inválido o usuario ya activado.");
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error al confirmar el correo electrónico: {ex.Message}");
        }
    }


    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UsuarioDTO userDto)
    {
        if (userDto.IdTipoUsuario!=4 || userDto.IdTipoUsuario!=1)
        {
            return BadRequest("Error en el registro");
        }
        userDto.Correo= userDto.Correo.ToLower(); 
        try
        {
           
            var correos = await _usuarioService.GetCorreos();
            for (int i = 0; i < correos.Length; i++)
            {
                if (correos[i] == userDto.Correo)
                {
                    return BadRequest("Correo ya ha sido registrado");
                }
            }
            if(userDto.IdTipoUsuario == 1)
            {
                var empresas = await _usuarioService.GetEmpresas();
                for (int i = 0; i < empresas.Length; i++)
                {
                    if (empresas[i] == userDto.EmpresaPertenece)
                    {
                        
                        return BadRequest("La empresa ya ha sido registrada");
                    }
                }
            }
            var confirmationToken = _correoService.GenerateConfirmationToken();
            confirmationToken = confirmationToken.Replace("+", "-");
            var (usuario, numero) = await _usuarioService.Register(userDto, confirmationToken);

            // Genera el token de confirmación antes de enviar el correo
            
            await _correoService.SendConfirmationEmail(userDto.Correo, confirmationToken, 1);

            return Ok(usuario);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UsuarioLoginDTO loginDto)
    {
       loginDto.Correo= loginDto.Correo.ToLower();
        if (loginDto == null)
        {
            return BadRequest("Invalid login request");
        }
    
        var (usuario, miContra) = await _usuarioService.Login(loginDto);
       
        if (usuario == null)
        {
            return BadRequest("El correo/contraseña no es valida");
        }
        var correoNoValidado = !usuario.Activo;
        if (correoNoValidado)
        {
            return BadRequest("El correo no ha sido validado");
        }
        if (usuario.IdTipoUsuario==4)
        {
            return BadRequest("El usuario NO ha sido validado por empresa");
        }
        bool Correcto = usuario.ContraseñaCifrada.SequenceEqual(miContra);

        var Error = await _usuarioService.ValidacionIntentos(usuario, Correcto);
        if (Error == 1)
        {
            return BadRequest("Debe esperar 5 min para poder volver a intentar a loguearse");
        }
        if (Error == 2)
        {
            return BadRequest("Debe esperar 10 min para poder volver a intentar a loguearse");
        }
        if (Error == 3)
        {
            var confirmationToken = _correoService.GenerateConfirmationToken();
            confirmationToken = confirmationToken.Replace("+", "-");
            await _usuarioService.BloquearCuenta(usuario.IdUsuario, confirmationToken);
            await _correoService.SendConfirmationEmail(usuario.Correo, confirmationToken, 2);
            return BadRequest("Su cuenta ha sido bloqueada, favor de revisar su correo");
        }
  

        if (!Correcto)
        {
            return BadRequest("El correo/contraseña no es valida");

        }
        //bool intentoValido = 
        // Aquí genera el token JWT y devuelve el usuario con el token
        var token = _usuarioService.GenerateJwtToken(usuario, usuario.IdTipoUsuario);
        
        return Ok(new { usuario, token });
    }



}