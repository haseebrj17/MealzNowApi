﻿using AutoMapper;
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
using Expo.Server.Client;
using Expo.Server.Models;
using Azure;
using Azure.Communication.Sms;
using Microsoft.Extensions.Logging;

namespace MealzNow.Services.Services
{
    public class FranchiseService : IFranchiseService
    {
        private readonly IFranchiseRepository _franchiseRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly IJwtTokenManager _jwtTokenManager;
        private readonly ILogger _logger;

        public FranchiseService(IMapper mapper, IFranchiseRepository franchiseRepository,
                 IJwtTokenManager jwtTokenManager, IOrderRepository orderRepository, ILoggerFactory loggerFactory)
        {
            _mapper = mapper;
            _franchiseRepository = franchiseRepository;
            _orderRepository = orderRepository;
            _jwtTokenManager = jwtTokenManager;
            _logger = loggerFactory.CreateLogger<CustomerService>();
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
            var updateSuccess = await _franchiseRepository.UpdateOrderStatus(orderId, dayId, productByTimingId, orderStatus, loggedInUserId);

            if (updateSuccess)
            {
                var order = await _orderRepository.GetOrderById(orderId);
                if (order != null && order.CustomerId.ToString() != null)
                {
                    string message = GetStatusMessage(orderStatus);

                    if (!string.IsNullOrEmpty(order.CustomerDetails.CustomerContactNumber))
                    {
                        await SendSms(order.CustomerDetails.CustomerContactNumber, message);
                    }

                    var activeDevice = order?.CustomerDevice?.Find(d => d.IsActive);

                    if (!string.IsNullOrEmpty(activeDevice?.DeviceId))
                    {
                        await SendExpoPushNotification(activeDevice.DeviceId, message);
                    }
                }
            }

            return updateSuccess;
        }

        private async Task SendExpoPushNotification(string deviceToken, string message)
        {
            var expoSDKClient = new PushApiClient();
            var pushTicketReq = new PushTicketRequest()
            {
                PushTo = new List<string>() { deviceToken },
                PushBadgeCount = 1,
                PushBody = message
            };

            var result = await expoSDKClient.PushSendAsync(pushTicketReq);

            if (result?.PushTicketErrors?.Any() == true)
            {
                foreach (var error in result.PushTicketErrors)
                {
                    Console.WriteLine($"Error: {error.ErrorCode} - {error.ErrorMessage}");
                }
            }
        }

        private async Task SendSms(string contactNumber, string message)
        {
            var connectionString = "endpoint=https://foodsnowcs.switzerland.communication.azure.com/;accesskey=I0YaWzdEMfzRNEqHdEyL3JFxDvEmg67/jllqoz1OEI1SelvCL1PkV/VO6jXk2Cfka3WZKhPsypfpOxpBNEBGAw==";
            var smsClient = new SmsClient(connectionString);
            try
            {
                var sendResult = await smsClient.SendAsync(
                    from: "BytezNow",
                    to: contactNumber,
                    message: message);

                if (sendResult.Value.Successful)
                {
                    _logger.LogInformation($"SMS sent successfully. Sms id: {sendResult.Value.MessageId}");
                }
                else
                {
                    _logger.LogWarning($"Failed to send SMS. Error: {sendResult.Value.ErrorMessage}");
                }
            }
            catch (RequestFailedException ex)
            {
                _logger.LogError($"Request failed: {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Unexpected error: {ex.Message}");
            }
        }

        private string GetStatusMessage(Enums.OrderStatus status)
        {
            switch (status)
            {
                case Enums.OrderStatus.OrderPlaced:
                    return "Your order has been placed successfully.";
                case Enums.OrderStatus.InProcess:
                    return "Your order is currently being processed.";
                case Enums.OrderStatus.ReadyForDelivery:
                    return "Your order is ready for delivery.";
                case Enums.OrderStatus.Shipped:
                    return "Your order has been shipped.";
                case Enums.OrderStatus.Delivered:
                    return "Your order has been delivered.";
                default:
                    return "There is an update on your order.";
            }
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

        public async Task<bool> UpdateDishStatus(Guid Id, Enums.Status status, Guid loggedInUserId)
        {
            var updateSuccess = await _franchiseRepository.UpdateDishStatus(Id, status, loggedInUserId);

            return updateSuccess;
        }

        public async Task<bool> UpdateBrandStatus(Guid Id, Enums.Status status, Guid loggedInUserId)
        {
            var updateSuccess = await _franchiseRepository.UpdateBrandStatus(Id, status, loggedInUserId);

            return updateSuccess;
        }

        public async Task<bool> UpdateFranchiseStatus(Guid Id, Enums.Status status, Guid loggedInUserId)
        {
            var updateSuccess = await _franchiseRepository.UpdateFranchiseStatus(Id, status, loggedInUserId);

            return updateSuccess;
        }

        public async Task<bool> UpdateSubCategoryStatus(Guid Id, Guid BrandId, Enums.Status status, Guid loggedInUserId)
        {
            var updateSuccess = await _franchiseRepository.UpdateSubCategoryStatus(Id, BrandId, status, loggedInUserId);

            return updateSuccess;
        }

        public async Task<bool> UpdateCategoryStatus(Guid Id, Enums.Status status, Guid loggedInUserId)
        {
            var updateSuccess = await _franchiseRepository.UpdateCategoryStatus(Id, status, loggedInUserId);

            return updateSuccess;
        }

        public async Task<bool> UpdateToppingStatus(Guid Id, Guid DishId, Enums.Status status, Guid loggedInUserId)
        {
            var updateSuccess = await _franchiseRepository.UpdateToppingStatus(Id, DishId, status, loggedInUserId);

            return updateSuccess;
        }

        public async Task<bool> UpdateDippingStatus(Guid Id, Guid DishId, Enums.Status status, Guid loggedInUserId)
        {
            var updateSuccess = await _franchiseRepository.UpdateDippingStatus(Id, DishId, status, loggedInUserId);

            return updateSuccess;
        }
    }
}