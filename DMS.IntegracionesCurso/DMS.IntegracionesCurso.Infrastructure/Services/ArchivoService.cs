using DMS.IntegracionesCurso.Core.Interfaces;
using System.Data;

namespace DMS.IntegracionesCurso.Infrastructure.Services;

public class ArchivoService : IArchivoService
{
    private readonly ILogService _logService;
    public ArchivoService(ILogService logService)
    {
        _logService = logService;
    }
    public bool GuardarEnCSV(DataTable datos, string rutaArchivo)
    {
        try
        {
            foreach (DataRow row in datos.Rows)
            {
                var cadena = ($"{row["id"]},{row["nombre"]},{row["apellido"]},{row["email"]},{row["genero"]},{row["usuario"]},{row["activo"]}");
                var directorio = Path.GetDirectoryName(rutaArchivo);
                if (!Directory.Exists(directorio))
                {
                    Directory.CreateDirectory(directorio);
                }

                using StreamWriter writer = new StreamWriter(rutaArchivo, true);
                writer.WriteLine(cadena);
                writer.Close();
            }
            return true;
        }
        catch (Exception ex)
        {
            _logService.GuardarMensaje($"Se ha producido un error al generar archivo plano, {ex.Message}");
            return false;
        }
    }
}
