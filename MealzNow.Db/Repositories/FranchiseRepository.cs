using MealzNow.Db.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using static MealzNow.Core.Enum.Enums;

namespace MealzNow.Db.Repositories
{
    public interface IFranchiseRepository
    {
        Task<List<Franchise>> GetClientFranchises(Guid clientId);
        Task<List<Order>> GetAllFranchiseOrders(Guid franchiseId, DateTime specificDay);
        Task<List<Order>> GetCustomerOrders(Guid customerId);
        Task<bool> UpdateOrderStatus(Guid orderId, Guid dayId, Guid productByTimingId, OrderStatus orderStatus, Guid loggedInUserId);
        Task<FranchiseUser?> UserLogin(string email, string password);
        Task<Franchise?> GetFranchiseDetailByUser(string email);
        Task<Franchise> GetFranchiseSettingById(Guid franchiseId);
        Task<bool> UpdateDishStatus(Guid id, Status status, Guid loggedInUserId);
        Task<bool> UpdateBrandStatus(Guid id, Status status, Guid loggedInUserId);
        Task<bool> UpdateFranchiseStatus(Guid id, Status status, Guid loggedInUserId);
        Task<bool> UpdateSubCategoryStatus(Guid id, Guid BrandId, Status status, Guid loggedInUserId);
        Task<bool> UpdateCategoryStatus(Guid id, Status status, Guid loggedInUserId);
        Task<bool> UpdateDippingStatus(Guid id, Guid DishId, Status status, Guid loggedInUserId);
        Task<bool> UpdateToppingStatus(Guid id, Guid DishId, Status status, Guid loggedInUserId);
        Task<Franchise> GetFranchisById(Guid franchiseId);
    }
    public class FranchiseRepository : IFranchiseRepository
    {
        private readonly MealzNowDataBaseContext _mealzNowDataBaseContext;
        public FranchiseRepository(MealzNowDataBaseContext mealzNowDataBaseContext)
        {
            _mealzNowDataBaseContext = mealzNowDataBaseContext;
        }

