using DMS.IntegracionesCurso.Core.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using System.Data;

namespace DMS.IntegracionesCurso.Infrastructure.Repositories;

public class CursoRepository : ICursoRepository
{
    private readonly IConfiguration _configuration;
    public CursoRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public bool ActualizarSincronizados(int idUsuario)
    {
        using SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("CadenaConexion"));
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

    public DataSet ObtenerUsuariosSinSincronizar()
    {
        DataSet dt = new DataSet();

        using SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("CadenaConexion"));
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
}
