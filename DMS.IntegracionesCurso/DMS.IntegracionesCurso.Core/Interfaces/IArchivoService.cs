using System.Data;

namespace DMS.IntegracionesCurso.Core.Interfaces;

public interface IArchivoService
{
    bool GuardarEnCSV(DataTable datos, string rutaArchivo);
    bool CrearJson(DataTable datos, string rutaArchivo);
    bool CrearXml(DataTable datos, string rutaArchivo);
}
