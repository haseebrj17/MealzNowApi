using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

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
        [JsonProperty("kind")]
        public string Kind { get; set; }

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

        [JsonProperty("CustomerAddress")]
        public List<CustomerAddress> CustomerAddress { get; set; } = new List<CustomerAddress>();

        [JsonProperty("Preference")]
        public Preference Preference { get; set; }

        [JsonProperty("customerProductOutline")]
        public  List<CustomerProductOutline> CustomerProductOutline { get; set; } = new List<CustomerProductOutline>();

        [JsonProperty("CustomerOrderedPackage")]
        public CustomerOrderedPackage CustomerOrderedPackage { get; set; }

        [JsonProperty("CustomerPromo")]
        public CustomerPromo CustomerPromo { get; set; }

        [JsonProperty("CustomerPayment")]
        public CustomerPayment CustomerPayment { get; set; }

        [JsonProperty("customerPassword")]
        public CustomerPassword CustomerPassword { get; set; }

        [JsonProperty("CustomerDevice")]
        public List<CustomerDevice> CustomerDevice { get; set; } = new List<CustomerDevice>();
    }

    public class CustomerAddress : BaseEntity
    {
        [Required]
        [JsonProperty("streetAddress")]
        public string StreetAddress { get; set; }

        [JsonProperty("house")]
        public string? House { get; set; }

        [JsonProperty("postalCode")]
        public string? PostalCode { get; set; }

        [JsonProperty("district")]
        public string? District { get; set; }

        [JsonProperty("unitNumber")]
        public string? UnitNumber { get; set; }

        [JsonProperty("floorNumber")]
        public string? FloorNumber { get; set; }

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

        [JsonProperty("cityId")]
        public Guid CityId { get; set; }
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
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("outlineId")]
        public Guid OutlineId { get; set; }
    }
}
