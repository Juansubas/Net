namespace DMS.IntegracionesCurso.Core.Interfaces;

public interface ICorreoService
{
    void NotificarEmail(List<string> destinatarios, string asunto, string cuerpo, bool esHtml, List<string> adjuntos = null);
}
