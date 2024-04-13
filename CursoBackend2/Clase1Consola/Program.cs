//using Clase1Consola;
//using Microsoft.Extensions.DependencyInjection;

//var service = new ServiceCollection();
//service.AddSingleton<IIDSingleton>(new ID());
//service.AddScoped<IIDScoped, ID>();
//service.AddTransient<IIDTrasient, ID>();


//var app = service.BuildServiceProvider();
//var single = app.GetRequiredService<IIDSingleton>();
//var scoped1 = app.GetRequiredService<IIDScoped>();
//var scoped2 = app.GetRequiredService<IIDScoped>();
//var trasient1 = app.GetRequiredService<IIDTrasient>();
//var trasient2 = app.GetRequiredService<IIDTrasient>();

//Console.WriteLine($"Singleton {single.Value}");

//Console.WriteLine($"Scoped1 {scoped1.Value}");
//Console.WriteLine($"Scoped2 {scoped2.Value}");
//Console.WriteLine($"Trasient1 {trasient1.Value}");
//Console.WriteLine($"Trasient2 {trasient2.Value}");

using LibLogica.Interfaces;
using LibLogica.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

var service = new ServiceCollection();

service.AddScoped<IMiService, MiService>();

#if DEBUG
    var builder = new ConfigurationBuilder().SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName).AddJsonFile("Appsettings.Development.json", false);
#else
    var builder = new ConfigurationBuilder().SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName).AddJsonFile("Appsettings.json", false);
#endif
IConfiguration configuration = builder.Build();
service.AddSingleton(configuration);

var app  = service.BuildServiceProvider();
var miServicio = app.GetRequiredService<IMiService>();

Console.WriteLine("Por favor escribe tu nombre");


var nombre = Console.ReadLine();
miServicio.Saluda(nombre);

string menu = "\nA continuación puedes realizar tu operación matemática:\n" +
    "0. Salir y no elegir opción\n" +
    "1. Suma\n" +
    "2. Resta\n" +
    "3. Multiplicación\n" +
    "4. División\n";

Console.WriteLine(menu);

var operacion = Console.ReadLine();

while (Convert.ToInt32(operacion) != 0)
{
    Console.Write("Ingrese el Numero 1 \n");
    var numero1 = Convert.ToInt32(Console.ReadLine());
    Console.Write("Ingrese el Numero 2 \n");
    var numero2 = Convert.ToInt32(Console.ReadLine());

    switch (operacion)
    {
        case "1":
            miServicio.Suma(numero1, numero2);
            break;
        case "2":
            miServicio.Resta(numero1, numero2);
            break;
        case "3":
            miServicio.Multiplicacion(numero1, numero2);
            break;
        case "4":
            miServicio.Division(numero1, numero2);
            break;
        default:
            Console.WriteLine("Escribiste un valor erroneo");
            break;
    }

    Console.WriteLine(menu);
    operacion = Console.ReadLine();
}

miServicio.LeerAmbiente();