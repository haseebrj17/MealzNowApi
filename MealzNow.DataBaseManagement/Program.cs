using MealzNow.DataBaseManagement.Seeder;
using MealzNow.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

var cosmosDbConString = configuration.GetConnectionString("CosmosDb:ConnectionString") ??
    "AccountEndpoint=https://mealznowcdb.documents.azure.com:443/;AccountKey=ZUr2bcfSjsQSjuhfpS6XtWjcUYKWYGXhe3SoA2okp0pcjiTq7Oej56L2OuvOFwEaKZ032OZi2QMzACDbL9fXVQ==;";
var cosmosDbDatabaseName = configuration.GetConnectionString("CosmosDb:DatabaseName") ??
    "MealzNowDB";

builder.Services.AddDbContext<MealzNowDataBaseContext>(options =>
options.UseCosmos(
    cosmosDbConString,
    databaseName: cosmosDbDatabaseName
));

builder.Services.AddScoped<DataSeeder>();

var app = builder.Build();

await InitializeDatabase(app);

using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();
    await seeder.SeedDataAsync();
}

app.MapGet("/", () => "Hello World!");

app.Run();

async Task InitializeDatabase(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<MealzNowDataBaseContext>();
    await dbContext.Database.EnsureCreatedAsync();
}
