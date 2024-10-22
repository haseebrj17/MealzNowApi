﻿using MealzNow.Core.Dto;
using MealzNow.Core.RequestModels;
using MealzNow.Services;
using MealzNow.Services.Interfaces;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;
using static MealzNow.Core.Enum.Enums;

namespace MealzNow.Api
{
    public class CustomerApi
    {
        private readonly ILogger _logger;
        private readonly ICustomerService _customerService;
        private readonly IJwtTokenManager _jwtTokenManager;

        public CustomerApi(ILoggerFactory loggerFactory, ICustomerService customerService, IJwtTokenManager jwtTokenManager)
        {
            _logger = loggerFactory.CreateLogger<CustomerApi>();
            _customerService = customerService;
            _jwtTokenManager = jwtTokenManager;
        }

        [Function(nameof(Register))]
        public async Task<HttpResponseData> Register([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req)
        {
            _logger.LogInformation("Calling Register function");

            var content = await new StreamReader(req.Body).ReadToEndAsync();

            if (content == null)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            var request = JsonConvert.DeserializeObject<CustomerDto>(content);

            if (request == null)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            if (string.IsNullOrWhiteSpace(request.ContactNumber))
                return req.CreateResponse(HttpStatusCode.BadRequest);

            var data = await _customerService.AddCustomer(request);

            var response = req.CreateResponse(HttpStatusCode.OK);
            if (data == null)
            {
                await response.WriteAsJsonAsync(new { isSuccess = false, ErrorMessage = "Customer with this detail already exist" });
            }
            else
            {
                await response.WriteAsJsonAsync(new { isSuccess = true, data });

            }

            return response;
        }

        [Function(nameof(VerifyPin))]
        public async Task<HttpResponseData> VerifyPin([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req)
        {
            _logger.LogInformation("Calling Verifiy pin function");

            var content = await new StreamReader(req.Body).ReadToEndAsync();

            if (content == null)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            var request = JsonConvert.DeserializeObject<CustomerDto>(content);

            if (request == null)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            if (string.IsNullOrWhiteSpace(request.Code))
                return req.CreateResponse(HttpStatusCode.BadRequest);

            if (request.Id == Guid.Empty)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            var data = await _customerService.VerifyPin(request.Code, request.Id.Value);

            var response = req.CreateResponse(HttpStatusCode.OK);

            await response.WriteAsJsonAsync(data);

            return response;
        }

        [Function(nameof(CustomerLogin))]
        public async Task<HttpResponseData> CustomerLogin([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req)
        {
            _logger.LogInformation("Calling Cutomer Login function");

            var content = await new StreamReader(req.Body).ReadToEndAsync();

            if (content == null)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            var request = JsonConvert.DeserializeObject<LoginRequestModel>(content);

            if (request == null)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            if (string.IsNullOrWhiteSpace(request.EmailAddress))
                return req.CreateResponse(HttpStatusCode.BadRequest);

            if (string.IsNullOrWhiteSpace(request.Password))
                return req.CreateResponse(HttpStatusCode.BadRequest);

            var data = await _customerService.CustomerLogin(request);

            var response = req.CreateResponse(HttpStatusCode.OK);

            await response.WriteAsJsonAsync(data);

            return response;
        }

        [Function(nameof(CustomerAddAddress))]
        public async Task<HttpResponseData> CustomerAddAddress([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req)
        {
            _logger.LogInformation("Calling Customer Add Address function");

            var loggedInUser = _jwtTokenManager.ValidateToken(req, new List<UserRole> { UserRole.Customer });

            if (loggedInUser == null)
                return req.CreateResponse(HttpStatusCode.Unauthorized);

            var content = await new StreamReader(req.Body).ReadToEndAsync();

            if (content == null)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            var request = JsonConvert.DeserializeObject<CustomerAddressDto>(content);

            if (request == null)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            if (string.IsNullOrWhiteSpace(request.CityName))
                return req.CreateResponse(HttpStatusCode.BadRequest);

            if (loggedInUser.Id.HasValue)
            {
                request.CustomerId = loggedInUser.Id.Value;
            }
            else
            {
                _logger.LogError("Logged in user ID is null.");
                return req.CreateResponse(HttpStatusCode.Unauthorized);
            }

            var data = await _customerService.AddAddress(request);

            var response = req.CreateResponse(HttpStatusCode.OK);
            await response.WriteAsJsonAsync(new { isSuccess = data != null, ErrorMessage = data != null ? "" : "Adding address failed" });

            return response;
        }

        [Function(nameof(CustomerUpdateAddress))]
        public async Task<HttpResponseData> CustomerUpdateAddress([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req)
        {
            _logger.LogInformation("Calling Register function");

            var loggedInUser = _jwtTokenManager.ValidateToken(req, new List<UserRole> { UserRole.Customer });

            if (loggedInUser == null)
                return req.CreateResponse(HttpStatusCode.Unauthorized);

            var content = await new StreamReader(req.Body).ReadToEndAsync();

            if (content == null)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            var request = JsonConvert.DeserializeObject<CustomerAddressDto>(content);

            if (request == null)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            if (string.IsNullOrWhiteSpace(request.CityName))
                return req.CreateResponse(HttpStatusCode.BadRequest);

            if (loggedInUser.Id.HasValue)
            {
                request.CustomerId = loggedInUser.Id.Value;
            }
            else
            {
                _logger.LogError("Logged in user ID is null.");
                return req.CreateResponse(HttpStatusCode.Unauthorized);
            }

            var data = await _customerService.UpdateAddress(request);

            var response = req.CreateResponse(HttpStatusCode.OK);
            await response.WriteAsJsonAsync(new { isSuccess = data != null, ErrorMessage = data != null ? "" : "Updating address failed" });

            return response;
        }

        [Function(nameof(DeleteMyAccount))]
        public async Task<HttpResponseData> DeleteMyAccount([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req)
        {
            _logger.LogInformation("Calling DeleteMyAccount function");

            var loggedInUser = _jwtTokenManager.ValidateToken(req, new List<UserRole> { UserRole.Customer });

            if (loggedInUser == null)
                return req.CreateResponse(HttpStatusCode.Unauthorized);

            var data = await _customerService.DeleteMyAccount(loggedInUser.Id.Value);

            var response = req.CreateResponse(HttpStatusCode.OK);

            await response.WriteAsJsonAsync(data);

            return response;
        }

        [Function(nameof(GetCustomerAddresses))]
        public async Task<HttpResponseData> GetCustomerAddresses([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req)
        {
            _logger.LogInformation("Calling GetCustomerAddresses function");

            var loggedInUser = _jwtTokenManager.ValidateToken(req, new List<UserRole> { UserRole.Customer });

            if (loggedInUser == null)
                return req.CreateResponse(HttpStatusCode.Unauthorized);

            var data = await _customerService.GetAllAddresses(loggedInUser.Id.Value);

            var response = req.CreateResponse(HttpStatusCode.OK);

            await response.WriteAsJsonAsync(data);

            return response;
        }
    }
}