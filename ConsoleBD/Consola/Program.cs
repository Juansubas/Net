﻿// Servidor; base de datos; usuario; clave; certificado

using Microsoft.Data.SqlClient;

var Servidor = string.Empty;
var Bd = string.Empty;
var Usuario = string.Empty;
var Clave = string.Empty;

Console.WriteLine("Por favor ingrese el servidor de base de datos");
Servidor = Console.ReadLine();
Console.WriteLine("Por favor ingrese la bd: ");
Bd = Console.ReadLine();
//Console.WriteLine("Por favor ingrese el usuario: ");
//Usuario = Console.ReadLine();
//Console.WriteLine("Por favor ingrese la clave: ");
//Clave = Console.ReadLine();

//;User Id ={Usuario};Password={Clave}
var cadena = $"Server={Servidor};Database={Bd};Integrated Security=True;TrustServerCertificate=True";
Console.WriteLine($"La cadena de conexion {cadena}");

using (SqlConnection conn = new SqlConnection(cadena))
{
    var query = "SELECT @@SERVERNAME";

    SqlCommand cmd = new SqlCommand(query, conn);

	try
	{
		conn.Open();
		SqlDataReader reader = cmd.ExecuteReader();
		while (reader.Read())
		{
			Console.WriteLine($"Nombre del servidor: {reader[0]}");
		}
	}
	catch (Exception ex)
	{
        Console.WriteLine($"Se ha generado un error al contectar o ejecutar la consulta, {ex.Message}");
	}
}