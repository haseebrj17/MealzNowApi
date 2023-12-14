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

[assembly: FunctionsStartup(typeof(MealzNow.MobApi.Startup))]

namespace MealzNow.MobApi
{
    public class Startup : FunctionsStartup
    {
        private static readonly IConfigurationRoot Configuration = new ConfigurationBuilder()
            .SetBasePath(Environment.CurrentDirectory)
            .AddJsonFile("local.settings.json", true)
            .AddEnvironmentVariables()
            .Build();

        public override void Configure(IFunctionsHostBuilder builder)
        {
            var config = builder.GetContext().Configuration;

            var cosmosDbAccount = config.GetValue<string>("CosmosDb:Account");
            var cosmosDbKey = config.GetValue<string>("CosmosDb:Key");
            var cosmosDbDatabaseName = config.GetValue<string>("CosmosDb:DatabaseName");

            builder.Services.AddDbContext<MealzNowDataBaseContext>(options =>
                options.UseCosmos(cosmosDbAccount, cosmosDbKey, cosmosDbDatabaseName));

            builder.Services.AddRepositories(config);
            builder.Services.AddServices(config);
            builder.Services.AddAutoMapper(typeof(Program));
        }
    }
}