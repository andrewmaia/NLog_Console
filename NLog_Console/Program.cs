using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using NLog_Console;

//https://github.com/NLog/NLog/wiki/Getting-started-with-.NET-Core-2---Console-application
var config = new ConfigurationBuilder()
   .SetBasePath(Directory.GetCurrentDirectory())
   .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
   .Build();
var logger = LoggerFactory.Create(builder => builder.AddNLog());

using var servicesProvider = new ServiceCollection()
    .AddTransient<IServico1, Servico1>() 
    .AddLogging(loggingBuilder =>
    {
        loggingBuilder.ClearProviders();
        loggingBuilder.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
        loggingBuilder.AddNLog(config);
    })
    .BuildServiceProvider();


IServico1 servico1 = servicesProvider.GetRequiredService<IServico1>();
servico1.Log();
