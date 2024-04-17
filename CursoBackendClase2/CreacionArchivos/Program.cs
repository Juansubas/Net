using System.IO;

//string directorio = "c:/lib/archivosCreados/";
//string archivoACrear = "primerArchivo.txt";

//string segundoArchivo = "c:/lib/archivosCreados/segundoArchivo.txt";

//Bloque 1 -- Crear Archivo y validar su ruta

//try
//{
//    if (!Directory.Exists(directorio))
//    {
//        Directory.CreateDirectory(directorio);
//    }

//    if (File.Exists(archivoACrear))
//    {
//        FileStream archivo = File.Create(Path.Combine(directorio, archivoACrear));
//        archivo.Close();
//    }
//}
//catch (Exception ex)
//{
//    Console.WriteLine("Se ha generado un error al crear el archivo", ex.Message);
//}

//Bloque 2 -- Obteniendo Ruta Directorio.

//var rutaArchivo = Path.GetDirectoryName(segundoArchivo);

//try
//{
//    if (!Directory.Exists(rutaArchivo))
//    {
//        Directory.CreateDirectory(rutaArchivo);
//    }

//    if(!File.Exists(segundoArchivo))
//    {
//        File.Create(segundoArchivo).Close();
//    }
//}
//catch (Exception ex)
//{
//    Console.WriteLine("Se ha generado un error al crear el archivo", ex.Message);
//    throw;
//}