using System.Net;
using System.Net.Mail;
using System.Text;

namespace Data;

public static class Correo
{
    public static MailMessage CrearMensaje(List<string> destinatarios, string asunto, string cuerpo, bool esHtml, string usuario, string usuarioAMostrar)
    {
        MailMessage message = new MailMessage();
        foreach (string destinatario in destinatarios) 
        { 
            message.CC.Add(destinatario);
        }

        message.From = new MailAddress(usuario, usuarioAMostrar, Encoding.UTF8);
        message.Subject = asunto;
        message.Body = cuerpo;
        message.BodyEncoding = Encoding.UTF8;
        message.Priority = MailPriority.Normal;
        message.IsBodyHtml = esHtml;
        return message;
    }
    
    public static void AdjuntarArchivos(this MailMessage mensaje, List<string> archivos)
    {
        if (mensaje != null)
        {
            if (archivos.Any())
            {
                foreach (string archivo in archivos)
                {
                    if (File.Exists(archivo))
                    {
                        Attachment adjunto = new Attachment(archivo);
                        mensaje.Attachments.Add(adjunto);
                    }
                }
            }
        }
    }

    public static void EnviarMensaje(this MailMessage message, string usuario, string clave, string host, int puerto, bool usaSSL)
    {
        SmtpClient smtp = new SmtpClient();
        smtp.Host = host;
        smtp.Port = puerto;
        smtp.EnableSsl = usaSSL;
        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
        smtp.UseDefaultCredentials = false;
        smtp.Credentials = new NetworkCredential(usuario, clave);
        //smtp.Timeout = 30;

        try
        {
            smtp.Send(message);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al enviar email, {ex.Message}");
        }
    }
}
