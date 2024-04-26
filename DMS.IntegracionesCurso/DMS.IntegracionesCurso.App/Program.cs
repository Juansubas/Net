
using DMS.IntegracionesCurso.Core.Interfaces;
using DMS.IntegracionesCurso.Infrastructure.Repositories;
using DMS.IntegracionesCurso.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

var serviceProvider = new ServiceCollection();
serviceProvider.AddSingleton(configuration);
serviceProvider.AddTransient<IArchivoService, ArchivoService>();
serviceProvider.AddTransient<ICorreoService, CorreoService>();
serviceProvider.AddTransient<ICursoRepository, CursoRepository>();
serviceProvider.AddTransient<ILogService, LogService>();
serviceProvider.AddTransient<IExecuteService, ExecuteService>();

var app = serviceProvider.BuildServiceProvider();
var execute = app.GetService<IExecuteService>();
execute.Execute();