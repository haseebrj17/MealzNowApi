using AutoMapper;
using MealzNow.Core.Dto;
using MealzNow.Db.Models;
using MealzNow.Db.Repositories;
using MealzNow.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MealzNow.Services.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICustomerAddressRepository _customerAddressRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IFranchiseRepository _franchiseRepository;
        private readonly IMapper _mapper;

        public OrderService(IMapper mapper, IOrderRepository orderRepository, IProductRepository productRepository, ICustomerAddressRepository customerAddressRepository,
            ICustomerRepository customerRepository, IFranchiseRepository franchiseRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _customerAddressRepository = customerAddressRepository;
            _customerRepository = customerRepository;
            _franchiseRepository = franchiseRepository;
        }

        public async Task<Guid?> PlaceOrder(OrderDto orderDto)
        {
            try
            {
                var order = _mapper.Map<OrderDto, Order>(orderDto);

                var customer = await _customerRepository.GetById(orderDto.CustomerId) ?? throw new InvalidOperationException("Customer not found.");

                var customerAddress = (customer?.CustomerAddresses?.Find(a => a.Id == orderDto.CustomerAddressId)) ?? throw new InvalidOperationException("Customer address not found.");

                order.TotalBill = orderDto.TotalBill;
                order.TotalItems = orderDto.CustomerOrderedPackage.TotalNumberOfMeals;
                order.OrderDeliveryDateTime = orderDto.OrderDeliveryDateTime;
                order.Instructions = orderDto.Instructions ?? null;
                order.CustomerId = customer.Id;
                order.CustomerAddressId = customerAddress.Id;
                order.FranchiseId = orderDto.FranchiseId;
                order.CreatedById = orderDto.CustomerId;
                order.CreatedDateTimeUtc = DateTime.UtcNow;
                order.UpdatedDateTimeUtc = DateTime.UtcNow;
                order.OrderStatus = MealzNow.Core.Enum.Enums.OrderStatus.OrderPlaced;
                order.CustomerDetails = new CustomerDetails
                {
                    CustomerFullName = customer.FullName,
                    CustomerEmailAddress = customer.EmailAddress,
                    CustomerContactNumber = customer.ContactNumber,
                    CustomerAddressDetail = new CustomerAddressDetail
                    {
                        StreetAddress = customerAddress.StreetAddress,
                        House = customerAddress.House,
                        PostalCode = customerAddress.PostalCode,
                        CityName = customerAddress.CityName,
                        District = customerAddress.District,
                        UnitNumber = customerAddress.UnitNumber,
                        FloorNumber = customerAddress.FloorNumber,
                        StateName = customerAddress.StateName,
                        CountryName = customerAddress.CountryName,
                        Notes = customerAddress.Notes,
                        Latitude = customerAddress.Latitude,
                        Longitude = customerAddress.Longitude,
                        CityId = customerAddress.CityId
                    }
                };

                order.CustomerOrderedPackage = new CustomerOrderedPackage
                {
                    PackageId = orderDto.CustomerOrderedPackage.PackageId,
                    PackageName = orderDto.CustomerOrderedPackage.PackageName,
                    TotalNumberOfMeals = orderDto.CustomerOrderedPackage.TotalNumberOfMeals,
                    NumberOfDays = orderDto.CustomerOrderedPackage.NumberOfDays,
                    Timings = orderDto.CustomerOrderedPackage.Timings,
                    MealzPerDay = orderDto.CustomerOrderedPackage.MealzPerDay,
                    NumberOfWeeks = orderDto.CustomerOrderedPackage.NumberOfWeeks
                };

                order.CustomerOrderPayment = new CustomerOrderPayment
                {
                    PaymentType = orderDto.CustomerOrderPayment.PaymentType,
                    OrderType = orderDto.CustomerOrderPayment.OrderType
                };


                order.CustomerOrderPromo = new CustomerOrderPromo
                {
                    Type = orderDto.CustomerOrderPromo.Type,
                    Name = orderDto.CustomerOrderPromo.Name,
                    Percent = orderDto.CustomerOrderPromo.Percent
                };

                order.CustomerDevice = customer.CustomerDevice?.Select(device => new CustomerDevice
                {
                    DeviceId = device.DeviceId,
                    IsActive = device.IsActive
                }).ToList() ?? new List<CustomerDevice>();

                foreach (var productByDayDto in orderDto.ProductByDay)
                {
                    var productByDay = new ProductByDay
                    {
                        Day = productByDayDto.Day,
                        DayId = productByDayDto.DayId,
                        DeliveryDate = productByDayDto.DeliveryDate,
                        ProductByTiming = new List<ProductByTiming>()
                    };

                    foreach (var productByTimingDto in productByDayDto.ProductByTiming)
                    {
                        string compositeId = $"{productByTimingDto.Id}_{productByTimingDto.DeliveryTimingsId}_{productByTimingDto.TimeOfDayId}_{productByDayDto.DeliveryDate:yyyyMMdd}";
                        var productByTiming = new ProductByTiming
                        {
                            CompositeId = compositeId,
                            Id = productByTimingDto.Id,
                            Fulfilled = false,
                            TimeOfDay = productByTimingDto.TimeOfDay,
                            TimeOfDayId = productByTimingDto.TimeOfDayId,
                            DeliveryTimings = productByTimingDto.DeliveryTimings,
                            DeliveryTimingsId = productByTimingDto.DeliveryTimingsId,
                            Name = productByTimingDto.Name,
                            Detail = productByTimingDto.Detail,
                            EstimatedDeliveryTime = productByTimingDto.EstimatedDeliveryTime,
                            SpiceLevel = productByTimingDto.SpiceLevel,
                            Type = productByTimingDto.Type,
                            IngredientSummary = productByTimingDto.IngredientSummary,
                            Image = productByTimingDto.Image,
                            Price = productByTimingDto.Price,

                            OrderedProductExtraDipping = productByTimingDto.OrderedProductExtraDipping?.Select(dip => new OrderedProductExtraDipping
                            {
                                Name = dip.Name,
                                Price = dip.Price
                            }).ToList() ?? new List<OrderedProductExtraDipping>(),

                            OrderedProductExtraTopping = productByTimingDto.OrderedProductExtraTopping?.Select(top => new OrderedProductExtraTopping
                            {
                                Name = top.Name,
                                Price = top.Price
                            }).ToList() ?? new List<OrderedProductExtraTopping>(),

                            OrderedProductSides = productByTimingDto.OrderedProductSides != null ? new OrderedProductSides
                            {
                                Name = productByTimingDto.OrderedProductSides.Name,
                                Price = productByTimingDto.OrderedProductSides.Price
                            } : new OrderedProductSides(),

                            OrderedProductDessert = productByTimingDto.OrderedProductDessert != null ? new OrderedProductDessert
                            {
                                Name = productByTimingDto.OrderedProductDessert.Name,
                                Price = productByTimingDto.OrderedProductDessert.Price
                            } : new OrderedProductDessert(),

                            OrderedProductDrinks = productByTimingDto.OrderedProductDrinks != null ? new OrderedProductDrinks
                            {
                                Name = productByTimingDto.OrderedProductDrinks.Name,
                                Price = productByTimingDto.OrderedProductDrinks.Price
                            } : new OrderedProductDrinks(),

                            OrderedProductChoices = productByTimingDto.OrderedProductChoices?.Select(top => new OrderedProductChoices
                            {
                                Name = top.Name,
                                Detail = top.Detail
                            }).ToList() ?? new List<OrderedProductChoices>(),
                        };

                        productByDay.ProductByTiming.Add(productByTiming);
                    }

                    order.ProductByDay.Add(productByDay);
                }

                await _orderRepository.AddOrder(order);

                return order.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

    }
}