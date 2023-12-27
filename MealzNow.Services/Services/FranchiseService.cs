using AutoMapper;
using MealzNow.Core.Dto;
using MealzNow.Core.Enum;
using MealzNow.Core.RequestModels;
using MealzNow.Core.ResponseModels;
using MealzNow.Db.Models;
using MealzNow.Core;
using MealzNow.Db.Repositories;
using MealzNow.Services;
using MealzNow.Services.Interfaces;
using Microsoft.Azure.Cosmos;

namespace MealzNow.Services.Services
{
    public class FranchiseService : IFranchiseService
    {
        private readonly IFranchiseRepository _franchiseRepository;
        private readonly IMapper _mapper;
        private readonly IJwtTokenManager _jwtTokenManager;

        public FranchiseService(IMapper mapper, IFranchiseRepository franchiseRepository,
                    IJwtTokenManager jwtTokenManager)
        {
            _mapper = mapper;
            _franchiseRepository = franchiseRepository;
            _jwtTokenManager = jwtTokenManager;
        }

        public async Task<List<OrderDto>> GetAllFranchiseOrders(Guid franchiseId)
        {
            var orders = await _franchiseRepository.GetAllFranchiseOrders(franchiseId, DateTime.Today);

            return _mapper.Map<List<Order>, List<OrderDto>>(orders);
        }

        public async Task<List<OrderDto>> GetCustomerOrders(Guid customerId)
        {
            var orders = await _franchiseRepository.GetCustomerOrders(customerId);

            var customerOrdrs = _mapper.Map<List<Order>, List<OrderDto>>(orders);

            return customerOrdrs;
        }

        public async Task<bool> UpdateOrderStatus(Guid orderId, Guid dayId, Guid productByTimingId, Enums.OrderStatus orderStatus, Guid loggedInUserId)
        {
            return await _franchiseRepository.UpdateOrderStatus(orderId, dayId, productByTimingId, orderStatus, loggedInUserId);
        }

        public async Task<LoginResponse> UserLogin(LoginRequestModel loginRequest)
        {
            var userDetails = await _franchiseRepository.UserLogin(loginRequest.EmailAddress, loginRequest.Password);

            if (userDetails == null) { return new LoginResponse() { IsLoggedIn = false }; }

            var currentAppUser = _mapper.Map<FranchiseUser, MealzNowUsers>(userDetails);

            currentAppUser.UserRole = userDetails.UserRole;

            currentAppUser.ContactNumber = "";
            currentAppUser.FranchiseId = userDetails.FranchiseId;
            currentAppUser.FullName = userDetails.FirstName + " " + userDetails.LastName;

            var token = _jwtTokenManager.GenerateToken(currentAppUser);

            return new LoginResponse() { IsLoggedIn = true, Token = token };
        }

        public async Task<FranchiseDto> GetFranchiseById(Guid franchiseId)
        {
            var franchise = await _franchiseRepository.GetFranchisById(franchiseId);

            if (franchise == null)
            {
                return null;
            }

            return _mapper.Map<Franchise, FranchiseDto>(franchise);
        }
    }
}