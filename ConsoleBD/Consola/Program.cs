//// Servidor; base de datos; usuario; clave; certificado

//using Microsoft.Data.SqlClient;
//using System.Data;

////var Servidor = string.Empty;
////var Bd = string.Empty;
////var Usuario = string.Empty;
////var Clave = string.Empty;

////Console.WriteLine("Por favor ingrese el servidor de base de datos");
////Servidor = Console.ReadLine();
////Console.WriteLine("Por favor ingrese la bd: ");
////Bd = Console.ReadLine();
////Console.WriteLine("Por favor ingrese el usuario: ");
////Usuario = Console.ReadLine();
////Console.WriteLine("Por favor ingrese la clave: ");
////Clave = Console.ReadLine();

////;User Id ={Usuario};Password={Clave}
////var cadena = $"Server={Servidor};Database={Bd};Integrated Security=True;TrustServerCertificate=True";
//var cadena = $"Server=.;Database=APIColombia;Integrated Security=True;TrustServerCertificate=True";
//Console.WriteLine($"La cadena de conexion {cadena}");

//using (SqlConnection conn = new SqlConnection(cadena))
//{
//	// var query = "SELECT @@SERVERNAME"; // Consultar nombre del Servidor

//	var query = "SELECT * FROM Usuarios; SELECT @@SERVERNAME";

//    SqlCommand cmd = new SqlCommand(query, conn);

//	try
//	{
//		conn.Open();
//		//SqlDataReader reader = cmd.ExecuteReader();
//		//while (reader.Read())
//		//{
//		//	//Console.WriteLine($"Nombre del servidor: {reader[0]}");
//		//	Console.WriteLine($"Id: {reader["Id"]}, Nombre: {reader["Nombre"]}, Apellido: {reader["Apellido"]}");
//		//}

//		DataSet dt = new DataSet();
//		var adaptador = new SqlDataAdapter(cmd);
//		adaptador.Fill(dt);
//		Console.ReadLine();
//	}
//	catch (Exception ex)
//	{
//        Console.WriteLine($"Se ha generado un error al contectar o ejecutar la consulta, {ex.Message}");
//	}
//}


using Data;
using System.Data;

string path = @"C:\lib\DDI\separado.csv";

var directory = Path.GetDirectoryName(path);

if (!Directory.Exists(directory))
{
	Directory.CreateDirectory(directory);
}

var conexion = new Conexion();

var usuarios = conexion.ObtenerUsuariosSinSincronizar();

foreach (DataRow usuario in usuarios.Tables[0].Rows)
{
    var cadena = ($"{usuario["id"]},{usuario["nombre"]},{usuario["apellido"]},{usuario["email"]},{usuario["genero"]},{usuario["usuario"]},{usuario["activo"]}");
	using (StreamWriter writer = new StreamWriter(path, true))
	{
		writer.WriteLine(cadena);
	}

	conexion.ActualizarSincronizado(int.Parse(usuario["id"].ToString()));
}

Console.WriteLine("Fin Lectura");