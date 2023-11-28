using MealzNow.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MealzNow.Db;

var config = new ConfigurationBuilder()
    .AddEnvironmentVariables()
    .Build();

var cosmosDbAccount = config.GetValue<string>("CosmosDb:Account") ??
    "https://mealznowcdb.documents.azure.com:443/";
var cosmosDbKey = config.GetValue<string>("CosmosDb:Key") ??
    "SEONv3ty9lriwa53UbtOIyUruLEW8000TIHM0uGBKqTQ9ChAp5TbX2nBtAIhaMngnm4475znExM3ACDb5UbnlA==";
var cosmosDbDatabaseName = config.GetValue<string>("CosmosDb:DatabaseName") ??
    "MealzNowDB";

var host = new HostBuilder()
    .ConfigureServices((context, services) =>
    {
        services.AddDbContext<MealzNowDataBaseContext>(options =>
            options.UseCosmos(cosmosDbAccount, cosmosDbKey, cosmosDbDatabaseName));

        // Add other services like repositories, automapper, etc.
        // services.AddRepositories(config);
        // services.AddServices(config);
        // services.AddAutoMapper(typeof(Program));

    }).ConfigureFunctionsWorkerDefaults()
    .Build();

host.Run();
