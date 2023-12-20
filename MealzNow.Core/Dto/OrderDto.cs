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
        public CustomerDetailsDto CustomerDetails { get; set; } = null!;

        [JsonProperty("franchiseId")]
        public Guid FranchiseId { get; set; }

        [JsonProperty("orderStatus")]
        public OrderStatus OrderStatus { get; set; }

        [JsonProperty("customerOrderedPackage")]
        public CustomerOrderedPackageDto CustomerOrderedPackage { get; set; } = null!;

        [JsonProperty("productByDay")]
        public List<ProductByDayDto> ProductByDay { get; set; } = null!;

        [JsonProperty("customerOrderPromo")]
        public CustomerOrderPromoDto CustomerOrderPromo { get; set; } = null!;

        [JsonProperty("customerOrderPayment")]
        public CustomerOrderPaymentDto CustomerOrderPayment { get; set; } = null!;
    }

    public class CustomerDetailsDto
    {
        [JsonProperty("customerFullName")]
        public string CustomerFullName { get; set; } = null!;

        [JsonProperty("customerEmailAddress")]
        public string CustomerEmailAddress { get; set; } = null!;

        [JsonProperty("customerContactNumber")]
        public string CustomerContactNumber { get; set; } = null!;

        [JsonProperty("customerAddressDetail")]
        public CustomerAddressDetailDto CustomerAddressDetail { get; set; } = null!;
    }

    public class CustomerAddressDetailDto
    {
        [JsonProperty("streetAddress")]
        public string StreetAddress { get; set; } = null!;

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
        public string PackageName { get; set; } = null!;

        [JsonProperty("totalNumberOfMeals")]
        public int TotalNumberOfMeals { get; set; }

        [JsonProperty("numberOfDays")]
        public int NumberOfDays { get; set; }
    }

    public class CustomerOrderPromoDto
    {
        [JsonProperty("type")]
        public string Type { get; set; } = null!;

        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [JsonProperty("percent")]
        public string Percent { get; set; } = null!;
    }

    public class CustomerOrderPaymentDto
    {
        [JsonProperty("paymentType")]
        public string PaymentType { get; set; } = null!;

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
        public List<ProductByTimingDto> ProductByTiming { get; set; } = null!;
    }

    public class ProductByTimingDto
    {
        [JsonProperty("fulfilled")]
        public bool Fulfilled { get; set; }

        [JsonProperty("timeOfDay")]
        public string TimeOfDay { get; set; } = null!;

        [JsonProperty("timeOfDayId")]
        public Guid TimeOfDayId { get; set; }

        [JsonProperty("deliveryTimings")]
        public DateTime DeliveryTimings { get; set; }

        [JsonProperty("deliveryTimingsId")]
        public Guid DeliveryTimingsId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [JsonProperty("detail")]
        public string Detail { get; set; } = null!;

        [JsonProperty("estimatedDeliveryTime")]
        public string? EstimatedDeliveryTime { get; set; }

        [JsonProperty("spiceLevel")]
        public int? SpiceLevel { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("ingredientSummary")]
        public string IngredientSummary { get; set; } = null!;

        [JsonProperty("image")]
        public string Image { get; set; } = null!;

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("orderedProductExtraDipping")]
        public List<OrderedProductExtraDippingDto> OrderedProductExtraDipping { get; set; } = null!;

        [JsonProperty("orderedProductExtraTopping")]
        public List<OrderedProductExtraToppingDto> OrderedProductExtraTopping { get; set; } = null!;

        [JsonProperty("orderedProductSides")]
        public OrderedProductSidesDto OrderedProductSides { get; set; } = null!;

        [JsonProperty("orderedProductDessert")]
        public OrderedProductDessertDto OrderedProductDessert { get; set; } = null!;

        [JsonProperty("orderedProductDrinks")]
        public OrderedProductDrinksDto OrderedProductDrinks { get; set; } = null!;

        [JsonProperty("orderedProductChoices")]
        public List<OrderedProductChoicesDtp> OrderedProductChoices { get; set; } = new List<OrderedProductChoicesDtp>();
    }

    public class OrderedProductChoicesDtp
    {
        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [JsonProperty("detail")]
        public string Detail { get; set; } = null!;
    }

    public class OrderedProductExtraDippingDto
    {
        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [JsonProperty("price")]
        public decimal Price { get; set; }
    }

    public class OrderedProductExtraToppingDto
    {
        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [JsonProperty("price")]
        public decimal Price { get; set; }
    }

    public class OrderedProductSidesDto
    {
        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [JsonProperty("price")]
        public decimal Price { get; set; }
    }

    public class OrderedProductDessertDto
    {
        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [JsonProperty("price")]
        public decimal Price { get; set; }
    }

    public class OrderedProductDrinksDto
    {
        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [JsonProperty("price")]
        public decimal Price { get; set; }
    }
}