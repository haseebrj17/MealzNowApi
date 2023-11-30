using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using static MealzNow.Core.Enum.Enums;

namespace MealzNow.Core.Dto
{
    public class OrderDto
    {
        [JsonProperty("totalBill")]
        public decimal TotalBill { get; set; }

        [JsonProperty("totalItems")]
        public int TotalItems { get; set; }

        [JsonProperty("orderDeliveryDateTime")]
        public DateTime OrderDeliveryDateTime { get; set; }

        [JsonProperty("instructions")]
        public string? Instructions { get; set; }

        [JsonProperty("customerId")]
        public Guid CustomerId { get; set; }

        [JsonProperty("customerAddressId")]
        public Guid CustomerAddressId { get; set; }

        [JsonProperty("customerDetails")]
        public CustomerDetailsDto CustomerDetails { get; set; }

        [JsonProperty("franchiseId")]
        public Guid FranchiseId { get; set; }

        [JsonProperty("orderStatus")]
        public OrderStatus OrderStatus { get; set; }

        [JsonProperty("customerOrderedPackage")]
        public CustomerOrderedPackageDto CustomerOrderedPackage { get; set; }

        [JsonProperty("productByDay")]
        public List<ProductByDayDto> ProductByDay { get; set; }

        [JsonProperty("customerOrderPromo")]
        public CustomerOrderPromoDto CustomerOrderPromo { get; set; }

        [JsonProperty("customerOrderPayment")]
        public CustomerOrderPaymentDto CustomerOrderPayment { get; set; }
    }

    public class CustomerDetailsDto
    {
        [JsonProperty("customerFullName")]
        public string CustomerFullName { get; set; }

        [JsonProperty("customerEmailAddress")]
        public string CustomerEmailAddress { get; set; }

        [JsonProperty("customerContactNumber")]
        public string CustomerContactNumber { get; set; }

        [JsonProperty("customerAddressDetail")]
        public CustomerAddressDetailDto CustomerAddressDetail { get; set; }
    }

    public class CustomerAddressDetailDto
    {
        [JsonProperty("streetAddress")]
        public string StreetAddress { get; set; }

        [JsonProperty("house")]
        public string? House { get; set; }

        [JsonProperty("postalCode")]
        public string? PostalCode { get; set; }

        [JsonProperty("cityName")]
        public string? CityName { get; set; }

        [JsonProperty("district")]
        public string? District { get; set; }

        [JsonProperty("unitNumber")]
        public string? UnitNumber { get; set; }

        [JsonProperty("floorNumber")]
        public string? FloorNumber { get; set; }

        [JsonProperty("stateName")]
        public string? StateName { get; set; }

        [JsonProperty("countryName")]
        public string? CountryName { get; set; }

        [JsonProperty("notes")]
        public string? Notes { get; set; }

        [JsonProperty("latitude")]
        public decimal Latitude { get; set; }

        [JsonProperty("longitude")]
        public decimal Longitude { get; set; }

        [JsonProperty("cityId")]
        public Guid CityId { get; set; }
    }

    public class CustomerOrderedPackageDto
    {
        [JsonProperty("packageId")]
        public Guid PackageId { get; set; }

        [JsonProperty("packageName")]
        public string PackageName { get; set; }

        [JsonProperty("totalNumberOfMeals")]
        public int TotalNumberOfMeals { get; set; }

        [JsonProperty("numberOfDays")]
        public int NumberOfDays { get; set; }
    }

    public class CustomerOrderPromoDto
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("percent")]
        public string Percent { get; set; }
    }

    public class CustomerOrderPaymentDto
    {
        [JsonProperty("paymentType")]
        public string PaymentType { get; set; }

        [JsonProperty("orderType")]
        public OrderType OrderType { get; set; }
    }

    public class ProductByDayDto
    {
        [JsonProperty("day")]
        public string Day { get; set; }

        [JsonProperty("dayId")]
        public Guid DayId { get; set; }

        [JsonProperty("deliveryDate")]
        public DateTime DeliveryDate { get; set; }

        [JsonProperty("productByTiming")]
        public List<ProductByTimingDto> ProductByTiming { get; set; }
    }

    public class ProductByTimingDto
    {
        [JsonProperty("fulfilled")]
        public bool Fulfilled { get; set; }

        [JsonProperty("timeOfDay")]
        public string TimeOfDay { get; set; }

        [JsonProperty("timeOfDayId")]
        public Guid TimeOfDayId { get; set; }

        [JsonProperty("deliveryTimings")]
        public DateTime DeliveryTimings { get; set; }

        [JsonProperty("deliveryTimingsId")]
        public Guid DeliveryTimingsId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("detail")]
        public string Detail { get; set; }

        [JsonProperty("estimatedDeliveryTime")]
        public string? EstimatedDeliveryTime { get; set; }

        [JsonProperty("spiceLevel")]
        public int? SpiceLevel { get; set; }

        [JsonProperty("ingredientSummary")]
        public string IngredientSummary { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("orderedProductExtraDipping")]
        public List<OrderedProductExtraDippingDto> OrderedProductExtraDipping { get; set; }

        [JsonProperty("orderedProductExtraTopping")]
        public List<OrderedProductExtraToppingDto> OrderedProductExtraTopping { get; set; }

        [JsonProperty("orderedProductSides")]
        public OrderedProductSidesDto OrderedProductSides { get; set; }

        [JsonProperty("orderedProductDessert")]
        public OrderedProductDessertDto OrderedProductDessert { get; set; }

        [JsonProperty("orderedProductDrinks")]
        public OrderedProductDrinksDto OrderedProductDrinks { get; set; }
    }

    public class OrderedProductExtraDippingDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }
    }

    public class OrderedProductExtraToppingDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }
    }

    public class OrderedProductSidesDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }
    }

    public class OrderedProductDessertDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }
    }

    public class OrderedProductDrinksDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }
    }
}