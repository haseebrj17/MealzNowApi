using System.Text.Json;
using MealzNow.Db;
using MealzNow.Db.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace MealzNow.DataBaseManagement.Seeder
{
    public class DataSeeder
    {
        private readonly MealzNowDataBaseContext _context;

        public DataSeeder(MealzNowDataBaseContext context)
        {
            _context = context;
        }

        public async Task SeedDataAsync()
        {
            await SeedFranchisesAsync();
            // Add more seed methods as needed...
        }

        private async Task SeedFranchisesAsync()
        {
            var franchisesExist = await _context.Franchises.AsNoTracking().FirstOrDefaultAsync() != null;
            if (!franchisesExist)
            {
                var jsonData = await File.ReadAllTextAsync("./Data/Franchise.json");
                var franchises = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Franchise>>(jsonData);
                if (franchises != null)
                {
                    _context.Franchises.AddRange(franchises);
                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}