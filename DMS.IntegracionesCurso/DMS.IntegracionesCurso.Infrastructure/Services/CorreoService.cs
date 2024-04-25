using DMS.IntegracionesCurso.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;

namespace DMS.IntegracionesCurso.Infrastructure.Services;

public class CorreoService : ICorreoService
{
    private readonly IConfiguration _configuration;
    private readonly ILogService _logService;
    public CorreoService(IConfiguration configuration, ILogService logService)
    {
        _configuration = configuration;
        _logService = logService;   
    }
    public void NotificarEmail(List<string> destinatarios, string asunto, string cuerpo, bool esHtml, List<string> adjuntos = null)
    {
        if(!destinatarios.Any())
        {
            throw new ArgumentException("El parametro destinatarios es obligatorio y no puede ser vacio");
        }

        MailMessage message = new MailMessage();
        foreach (string destinatario in destinatarios)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (regex.Match(destinatario).Success)
            {
                message.CC.Add(destinatario);
            }
            else
            {
                Console.WriteLine($"El correo [{destinatario}] no es un email valido.");
            }
        }

        message.From = new MailAddress(_configuration["UsuarioEmail"], _configuration["NombreUsuarioEmail"], Encoding.UTF8);;
        message.Subject = asunto;
        message.Body = cuerpo;
        message.BodyEncoding = Encoding.UTF8;
        message.Priority = MailPriority.Normal;
        message.IsBodyHtml = esHtml;

        if(adjuntos != null || adjuntos.Any()) 
        { 
            foreach (string archivo in adjuntos)
            {
                if (File.Exists(archivo))
                {
                    Attachment adjunto = new Attachment(archivo);
                    message.Attachments.Add(adjunto);
                }
            }
        }

        SmtpClient smtp = new SmtpClient();
        smtp.Host = _configuration["HostSmtp"];
        smtp.Port = int.Parse(_configuration["PuertoEmail"]);
        smtp.EnableSsl = bool.Parse(_configuration["UsaSSL"]);
        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
        smtp.UseDefaultCredentials = false;
        smtp.Credentials = new NetworkCredential(_configuration["UsuarioEmail"], _configuration["ClaveUsuarioEmail"]);
        //smtp.Timeout = 30;

        try
        {
            smtp.Send(message);
        }
        catch (Exception ex)
        {
            _logService.GuardarMensaje($"Se ha producido un error al enviar el mensaje, {ex.Message}");
            throw;
        }
    }
}
