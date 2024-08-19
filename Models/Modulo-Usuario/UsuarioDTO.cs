namespace ArquiVision.Models.Modulo_Usuario
{
    // UsuarioDTO.cs
    public class UsuarioDTO
    {
        public string Correo { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Direccion { get; set; }
        public short Edad { get; set; }
        public string EmpresaPertenece { get; set; }
        public string Contraseña { get; set; } // Contraseña en texto claro
        public int IdTipoUsuario { get; set; }
    }

}
