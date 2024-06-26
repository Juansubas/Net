﻿using System.Data;
using System.IO;

namespace Data;

public class ManejadorArchivo
{
    private readonly LogService _logService = new LogService();
    public bool GuardarEnCsv(DataRow row, string rutaArchivo, string nombreArchivo)
    {
        rutaArchivo = Path.Combine(rutaArchivo, nombreArchivo);
        if (string.IsNullOrEmpty(rutaArchivo)) throw new Exception("La ruta no puede ser vacia");

		try
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
            return true;
        }
		catch (Exception ex)
		{
            _logService.saveMessage($"Se ha generado un error al guardar en el archivo [{rutaArchivo}], {ex.Message}");
            return false;
		}
    }
}
