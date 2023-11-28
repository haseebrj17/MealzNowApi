using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using static MealzNow.Core.Enum.Enums;

namespace MealzNow.Db.Models
{
    public class Order : BaseEntity
    {
        [Required]
        [JsonProperty("totalBill")]
        public decimal TotalBill { get; set; }

        [Required]
        [JsonProperty("totalItems")]
        public int TotalItems { get; set; }

        [Required]
        [JsonProperty("")]
        public DateTime OrderDeliveryDateTime { get; set; }

        [JsonProperty("instructions")]
        public string? Instructions { get; set; }

        [Required]
        [JsonProperty("customerId")]
        public Guid CustomerId { get; set; }

        [Required]
        [JsonProperty("customerAddressId")]
        public Guid CustomerAddressId { get; set; }

        [Required]
        [JsonProperty("franchiseId")]
        public Guid FranchiseId { get; set; }

        [JsonProperty("orderStatus")]
        public OrderStatus OrderStatus { get; set; }

        [Required]
        [JsonProperty("customerOrderedPackage")]
        public CustomerOrderedPackage CustomerOrderedPackage { get; set; }

        [JsonProperty("productByDay")]
        public List<ProductByDay> ProductByDay { get; set; } = new List<ProductByDay>();

        [JsonProperty("customerPromo")]
        public CustomerPromo CustomerPromo { get; set; }

        [JsonProperty("customerPayment")]
        public CustomerPayment CustomerPayment { get; set; }
    }

    public class CustomerOrderedPackage : BaseEntity
    {
        [Required]
        [JsonProperty("packageId")]
        public Guid PackageId { get; set; }

        [Required]
        [JsonProperty("packageName")]
        public string PackageName { get; set; }

        [Required]
        [JsonProperty("totalNumberOfMeals")]
        public int TotalNumberOfMeals { get; set; }

        [Required]
        [JsonProperty("numberOfDays")]
        public int NumberOfDays { get; set; }
    }

    public class CustomerPayment : BaseEntity
    {
        [Required]
        [JsonProperty("paymentType")]
        public string PaymentType { get; set; }

        [Required]
        [JsonProperty("orderType")]
        public OrderType OrderType { get; set; }
    }

    public class CustomerPromo : BaseEntity
    {
        [Required]
        [JsonProperty("type")]
        public string Type { get; set; }

        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Required]
        [JsonProperty("percent")]
        public string Percent { get; set; }
    }

    public class ProductByDay : BaseEntity
    {
        [Required]
        [JsonProperty("day")]
        public string Day { get; set; }

        [Required]
        [JsonProperty("dayId")]
        public Guid DayId { get; set; }

        [Required]
        [JsonProperty("productByTiming")]
        public List<ProductByTiming> ProductByTiming { get; set; } = new List<ProductByTiming>();
    }

    public class ProductByTiming : BaseEntity
    {
        [Required]
        [JsonProperty("timeOfDay")]
        public string timeOfDay { get; set; }

        [Required]
        [JsonProperty("timeOfDayId")]
        public Guid timeOfDayId { get; set; }

        [Required]
        [JsonProperty("deliveryTimings")]
        public DateTime DeliveryTimings { get; set; }

        [Required]
        [JsonProperty("deliveryTimingsId")]
        public Guid DeliveryTimingsId { get; set; }

        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Required]
        [JsonProperty("detail")]
        public string Detail { get; set; }

        [JsonProperty("estimatedDeliveryTime")]
        public string? EstimatedDeliveryTime { get; set; }

        [JsonProperty("spiceLevel")]
        public int? SpiceLevel { get; set; }

        [Required]
        [JsonProperty("ingredientSummary")]
        public string IngredientSummary { get; set; }

        [Required]
        [JsonProperty("image")]
        public string Image { get; set; }

        [Required]
        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("orderedProductExtraDipping")]
        public List<OrderedProductExtraDipping> OrderedProductExtraDipping { get; set; } = new List<OrderedProductExtraDipping>();

        [JsonProperty("orderedProductExtraTopping")]
        public List<OrderedProductExtraTopping> OrderedProductExtraTopping { get; set; } = new List<OrderedProductExtraTopping>();

        [JsonProperty("orderedProductSides")]
        public OrderedProductSides OrderedProductSides { get; set; }

        [JsonProperty("orderedProductDessert")]
        public OrderedProductDessert OrderedProductDessert { get; set; }

        [JsonProperty("orderedProductDrinks")]
        public OrderedProductDrinks OrderedProductDrinks { get; set; }
    }

    public class OrderedProductExtraDipping : BaseEntity
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [Required]
        [JsonProperty("price")]
        public decimal Price { get; set; }
    }

    public class OrderedProductExtraTopping : BaseEntity
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [Required]
        [JsonProperty("price")]
        public decimal Price { get; set; }
    }

    public class OrderedProductSides : BaseEntity
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [Required]
        [JsonProperty("price")]
        public decimal Price { get; set; }
    }

    public class OrderedProductDessert : BaseEntity
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [Required]
        [JsonProperty("price")]
        public decimal Price { get; set; }
    }

    public class OrderedProductDrinks : BaseEntity
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [Required]
        [JsonProperty("price")]
        public decimal Price { get; set; }
    }
}
