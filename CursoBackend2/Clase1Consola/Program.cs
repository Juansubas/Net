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
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

var service = new ServiceCollection();

service.AddScoped<IMiService, MiService>();

var app  = service.BuildServiceProvider();
var miServicio = app.GetRequiredService<IMiService>();

Console.WriteLine("Por favor escribe tu nombre");


var nombre = Console.ReadLine();
miServicio.Saluda(nombre);
