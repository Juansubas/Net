using System.Data;

namespace DMS.IntegracionesCurso.Core.Interfaces;

public interface ICursoRepository
{
    DataSet ObtenerUsuariosSincronizados();
    bool ActualizarSincronizados(int idUsuario);
}
