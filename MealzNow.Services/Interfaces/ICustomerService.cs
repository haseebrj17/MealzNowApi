using MealzNow.Core.Dto;
using MealzNow.Core.RequestModels;
using MealzNow.Core.ResponseModels;

namespace MealzNow.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerDto>? AddCustomer(CustomerDto customer);
        Task<LoginResponse> VerifyPin(string pin, Guid customerId);
        Task<LoginResponse> CustomerLogin(LoginRequestModel customer);
        Task<CustomerAddressDto> AddAddress(CustomerAddressDto addressDto);
        Task<List<CustomerAddressDto>> GetAllAddresses(Guid customerId);
        Task<bool> UpdateAddress(CustomerAddressDto customer);
        Task<bool> DeleteMyAccount(Guid customerId);
    }
}
