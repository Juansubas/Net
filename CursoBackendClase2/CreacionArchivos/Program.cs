using CreacionArchivos;
using System.ComponentModel;
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


//Bloque 3 

// leer Contenido archivos

string rutaArchivo = @"C:\Users\juans\Downloads\ArchivosCreados\MOCK_DATA.csv";
string rutaProcesado = $"{Guid.NewGuid()}.csv";
List<Persona> lista = new List<Persona>();

if (File.Exists(rutaArchivo))
{
    string[] lineas = File.ReadAllLines(rutaArchivo);
    foreach (string linea in lineas.Skip(1))
    {
        string[] lineaPersona = linea.Split(",");
        var persona = new Persona()
        {
            Id = Convert.ToInt32(lineaPersona[0]),
            First_name = lineaPersona[1],
            Last_name = lineaPersona[2],
            Email = lineaPersona[3],
            Gender = lineaPersona[4],
            Ip_address = lineaPersona[5],
            Company_name = lineaPersona[6],
        };

        lista.Add(persona);

    }

    if (lista.Count > 0)
    {
        File.Move(rutaArchivo, Path.Combine(Path.GetDirectoryName(rutaArchivo), rutaProcesado));
    }

    Console.WriteLine($"Cantidad de personas {lista.Count()}");
}