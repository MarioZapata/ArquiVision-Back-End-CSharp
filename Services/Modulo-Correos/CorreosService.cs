using ArquiVision.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using ArquiVision.Services.Modulo_Correos;
using Microsoft.Extensions.Configuration;



namespace ArquiVision.Services
{
    public class CorreoService : ICorreoService
    {
       
        private readonly SmtpSettings _smtpSettings;
        private readonly AppDbContext _context;
        public CorreoService(IConfiguration configuration, IOptions<SmtpSettings> smtpSettings, AppDbContext context)
        {
            
            _smtpSettings = smtpSettings.Value;
            _context = context;
        }
        public async Task<bool> ConfirmEmail(string token)
        {
            try
            {
                var user = await _context.Usuarios.FirstOrDefaultAsync(u => u.Activo == false && u.ConfirmationToken == token );

                if (user == null)
                {
                    Console.WriteLine("no se encontro nada");
                    return false; // Token de confirmación inválido o usuario ya activado
                }

                // Actualizar el estado del usuario a activo
                user.Activo = true;
                user.Intentos = 0;
                user.FechaIntento = null;
                //user.ConfirmationToken = null; // Opcional: limpiar el token de confirmación

                _context.Entry(user).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Console.WriteLine($"Error al confirmar el correo electrónico: {ex.Message}");
                return false;
            }
        }
        public async Task SendConfirmationEmail(string email, string token, int Tipo)
        {
            var confirmationLink = $"https://http://localhost:4200/confirm?token={token}";

            var client = new SmtpClient(_smtpSettings.Server, _smtpSettings.Port)
            {
                Credentials = new NetworkCredential(_smtpSettings.Username, _smtpSettings.Password),
                EnableSsl = true
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_smtpSettings.SenderEmail, _smtpSettings.SenderName),
                Subject = "Confirma tu correo electrónico",
                Body = $"Hola,\n\nPor favor confirma tu correo electrónico haciendo clic en el siguiente enlace:\n\n{confirmationLink}\n\nSaludos,\nEl equipo. ArquiVison",
                IsBodyHtml = false,
            };
            if(Tipo == 2)
            {
                mailMessage = new MailMessage
                {
                    From = new MailAddress(_smtpSettings.SenderEmail, _smtpSettings.SenderName),
                Subject = "Se ha bloqueado su cuneta, por actividad sospechosa",
                Body = $"Hola,\n\n Para desbloquear la cuenta \n\nPor favor da clic en el siguiente enlace:\n\n{confirmationLink}\n\nSaludos,\nEl equipo de ArquiVison.",
                IsBodyHtml = false,
                };
            }
            mailMessage.To.Add(email);

            await client.SendMailAsync(mailMessage);
        }

        public string GenerateConfirmationToken()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var tokenData = new byte[32];
                rng.GetBytes(tokenData);
                return Convert.ToBase64String(tokenData);
            }
        }
    }

}
