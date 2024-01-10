using AutoMapper;
using MealzNow.Core.Dto;
using MealzNow.Db.Models;
using MealzNow.Db.Repositories;
using MealzNow.Services.Interfaces;

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

                var customer = await _customerRepository.GetById(orderDto.CustomerId);
                if (customer == null) throw new InvalidOperationException("Customer not found.");

                var customerAddress = await _customerAddressRepository.GetAddressById(orderDto.CustomerAddressId, orderDto.CustomerId);
                if (customerAddress == null) throw new InvalidOperationException("Customer address not found.");

                var franchiseSettings = await _franchiseRepository.GetFranchiseSettingById(orderDto.FranchiseId);
                if (franchiseSettings == null) throw new InvalidOperationException("Franchise not found.");

                decimal totalBill = 0;

                order.CustomerId = customer.Id;
                order.CustomerAddressId = customerAddress.Id;
                order.FranchiseId = orderDto.FranchiseId;
                order.CreatedDateTimeUtc = DateTime.UtcNow;
                order.UpdatedDateTimeUtc = DateTime.UtcNow;
                order.OrderStatus = MealzNow.Core.Enum.Enums.OrderStatus.OrderPlaced;
                order.TotalItems = orderDto.CustomerOrderedPackage.TotalNumberOfMeals;
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
                } ?? null;

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
                        var productByTiming = new ProductByTiming
                        {
                            TimeOfDay = productByTimingDto?.TimeOfDay,
                            TimeOfDayId = productByTimingDto.TimeOfDayId,
                            DeliveryTimings = productByTimingDto.DeliveryTimings,
                            DeliveryTimingsId = productByTimingDto.DeliveryTimingsId,
                            Name = productByTimingDto.Name,
                            EstimatedDeliveryTime = productByTimingDto.EstimatedDeliveryTime,
                            Image = productByTimingDto.Image,
                            Price = productByTimingDto.Price,

                            OrderedProductExtraDipping = productByTimingDto.OrderedProductExtraDipping.Select(dip => new OrderedProductExtraDipping
                            {
                                Name = dip.Name,
                                Price = dip.Price
                            }).ToList() ?? null,

                            OrderedProductExtraTopping = productByTimingDto.OrderedProductExtraTopping.Select(top => new OrderedProductExtraTopping
                            {
                                Name = top.Name,
                                Price = top.Price
                            }).ToList() ?? null,

                            OrderedProductSides = productByTimingDto.OrderedProductSides != null ? new OrderedProductSides
                            {
                                Name = productByTimingDto.OrderedProductSides.Name,
                                Price = productByTimingDto.OrderedProductSides.Price
                            } : null,

                            OrderedProductDessert = productByTimingDto.OrderedProductDessert != null ? new OrderedProductDessert
                            {
                                Name = productByTimingDto.OrderedProductDessert.Name,
                                Price = productByTimingDto.OrderedProductDessert.Price
                            } : null,

                            OrderedProductDrinks = productByTimingDto.OrderedProductDrinks != null ? new OrderedProductDrinks
                            {
                                Name = productByTimingDto.OrderedProductDrinks.Name,
                                Price = productByTimingDto.OrderedProductDrinks.Price
                            } : null
                        };

                        totalBill += productByTiming.Price;
                        if (productByTiming.OrderedProductExtraDipping != null) totalBill += productByTiming.OrderedProductExtraDipping.Sum(dip => dip.Price);
                        if (productByTiming.OrderedProductExtraTopping != null) totalBill += productByTiming.OrderedProductExtraTopping.Sum(top => top.Price);
                        if (productByTiming.OrderedProductSides != null) totalBill += productByTiming.OrderedProductSides.Price;
                        if (productByTiming.OrderedProductDessert != null) totalBill += productByTiming.OrderedProductDessert.Price;
                        if (productByTiming.OrderedProductDrinks != null) totalBill += productByTiming.OrderedProductDrinks.Price;

                        productByDay.ProductByTiming.Add(productByTiming);
                    }

                    order.ProductByDay.Add(productByDay);
                }

                order.TotalBill = totalBill;

                await _orderRepository.AddOrder(order);

                return order.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

    }
}