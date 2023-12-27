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

    var cosmosDbConString = config.GetValue<string>("CosmosDb:ConnectionString") ??
        "AccountEndpoint=https://mealznowcdb.documents.azure.com:443/;AccountKey=ZUr2bcfSjsQSjuhfpS6XtWjcUYKWYGXhe3SoA2okp0pcjiTq7Oej56L2OuvOFwEaKZ032OZi2QMzACDbL9fXVQ==;";
    var cosmosDbDatabaseName = config.GetValue<string>("CosmosDb:DatabaseName") ??
        "MealzNowDB";

    var host = new HostBuilder()
        .ConfigureServices((context, services) =>
        {
            services.AddDbContext<MealzNowDataBaseContext>(options =>
                options.UseCosmos(
                    cosmosDbConString,
                    databaseName: cosmosDbDatabaseName
                ));

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