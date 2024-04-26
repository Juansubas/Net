using System.Data;

namespace DMS.IntegracionesCurso.Core.Interfaces;

public interface IArchivoService
{
    bool GuardarEnCSV(DataTable datos, string rutaArchivo);
}
