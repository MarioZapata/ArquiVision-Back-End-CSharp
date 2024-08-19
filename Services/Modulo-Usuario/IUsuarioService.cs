// IUsuarioService.cs

using ArquiVision.Models.Modulo_Usuario;


public interface IUsuarioService
{
    // Task InsertarUsuarioAsync(UsuarioDTO userDto);
    Task<(UsuarioDTO usuario, int Error)> Register(UsuarioDTO userDto, string confirmationToken);
    //Task<bool> ConfirmEmail(string token);

}