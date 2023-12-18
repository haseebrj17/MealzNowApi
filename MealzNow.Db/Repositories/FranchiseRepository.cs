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
            return await _mealzNowDataBaseContext.Franchises.Where(f => f.ClientId == clientId && f.IsActive == true).ToListAsync();
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
    }
}