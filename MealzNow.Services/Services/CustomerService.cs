using System.Net.Mail;
using AutoMapper;
using Azure.Communication.Sms;
using MealzNow.Core;
using MealzNow.Core.Dto;
using MealzNow.Core.RequestModels;
using MealzNow.Core.ResponseModels;
using MealzNow.Db.Models;
using MealzNow.Db.Repositories;
using MealzNow.Services;
using MealzNow.Services.Interfaces;
using Microsoft.Extensions.Logging;
using static MealzNow.Core.Enum.Enums;

namespace MealzNow.Services.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerAddressRepository _customerAddressRepository;
        private readonly IMapper _mapper;
        private readonly IJwtTokenManager _jwtTokenManager;
        private readonly ICityRepository _cityRepository;
        private readonly ILogger<CustomerService> _logger;

        public CustomerService(IMapper mapper, ICustomerRepository customerRepository, ICustomerAddressRepository customerAddressRepository,
                 ICityRepository _cityRepository, IJwtTokenManager jwtTokenManager, ILogger<CustomerService> logger)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            _customerAddressRepository = customerAddressRepository;
            _jwtTokenManager = jwtTokenManager;
            _logger = logger;
        }

        public async Task<CustomerDto> AddCustomer(CustomerDto customerDto)
        {
            var customer = _mapper.Map<CustomerDto, Customer>(customerDto);

            if (customer == null) { return null; }

            var newCustomer = await _customerRepository.Add(customer);

            if (newCustomer == null) { return null; }

            var response = _mapper.Map<Customer, CustomerDto>(newCustomer);

            await SendSms(customer);

            return response;
        }

        private async Task SendSms(Customer customer)
        {
            try
            {
                var connectionString = "endpoint=https://foodsnowcs.switzerland.communication.azure.com/;accesskey=I0YaWzdEMfzRNEqHdEyL3JFxDvEmg67/jllqoz1OEI1SelvCL1PkV/VO6jXk2Cfka3WZKhPsypfpOxpBNEBGAw==";
                var smsClient = new SmsClient(connectionString);
                var sendResult = await smsClient.SendAsync(
                    from: "MealzNow",
                    to: customer.ContactNumber,
                    message: customer.VerificationCode);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while sending SMS to {PhoneNumber}", customer.ContactNumber);
            }
        }

        public async Task<CustomerAddressDto> AddAddress(CustomerAddressDto addressDto)
        {
            var address = _mapper.Map<CustomerAddressDto, CustomerAddresses>(addressDto);

            if (address == null) { return null; }

            var cityId = await _cityRepository.GetCityIdByName(addressDto.CityName, addressDto.StateName, addressDto.CountryName);

            if (cityId == null || cityId == Guid.Empty)
            {
                cityId = await _cityRepository.AddCity(addressDto.CityName, addressDto.StateName, addressDto.CountryName);
            }

            address.CityId = cityId.Value;

            var customer = await _customerAddressRepository.AddAddress(addressDto.CustomerId, address);

            if (customer == null) { return null; }

            var newAddress = customer.CustomerAddresses.LastOrDefault();

            return _mapper.Map<CustomerAddresses, CustomerAddressDto>(newAddress);
        }

        public async Task<LoginResponse> CustomerLogin(LoginRequestModel loginRequest)
        {
            var customerDetails = await _customerRepository.CustomerLogin(loginRequest.EmailAddress, loginRequest.Password);

            if (customerDetails == null) { return new LoginResponse() { IsLoggedIn = false }; }

            var currentAppUser = _mapper.Map<Customer, MealzNowUsers>(customerDetails);

            currentAppUser.UserRole = UserRole.Customer;

            var token = _jwtTokenManager.GenerateToken(currentAppUser);

            return new LoginResponse() { IsLoggedIn = true, Token = token, IsNumberVerified = customerDetails.IsNumberVerified };

        }

        public async Task<bool> UpdateAddress(CustomerAddressDto addressDto)
        {
            var address = _mapper.Map<CustomerAddressDto, CustomerAddresses>(addressDto);

            var cityId = await _cityRepository.GetCityIdByName(addressDto.CityName, addressDto.StateName, addressDto.CountryName);

            if (cityId == null || cityId == Guid.Empty)
            {
                return false;
            }

            address.CityId = cityId.Value;

            if (address == null) { return false; }

            return await _customerAddressRepository.UpdateAddress(addressDto.CustomerId, address);
        }

        public async Task<LoginResponse> VerifyPin(string pin, Guid customerId)
        {
            var isVerified = await _customerRepository.VerifyPin(pin, customerId);

            if (!isVerified)
            {
                return new LoginResponse() { IsLoggedIn = false, IsNumberVerified = false };
            }

            var customer = await _customerRepository.GetById(customerId);

            var currentAppUser = _mapper.Map<Customer, MealzNowUsers>(customer);

            currentAppUser.UserRole = UserRole.Customer;

            var token = _jwtTokenManager.GenerateToken(currentAppUser);
            return new LoginResponse() { IsLoggedIn = true, Token = token, IsNumberVerified = customer.IsNumberVerified };
        }

        public async Task<List<CustomerAddressDto>> GetAllAddresses(Guid customerId)
        {
            var customer = await _customerAddressRepository.GetAllAddresses(customerId);

            if (customer == null || customer.CustomerAddresses == null)
            {
                return new List<CustomerAddressDto>();
            }

            var addresses = _mapper.Map<List<CustomerAddresses>, List<CustomerAddressDto>>(customer.CustomerAddresses);

            foreach (var address in addresses)
            {
                var city = await _cityRepository.GetCityById(address.CityId);
                address.CityName = city?.Name;
            }

            return addresses;
        }


        public async Task<bool> DeleteMyAccount(Guid customerId)
        {
            return await _customerRepository.DeleteMyAccount(customerId);
        }
    }
}