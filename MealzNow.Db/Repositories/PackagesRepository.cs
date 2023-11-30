using MealzNow.Db.Models;
using Microsoft.EntityFrameworkCore;

namespace MealzNow.Db.Repositories
{
    public interface IPackagesRepository
    {
        Task<List<Packages>> GetFranchisePackages(Guid franchiseId);
    }

    public class PackagesRepository : IPackagesRepository
    {
        private readonly MealzNowDataBaseContext _mealzNowDataBaseContext;

        public PackagesRepository(MealzNowDataBaseContext mealzNowDataBaseContext)
        {
            _mealzNowDataBaseContext = mealzNowDataBaseContext;
        }

        public async Task<List<Packages>> GetFranchisePackages(Guid franchiseId)
        {
            var packages = await _mealzNowDataBaseContext.Packages
                .Where(p => p.FranchiseId == franchiseId && p.IsActive)
                .ToListAsync();

            return packages;
        }
    }
}
