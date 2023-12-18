using MealzNow.Services;
using MealzNow.Db;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using var loggerFactory = LoggerFactory.Create(builder =>
{
    builder.AddConsole();
});

var logger = loggerFactory.CreateLogger<Program>();

try
{
    var config = new ConfigurationBuilder()
        .AddJsonFile("local.settings.json", optional: true)
        .AddEnvironmentVariables()
        .Build();

    var cosmosDbAccount = config.GetValue<string>("CosmosDb:Account") ??
        "https://mealznowcdb.documents.azure.com:443/";
    var cosmosDbKey = config.GetValue<string>("CosmosDb:Key") ??
        "ZUr2bcfSjsQSjuhfpS6XtWjcUYKWYGXhe3SoA2okp0pcjiTq7Oej56L2OuvOFwEaKZ032OZi2QMzACDbL9fXVQ==";
    var cosmosDbDatabaseName = config.GetValue<string>("CosmosDb:DatabaseName") ??
        "MealzNowDB";

    var host = new HostBuilder()
        .ConfigureAppConfiguration(builder =>
        {
            builder.AddEnvironmentVariables();
            builder.AddJsonFile("local.settings.json", optional: true);
        })
        .ConfigureServices((context, services) =>
        {
            services.AddDbContext<MealzNowDataBaseContext>(options =>
                options.UseCosmos(cosmosDbAccount, cosmosDbKey, cosmosDbDatabaseName));

             services.AddRepositories(config);
             services.AddServices(config);
             services.AddAutoMapper(typeof(Program));

        }).ConfigureFunctionsWorkerDefaults()
        .Build();

    await host.RunAsync();
}
catch (Exception ex)
{
    logger.LogCritical("JW: " + ex.Message);
}