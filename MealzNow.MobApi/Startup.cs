using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MealzNow.Db;
using System;
using AutoMapper;
using MealzNow.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.Extensions.Logging;

[assembly: FunctionsStartup(typeof(MealzNow.MobApi.Startup))]

namespace MealzNow.MobApi
{
    public class Startup : FunctionsStartup
    {
        public IConfiguration Configuration { get; }

        public Startup()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("local.settings.json", true)
                .AddEnvironmentVariables()
                .Build();
        }

        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddLogging(); // Adding logging services

            var config = builder.GetContext().Configuration;

            // Entity Framework Core setup
            string cosmosDbAccount = config.GetValue<string>("CosmosDb:Account");
            string cosmosDbKey = config.GetValue<string>("CosmosDb:Key");
            var cosmosDbDatabaseName = config.GetValue<string>("CosmosDb:DatabaseName");
            builder.Services.AddDbContext<MealzNowDataBaseContext>(options =>
                options.UseCosmos(cosmosDbAccount, cosmosDbKey, cosmosDbDatabaseName));

            // Register other services
            builder.Services.AddRepositories(config);
            builder.Services.AddServices(config);
            builder.Services.AddAutoMapper(typeof(Program));

            // Now resolve the logger
            var logger = builder.Services.BuildServiceProvider().GetRequiredService<ILogger<Startup>>();
            logger.LogInformation("Starting Configure method in Startup.");

            // Create Cosmos DB database and containers
            var serviceProvider = builder.Services.BuildServiceProvider();
            CreateCosmosDbDatabaseAndContainersAsync(serviceProvider, logger).GetAwaiter().GetResult();
        }

        private async Task CreateCosmosDbDatabaseAndContainersAsync(IServiceProvider serviceProvider, ILogger logger)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<MealzNowDataBaseContext>();
                logger.LogInformation("Ensuring Cosmos DB database and containers are created.");
                await dbContext.Database.EnsureCreatedAsync();
                logger.LogInformation("Database EnsureCreatedAsync method called.");
            }
        }
    }
}
