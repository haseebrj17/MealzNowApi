using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using static MealzNow.Core.Enum.Enums;

namespace MealzNow.Db.Models
{
    public class Customer : BaseEntity
    {
        [Required]
        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [Required]
        [JsonProperty("emailAddress")]
        public string EmailAddress { get; set; }

        [Required]
        [JsonProperty("password")]
        public string Password { get; set; }

        [Required]
        [JsonProperty("contactNumber")]
        public string ContactNumber { get; set; }

        [Required]
        [JsonProperty("verificationCode")]
        public string VerificationCode { get; set; }

        [JsonProperty("isActive")]
        public bool IsActive { get; set; }

        [JsonProperty("isDeleted")]
        public bool IsDeleted { get; set; }

        [JsonProperty("isNumberVerified")]
        public bool IsNumberVerified { get; set; }

        [JsonProperty("isEmailVerified")]
        public bool IsEmailVerified { get; set; }

        [JsonProperty("customerAddresses")]
        public List<CustomerAddresses> CustomerAddresses { get; set; } = new List<CustomerAddresses>();

        [JsonProperty("preference")]
        public Preference Preference { get; set; }

        [JsonProperty("customerProductOutline")]
        public CustomerProductOutline CustomerProductOutline { get; set; }

        [JsonProperty("customerPackage")]
        public CustomerPackage CustomerPackage { get; set; }

        [JsonProperty("customerPromo")]
        public CustomerPromo CustomerPromo { get; set; }

        [JsonProperty("customerPayment")]
        public CustomerPayment CustomerPayment { get; set; }

        [JsonProperty("customerPassword")]
        public CustomerPassword CustomerPassword { get; set; }

        [JsonProperty("customerDevice")]
        public List<CustomerDevice> CustomerDevice { get; set; } = new List<CustomerDevice>();
    }

    public class CustomerAddresses : BaseEntity
    {
        [Required]
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

        [JsonProperty("isDefault")]
        public bool IsDefault { get; set; }

        [JsonProperty("tag")]
        public string? Tag { get; set; }

        [Required]
        [JsonProperty("latitude")]
        public decimal Latitude { get; set; }

        [Required]
        [JsonProperty("longitude")]
        public decimal Longitude { get; set; }

        [Required]
        [JsonProperty("cityId")]
        public Guid CityId { get; set; }

        [Required]
        [JsonProperty("customerId")]
        public Guid CustomerId { get; set; }
    }

    public class CustomerPackage : BaseEntity
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

    public class CustomerDevice : BaseEntity
    {
        [JsonProperty("deviceId")]
        public string DeviceId { get; set; }

        [JsonProperty("isActive")]
        public bool IsActive { get; set; }
    }

    public class CustomerPassword : BaseEntity
    {
        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("salt")]
        public string Salt { get; set; }
    }

    public class Preference : BaseEntity
    {
        [JsonProperty("preferredCategories")]
        public List<PreferredCategories> PreferredCategories { get; set; } = new List<PreferredCategories>();

        [JsonProperty("preferredSubCategories")]
        public List<PreferredSubCategories> PreferredSubCategories { get; set; } = new List<PreferredSubCategories>();
    }

    public class PreferredCategories : BaseEntity
    {
        [JsonProperty("categoryId")]
        public Guid CategoryId { get; set; }

        [JsonProperty("categoryName")]
        public string CategoryName { get; set; }
    }

    public class PreferredSubCategories : BaseEntity
    {
        [JsonProperty("subCategoryId")]
        public Guid SubCategoryId { get; set; }

        [JsonProperty("subCategoryName")]
        public string SubCategoryName { get; set; }
    }

    public class CustomerProductOutline : BaseEntity
    {
        [Required]
        [JsonProperty("title")]
        public string Title { get; set; }

        [Required]
        [JsonProperty("description")]
        public string Description { get; set; }

        [Required]
        [JsonProperty("icon")]
        public string Icon { get; set; }

        [Required]
        [JsonProperty("outlineId")]
        public Guid OutlineId { get; set; }

        [Required]
        [JsonProperty("customerProductInclusion")]
        public List<CustomerProductInclusion> CustomerProductInclusion { get; set; } = new List<CustomerProductInclusion>();
    }

    public class CustomerProductInclusion : BaseEntity
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("productInclusionId")]
        public Guid ProductInclusionId { get; set; }
    }
}
