using MealzNow.Db.Models;
using Microsoft.EntityFrameworkCore;

namespace MealzNow.Db.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProductsByCategoryId(Guid categoryId);
        Task<List<Product>> GetProductsByCategoryIds(List<Guid> categoryIds);
        Task<List<Product>> GetProductsById(List<Guid> productIds);
        Task<List<Product>> GetAllProducts(Guid franchiseId);
        Task<Product> GetProductById(Guid productId);
    }
    public class ProductRepository : IProductRepository
    {
        private readonly MealzNowDataBaseContext _mealzNowDataBaseContext;
        public ProductRepository(MealzNowDataBaseContext mealzNowDataBaseContext)
        {
            _mealzNowDataBaseContext = mealzNowDataBaseContext;
        }

        public async Task<List<Product>> GetProductsById(List<Guid> productIds)
        {
            var products = await _mealzNowDataBaseContext.Products
                .Include(p => p.ProductAllergy)
                .Include(p => p.ProductPrice)
                .Include(p => p.ProductCategory)
                .Include(p => p.ProductExtraDipping)
                .Include(p => p.ProductExtraTopping)
                .Include(p => p.ProductChoices)
                .Include(p => p.ProductItemOutline)
                .Where(p => productIds
                .Contains(p.Id) && p.IsActive).ToListAsync();

            return products;
        }

        public async Task<List<Product>> GetProductsByCategoryId(Guid categoryId)
        {
            var products = await _mealzNowDataBaseContext.Products
                .Include(p => p.ProductAllergy)
                .Include(p => p.ProductPrice)
                .Include(p => p.ProductCategory)
                .Include(p => p.ProductExtraDipping)
                .Include(p => p.ProductExtraTopping)
                .Include(p => p.ProductChoices)
                .Include(p => p.ProductItemOutline)
                .Where(p => p.CategoryId == categoryId && p.IsActive)
                .OrderBy(p => p.Sequence).ToListAsync();

            return products;
        }

        public async Task<List<Product>> GetProductsByCategoryIds(List<Guid> categoryIds)
        {
            var products = await _mealzNowDataBaseContext.Products
                .Include(p => p.ProductPrice)
                .Include(p => p.ProductAllergy)
                .Include(p => p.ProductExtraDipping)
                .Include(p => p.ProductExtraTopping)
                .Include(p => p.ProductChoices)
                .Include(p => p.ProductItemOutline)
                .Where(p => p.ProductCategory.Any(c => categoryIds.Contains(c.CategoryId)) && p.IsActive)
                .ToListAsync();

            return products;
        }

        public async Task<List<Product>> GetAllProducts(Guid franchiseId)
        {
            var products = await _mealzNowDataBaseContext.Products
                .Include(p => p.ProductPrice)
                .Include(p => p.ProductAllergy)
                .Include(p => p.ProductExtraDipping)
                .Include(p => p.ProductExtraTopping)
                .Include(p => p.ProductChoices)
                .Include(p => p.ProductItemOutline)
                .Include(p => p.ProductCategory)
                .Where(p => p.Franchiseid == franchiseId && p.IsActive)
                .OrderBy(p => p.CategoryId)
                .ToListAsync();

            return products;
        }

        public async Task<Product> GetProductById(Guid productId)
        {
            var product = await _mealzNowDataBaseContext.Products
                .Include(p => p.ProductPrice)
                .Include(p => p.ProductAllergy)
                .Include(p => p.ProductExtraDipping)
                .Include(p => p.ProductExtraTopping)
                .Include(p => p.ProductChoices)
                .Include(p => p.ProductItemOutline)
                .Include(p => p.ProductCategory)
                .Where(p => p.Id == productId && p.IsActive)
                .OrderBy(p => p.Sequence).FirstAsync();

            return product;
        }
    }
}