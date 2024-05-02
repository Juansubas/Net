using DMS.IntegracionesCurso.Core.Interfaces;
using Newtonsoft.Json;
using System.Data;
using System.Xml.Serialization;

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

    public bool CrearJson(DataTable datos, string rutaArchivo)
    {
        var directorio = Path.GetDirectoryName(rutaArchivo);
        if (!Directory.Exists(directorio))
        {
            Directory.CreateDirectory(directorio);
        }

        try
        {
            var json = JsonConvert.SerializeObject(datos, Formatting.Indented);
            using StreamWriter writer = new StreamWriter(rutaArchivo, true);
            writer.Write(json);
            writer.Close();
            return true;
        }
        catch (Exception ex)
        {
            _logService.GuardarMensaje($"Se ha producido un error al generar archivo json, {ex.Message}");
            return false;
        }
    }

    public bool CrearXml(DataTable datos, string rutaArchivo)
    {
        var directorio = Path.GetDirectoryName(rutaArchivo);
        if (!Directory.Exists(directorio))
        {
            Directory.CreateDirectory(directorio);
        }

        try
        {
            using StreamWriter writer = new StreamWriter(rutaArchivo, true);
            XmlSerializer serializer = new XmlSerializer(typeof(DataTable));
            serializer.Serialize(writer, datos);
            return true;
        }
        catch (Exception ex)
        {
            _logService.GuardarMensaje($"Se ha producido un error al generar archivo xml, {ex.Message}");
            return false;
        }
    }
}
