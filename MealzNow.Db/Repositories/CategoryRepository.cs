using MealzNow.Core.Dto;
using MealzNow.Db.Models;
using Microsoft.EntityFrameworkCore;

namespace MealzNow.Db.Repositories
{
    public interface ICategoryRepository
    {
        List<Category> GetFranchiseBrands(Guid franchiseId);
        List<SubCategory> GetChildCategories(Guid categoryId);
        Task<List<SubCategory>> GetAllSubCategories(Guid franchiseId);
    }
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MealzNowDataBaseContext _mealzNowDataBaseContext;
        public CategoryRepository(MealzNowDataBaseContext mealzNowDataBaseContext)
        {
            _mealzNowDataBaseContext = mealzNowDataBaseContext;
        }

        public List<SubCategory> GetChildCategories(Guid categoryId)
        {
            var parentCategory = _mealzNowDataBaseContext.Categories
                .Include(c => c.SubCategory)
                .FirstOrDefault(c => c.Id == categoryId && c.IsActive);

            return parentCategory?.SubCategory.Where(b => b.IsActive).OrderBy(c => c.Sequence).ToList() ?? new List<SubCategory>();
        }

        public List<Category> GetFranchiseBrands(Guid franchiseId)
        {
            return _mealzNowDataBaseContext.Categories.Where(b => b.FranchiseId == franchiseId && b.IsActive && b.IsBrand).OrderBy(c => c.Sequence).ToList();
        }

        public async Task<List<SubCategory>> GetAllSubCategories(Guid franchiseId)
        {
            var categories = await _mealzNowDataBaseContext.Categories
                .Include(c => c.SubCategory)
                .Where(c => c.FranchiseId == franchiseId && c.IsActive)
                .OrderBy(c => c.Sequence)
                .ToListAsync();

            var allSubCategories = new List<SubCategory>();
            foreach (var category in categories)
            {
                allSubCategories.AddRange(category.SubCategory
                    .Where(sc => sc.IsActive)
                    .OrderBy(sc => sc.Sequence));
            }

            return allSubCategories;
        }

    }
}