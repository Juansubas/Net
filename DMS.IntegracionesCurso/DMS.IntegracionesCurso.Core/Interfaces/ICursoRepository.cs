using System.Data;

namespace DMS.IntegracionesCurso.Core.Interfaces;

public interface ICursoRepository
{
    /// <summary>
    /// Este metodo permite obtener todos los usuarios que no se han sincronizados
    /// </summary>
    /// <returns>DataSet con los usuarios sin sincronizar</returns>
    DataSet ObtenerUsuariosSinSincronizar();

    /// <summary>
    /// Permite marcar un usuario como sincronizado
    /// </summary>
    /// <param name="idUsuario">Id del usuario que se va a marcar</param>
    /// <returns>True si el marcado fue exitoso, False si no se logro marcar el usuario</returns>
    bool ActualizarSincronizados(int idUsuario);
}
