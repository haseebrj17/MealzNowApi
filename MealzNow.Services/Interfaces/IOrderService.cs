using MealzNow.Core.Dto;

namespace MealzNow.Services.Interfaces
{
    public interface IOrderService
    {
        public Task<Guid?> PlaceOrder(OrderDto order);
    }
}