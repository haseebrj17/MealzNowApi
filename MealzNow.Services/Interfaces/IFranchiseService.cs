using MealzNow.Core.Dto;
using MealzNow.Core.Enum;
using MealzNow.Core.RequestModels;
using MealzNow.Core.ResponseModels;
using static MealzNow.Core.Enum.Enums;

namespace MealzNow.Services.Interfaces
{
    public interface IFranchiseService
    {
        Task<LoginResponse> UserLogin(LoginRequestModel customer);
        Task<FranchiseDto> GetFranchiseById(Guid franchiseId);
        Task<List<OrderDto>> GetAllFranchiseOrders(Guid franchiseId);
        Task<List<OrderDto>> GetCustomerOrders(Guid customerId);
        Task<bool> UpdateOrderStatus(Guid orderId, Guid dayId, Guid productByTimingId, Enums.OrderStatus orderStatus, Guid loggedInUserId);
        Task<bool> UpdateDishStatus(Guid Id, Status status, Guid loggedInUserId);
        Task<bool> UpdateBrandStatus(Guid Id, Status status, Guid loggedInUserId);
        Task<bool> UpdateFranchiseStatus(Guid Id, Status status, Guid loggedInUserId);
        Task<bool> UpdateSubCategoryStatus(Guid Id, Guid BrandId, Enums.Status status, Guid loggedInUserId);
        Task<bool> UpdateCategoryStatus(Guid Id, Enums.Status status, Guid loggedInUserId);
        Task<bool> UpdateToppingStatus(Guid Id, Guid DishId, Enums.Status status, Guid loggedInUserId);
        Task<bool> UpdateDippingStatus(Guid Id, Guid DishId, Enums.Status status, Guid loggedInUserId);
    }
}