        public async Task<List<Order>> GetCustomerOrders(Guid customerId)
        {
            return await _mealzNowDataBaseContext.Orders
                .Include(o => o.CustomerOrderedPackage)
                .Include(o => o.ProductByDay)
                    .ThenInclude(pbd => pbd.ProductByTiming)
                .Include(o => o.CustomerOrderPromo)
                .Include(o => o.CustomerOrderPayment)
                .Where(o => o.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task<List<Order>> GetAllFranchiseOrders(Guid franchiseId, DateTime specificDay)
        {

            return await _mealzNowDataBaseContext.Orders
                .Include(o => o.CustomerOrderedPackage)
                .Include(o => o.ProductByDay)
                    .ThenInclude(pbd => pbd.ProductByTiming)
                .Include(o => o.CustomerOrderPromo)
                .Include(o => o.CustomerOrderPayment)
                .Include(o => o.CustomerDetails)
                    .ThenInclude(cd => cd.CustomerAddressDetail)
                .Where(o => o.FranchiseId == franchiseId &&
                            o.ProductByDay.Any(pbd => pbd.DeliveryDate == specificDay.Date))
                .OrderByDescending(o => o.CreatedDateTimeUtc)
                .ToListAsync();
        }

        public async Task<List<Franchise>> GetClientFranchises(Guid clientId)
        {
            return await _mealzNowDataBaseContext.Franchises
                .Where(f => f.ClientId == clientId && f.IsActive)
                .ToListAsync();
        }

        public async Task<Franchise> GetFranchisById(Guid franchiseId)
        {
            return await _mealzNowDataBaseContext.Franchises
                .Where(f => f.Id == franchiseId && f.IsActive)
                .FirstOrDefaultAsync();
        }

        public async Task<Franchise?> GetFranchiseDetailByUser(string email)
        {
            var user = await _mealzNowDataBaseContext.FranchiseUsers
                .FirstOrDefaultAsync(u => u.EmailAddress == email);

            if (user == null || user.FranchiseId == Guid.Empty)
            {
                throw new InvalidOperationException("Franchise not found for the provided user.");
            }

            return await _mealzNowDataBaseContext.Franchises
                .FirstOrDefaultAsync(f => f.Id == user.FranchiseId);
        }

        public async Task<bool> UpdateOrderStatus(Guid orderId, Guid dayId, Guid productByTimingId, OrderStatus orderStatus, Guid loggedInUserId)
        {
            var order = await _mealzNowDataBaseContext.Orders
                .Include(o => o.ProductByDay)
                    .ThenInclude(pbd => pbd.ProductByTiming)
                .FirstOrDefaultAsync(o => o.Id == orderId);

            if (order == null)
            {
                return false;
            }

            var day = order.ProductByDay.FirstOrDefault(d => d.DayId == dayId);
            if (day == null)
            {
                return false;
            }

            var productByTiming = day.ProductByTiming.FirstOrDefault(pbt => pbt.TimeOfDayId == productByTimingId);
            if (productByTiming == null)
            {
                return false;
            }

            if (orderStatus == OrderStatus.Delivered)
            {
                productByTiming.Fulfilled = true;
            }

            order.OrderStatus = orderStatus;
            order.UpdatedById = loggedInUserId;
            _mealzNowDataBaseContext.Orders.Update(order);

            await _mealzNowDataBaseContext.SaveChangesAsync();
            return true;
        }

        public async Task<Franchise> GetFranchiseSettingById(Guid franchiseId)
        {
            var franchise = await _mealzNowDataBaseContext.Franchises
                                .Include(f => f.FranchiseSetting)
                                .Include(f => f.FranchiseTimings)
                                .FirstOrDefaultAsync(f => f.Id == franchiseId);

            if (franchise == null)
            {
                throw new InvalidOperationException("Franchise not found.");
            }

            return franchise;
        }

        public async Task<FranchiseUser?> UserLogin(string email, string password)
        {
            var user = await _mealzNowDataBaseContext.FranchiseUsers.FirstOrDefaultAsync(c => c.EmailAddress == email && c.Password == password);

            if (user == null) return null;

            return user;
        }

        public async Task<bool> UpdateDishStatus(Guid id, Status status, Guid loggedInUserId)
        {
            var dish = await _mealzNowDataBaseContext.Products.FirstAsync(p => p.Id == id);

            if (dish != null)
            {
                dish.IsActive = status == Status.Active;

                dish.UpdatedById = loggedInUserId;

                _mealzNowDataBaseContext.Products.Update(dish);

                await _mealzNowDataBaseContext.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<bool> UpdateBrandStatus(Guid id, Status status, Guid loggedInUserId)
        {
            var brand = await _mealzNowDataBaseContext.Categories.FirstAsync(p => p.Id == id);

            if (brand != null)
            {
                brand.IsActive = status == Status.Active;

                brand.UpdatedById = loggedInUserId;

                _mealzNowDataBaseContext.Categories.Update(brand);

                await _mealzNowDataBaseContext.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<bool> UpdateFranchiseStatus(Guid id, Status status, Guid loggedInUserId)
        {
            var franchise = await _mealzNowDataBaseContext.Franchises.FirstAsync(p => p.Id == id);

            if (franchise != null)
            {
                franchise.IsActive = status == Status.Active;

                franchise.UpdatedById = loggedInUserId;

                _mealzNowDataBaseContext.Franchises.Update(franchise);

                await _mealzNowDataBaseContext.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<bool> UpdateSubCategoryStatus(Guid id, Guid BrandId, Status status, Guid loggedInUserId)
        {
            var brand = await _mealzNowDataBaseContext.Categories
                .Include(c => c.SubCategory)
                .FirstOrDefaultAsync(p => p.Id == BrandId);

            var subCategory = brand?.SubCategory.FirstOrDefault(sc => sc.Id == id);

            if (subCategory != null)
            {
                subCategory.IsActive = status == Status.Active;
                subCategory.UpdatedById = loggedInUserId;

                await _mealzNowDataBaseContext.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<bool> UpdateCategoryStatus(Guid id, Status status, Guid loggedInUserId)
        {
            var category = await _mealzNowDataBaseContext.Categories
                .FirstOrDefaultAsync(c => c.Id == id && !c.IsBrand);

            if (category != null)
            {
                category.IsActive = status == Status.Active;
                category.UpdatedById = loggedInUserId;

                await _mealzNowDataBaseContext.SaveChangesAsync();

                return true;
            }

            return false;
        }
        public async Task<bool> UpdateDippingStatus(Guid id, Guid DishId, Status status, Guid loggedInUserId)
        {
            var dish = await _mealzNowDataBaseContext.Products
                .FirstOrDefaultAsync(d => d.Id == DishId);

            if (dish != null)
            {
                dish.ShowExtraDipping = status == Status.Active;
                dish.UpdatedById = loggedInUserId;

                await _mealzNowDataBaseContext.SaveChangesAsync();

                return true;
            }

            return false;
        }
        public async Task<bool> UpdateToppingStatus(Guid id, Guid DishId, Status status, Guid loggedInUserId)
        {
            var dish = await _mealzNowDataBaseContext.Products
                            .FirstOrDefaultAsync(d => d.Id == DishId);

            if (dish != null)
            {
                dish.ShowExtraTopping = status == Status.Active;
                dish.UpdatedById = loggedInUserId;

                await _mealzNowDataBaseContext.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}