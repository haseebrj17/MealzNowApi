using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MealzNow.Db;
using System;
using AutoMapper;
using MealzNow.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.ApplicationInsights.Extensibility;

[assembly: FunctionsStartup(typeof(MealzNow.Api.Startup))]

namespace MealzNow.Api
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            builder.Services.AddSingleton<IConfiguration>(config);

            var cosmosDbAccount = config.GetValue<string>("CosmosDb:Account");
            var cosmosDbKey = config.GetValue<string>("CosmosDb:Key");
            var cosmosDbDatabaseName = config.GetValue<string>("CosmosDb:DatabaseName");

            builder.Services.AddDbContext<MealzNowDataBaseContext>(options =>
                options.UseCosmos(cosmosDbAccount, cosmosDbKey, cosmosDbDatabaseName));

            builder.Services.AddRepositories(config);
            builder.Services.AddServices(config);
            builder.Services.AddAutoMapper(typeof(Program));

            var serviceProvider = builder.Services.BuildServiceProvider();
            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<MealzNowDataBaseContext>();
                dbContext.Database.EnsureCreated();
            }
        }
    }
}
