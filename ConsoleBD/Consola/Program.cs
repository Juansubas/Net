// Servidor; base de datos; usuario; clave; certificado

var Servidor = string.Empty;
var Bd = string.Empty;
var Usuario = string.Empty;
var Clave = string.Empty;

Console.WriteLine("Por favor ingrese el servidor de base de datos");
Servidor = Console.ReadLine();
Console.WriteLine("Por favor ingrese la bd: ");
Bd = Console.ReadLine();
Console.WriteLine("Por favor ingrese el usuario: ");
Usuario = Console.ReadLine();
Console.WriteLine("Por favor ingrese la clave: ");
Clave = Console.ReadLine();

var cadena = $"Server={Servidor};Database={Bd};User Id ={Usuario};Password={Clave}";
Console.WriteLine($"La cadena de conexion {cadena}");

