using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureLogging(logging =>
    {
        logging.AddConsole();
    })
    .Build();

try
{
    await host.RunAsync();
}
catch (Exception ex)
{
    var logger = host.Services.GetRequiredService<ILogger<Program>>();
    logger.LogCritical(ex, "An error occurred.");
}