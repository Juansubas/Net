using DMS.IntegracionesCurso.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace DMS.IntegracionesCurso.Infrastructure.Services;

public class ExecuteService : IExecuteService
{
    private readonly IConfiguration _configuration;
    private readonly ICorreoService _correoService;
    private readonly ILogService _logService;
    private readonly ICursoRepository _cursoRepository;
    private readonly IArchivoService _archivoService;
    public ExecuteService(IConfiguration configuration, ICorreoService correoService, ILogService logService, ICursoRepository cursoRepository, IArchivoService archivoService)
    {
        _configuration = configuration;
        _correoService = correoService;
        _logService = logService;
        _cursoRepository = cursoRepository;
        _archivoService = archivoService;

    }
    public void Execute()
    {
        var nombreArchivo = Guid.NewGuid().ToString();
        var rutaArchivo = Path.Combine(_configuration["RutaArchivo"], nombreArchivo);
        var datos = _cursoRepository.ObtenerUsuariosSinSincronizar();

        var tipoArchivo = int.Parse(_configuration["TipoArchivo"]);

        switch (tipoArchivo)
        {
            case 1:
                rutaArchivo = $"{rutaArchivo}.csv";
                _archivoService.GuardarEnCSV(datos.Tables[0], rutaArchivo);
                break;
            case 2:
                rutaArchivo = $"{rutaArchivo}.json";
                _archivoService.CrearJson(datos.Tables[0], rutaArchivo);
                break;
            case 3:
                rutaArchivo = $"{rutaArchivo}.xml";
                _archivoService.CrearXml(datos.Tables[0], rutaArchivo);
                 break;
        }

        foreach (DataRow row in datos.Tables[0].Rows)
        {
            _cursoRepository.ActualizarSincronizados(int.Parse(row["id"].ToString()));
        }

        var destinatarios = _configuration.GetSection("Destinatarios").Get<List<string>>();
        var listaArchivos = new List<string> { rutaArchivo };
        _correoService.NotificarEmail(destinatarios, "Curso back inyeccion", "Hola esto es una prueba de correo", false, listaArchivos);

    }

}
