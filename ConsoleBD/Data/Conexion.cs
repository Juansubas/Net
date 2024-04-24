using Microsoft.Data.SqlClient;
using System.Data;

namespace Data;

public class Conexion
{
    private readonly string cadena = $"Server=.;Database=APIColombia;Integrated Security=True;TrustServerCertificate=True";

    public DataSet ObtenerUsuariosSinSincronizar()
    {
        DataSet dt = new DataSet();

        using SqlConnection conn = new SqlConnection(cadena);
        var query = "ConsultarUsuariosNoSincronizados";

        SqlCommand cmd = new SqlCommand(query, conn);
        cmd.CommandType = CommandType.StoredProcedure;

        try
        {
            conn.Open();

            var adaptador = new SqlDataAdapter(cmd);
            adaptador.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            throw new Exception($"Se ha generado un error al conectar o ejecutar la consulta, {ex.Message}");
        }
    }

    public bool ActualizarSincronizado(int idUsuario)
    {
        using SqlConnection conn = new SqlConnection(cadena);
        var query = "GuardarUsuarioSincronizado";
        SqlCommand cmd = new SqlCommand(query, conn);
        cmd.CommandType = CommandType.StoredProcedure;


        cmd.Parameters.AddWithValue("@UsuarioId", idUsuario);

        try
        {
            conn.Open();

            return cmd.ExecuteNonQuery() > 0;
        }
        catch (Exception ex)
        {
            throw new Exception($"Se ha generado un error al guardar sincronizado, {ex.Message}");
        }
    }
}
