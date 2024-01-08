using MealzNow.Db.Models;
using Microsoft.EntityFrameworkCore;

namespace MealzNow.Db.Repositories
{
    public interface IOrderRepository
    {
        public Task<Order> AddOrder(Order order);
        public Task<Order> UpdateOrder(Order order);
        public Task<Order> GetOrderById(Guid orderId);
    }
    public class OrderRepository : IOrderRepository
    {
        private readonly MealzNowDataBaseContext _mealzNowDataBaseContext;
        public OrderRepository(MealzNowDataBaseContext mealzNowDataBaseContext)
        {
            _mealzNowDataBaseContext = mealzNowDataBaseContext;
        }

        public async Task<Order> AddOrder(Order order)
        {
            try
            {
                await _mealzNowDataBaseContext.Orders.AddAsync(order);
                await _mealzNowDataBaseContext.SaveChangesAsync();
                return order;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                throw new InvalidOperationException("Error adding order to the database.", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<Order> UpdateOrder(Order order)
        {
            try
            {
                _mealzNowDataBaseContext.Orders.Update(order);
                await _mealzNowDataBaseContext.SaveChangesAsync();
                return order;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Console.WriteLine(ex.Message);
                throw new InvalidOperationException("The order was not found or has been modified.", ex);
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                throw new InvalidOperationException("Error updating order in the database.", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<Order> GetOrderById(Guid orderId)
        {
            return await _mealzNowDataBaseContext.Orders
                .FirstAsync(o => o.Id == orderId);
        }

    }
}
