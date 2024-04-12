using Clase1Consola;
using Microsoft.Extensions.DependencyInjection;

var service = new ServiceCollection();
service.AddSingleton<IIDSingleton>(new ID());
service.AddScoped<IIDScoped, ID>();
service.AddTransient<IIDTrasient, ID>();


var app = service.BuildServiceProvider();
var single = app.GetRequiredService<IIDSingleton>();
var scoped1 = app.GetRequiredService<IIDScoped>();
var scoped2 = app.GetRequiredService<IIDScoped>();
var trasient1 = app.GetRequiredService<IIDTrasient>();
var trasient2 = app.GetRequiredService<IIDTrasient>();

Console.WriteLine($"Singleton {single.Value}");

Console.WriteLine($"Scoped1 {scoped1.Value}");
Console.WriteLine($"Scoped2 {scoped2.Value}");
Console.WriteLine($"Trasient1 {trasient1.Value}");
Console.WriteLine($"Trasient2 {trasient2.Value}");