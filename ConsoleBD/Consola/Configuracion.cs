﻿using Data;

namespace Consola;

public class Configuracion
{
	private readonly LogService _logService = new LogService();
    public static Dictionary<string, string> Conf = new Dictionary<string, string>();
    public Dictionary<string, string> ObtenerConfiguracion(string rutaArchivoConfiguracion)
    {
		try
		{
			if (string.IsNullOrEmpty(rutaArchivoConfiguracion)) throw new Exception("La ruta del archivo de configuracion no puede ser null o vacio.");
			var confi = File.ReadAllLines(rutaArchivoConfiguracion);
			foreach (var linea in confi)
			{
				var lineaConfi = linea.Split("=");
				Conf.Add(lineaConfi[0], lineaConfi[1]);
			} 
			return Conf;
		}
		catch (Exception ex)
		{
			_logService.saveMessage($"Error al leer el archivo de configuracion");
			return null;
		}
    }
}
