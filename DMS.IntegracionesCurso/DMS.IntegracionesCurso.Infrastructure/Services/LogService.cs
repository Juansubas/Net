using DMS.IntegracionesCurso.Core.Interfaces;
using Microsoft.Extensions.Configuration;

namespace DMS.IntegracionesCurso.Infrastructure.Services;

public class LogService(IConfiguration configuration) : ILogService
{
    private readonly IConfiguration _configuration = configuration;

    public void GuardarMensaje(string mensaje)
    {
        var rutaArchivo = _configuration["RutaLogs"];
        var directorio = Path.GetDirectoryName(rutaArchivo);
        if(!Directory.Exists(directorio))
        {
            Directory.CreateDirectory(directorio);
        }

        using StreamWriter writer = new StreamWriter(rutaArchivo, true);

        writer.Write(mensaje);
        Console.WriteLine($"[{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt")}] - *_* {mensaje}");
    }
}
