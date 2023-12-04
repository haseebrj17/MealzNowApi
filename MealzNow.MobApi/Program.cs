using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var loggerFactory = LoggerFactory.Create(builder =>
{
    builder.AddConsole();
});

var logger = loggerFactory.CreateLogger("Program");

try
{
    var host = new HostBuilder()
        .ConfigureFunctionsWorkerDefaults()
        .Build();

    await host.RunAsync();
}
catch (Exception ex)
{
    logger.LogCritical(ex, "An error occurred.");
}
