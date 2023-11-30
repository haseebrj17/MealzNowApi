using System;
using MealzNow.Db.Models;
using Microsoft.EntityFrameworkCore;

namespace MealzNow.Db.Repositories
{
    public interface IBannerRepository
    {
        public Task<List<Banner>> GetFranchiseBanners(Guid franchiseId);
    }

    public class BannerRepository : IBannerRepository
    {
        private readonly MealzNowDataBaseContext _mealzNowDataBaseContext;

        public BannerRepository(MealzNowDataBaseContext mealzNowDataBaseContext)
        {
            _mealzNowDataBaseContext = mealzNowDataBaseContext;
        }

        public async Task<List<Banner>> GetFranchiseBanners(Guid franchiseId)
        {
            var franchise = await _mealzNowDataBaseContext.Franchises
                .Include(f => f.Banner)
                .FirstOrDefaultAsync(f => f.Id == franchiseId && f.IsActive);

            return franchise?.Banner.Where(b => b.IsActive).ToList() ?? new List<Banner>();
        }
    }
}

