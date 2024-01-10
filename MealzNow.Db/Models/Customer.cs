using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using static MealzNow.Core.Enum.Enums;

namespace MealzNow.Db.Models
{
    public class Customer : BaseEntity
    {
        [Required]
        public string FullName { get; set; } = null!;

        [Required]
        public string EmailAddress { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        [Required]
        public string ContactNumber { get; set; } = null!;

        [Required]
        public string VerificationCode { get; set; } = null!;

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsNumberVerified { get; set; }

        public bool IsEmailVerified { get; set; }

        [Required]
        public Guid CityId { get; set; }

        public List<CustomerAddresses> CustomerAddresses { get; set; } = new List<CustomerAddresses>();

        public Preference Preference { get; set; } = null!;

        public CustomerProductOutline CustomerProductOutline { get; set; } = null!;

        public CustomerPackage CustomerPackage { get; set; } = null!;

        public CustomerPromo CustomerPromo { get; set; } = null!;

        public CustomerPayment CustomerPayment { get; set; } = null!;

        public CustomerPassword CustomerPassword { get; set; } = null!;

        public List<CustomerDevice> CustomerDevice { get; set; } = new List<CustomerDevice>();
    }

    public class CustomerAddresses : BaseEntity
    {
        [Required]
        public string StreetAddress { get; set; } = null!;

        public string House { get; set; } = null!;

        public string PostalCode { get; set; } = null!;

        public string CityName { get; set; } = null!;

        public string District { get; set; } = null!;

        public string UnitNumber { get; set; } = null!;

        public string FloorNumber { get; set; } = null!;

        public string StateName { get; set; } = null!;

        public string CountryName { get; set; } = null!;

        public string Notes { get; set; } = null!;

        public bool IsDefault { get; set; }

        public string Tag { get; set; } = null!;

        [Required]
        public decimal Latitude { get; set; }

        [Required]
        public decimal Longitude { get; set; }

        [Required]
        public Guid CityId { get; set; }

        [Required]
        public Guid CustomerId { get; set; }
    }

    public class CustomerPackage : BaseEntity
    {
        [Required]
        public Guid PackageId { get; set; }

        [Required]
        public string PackageName { get; set; } = null!;

        [Required]
        public int TotalNumberOfMeals { get; set; }

        [Required]
        public int NumberOfDays { get; set; }

        [Required]
        public Timings Timings { get; set; }

        [Required]
        public string MealzPerDay { get; set; } = null!;

        [Required]
        public int NumberOfWeeks { get; set; }
    }

    public class CustomerPayment : BaseEntity
    {
        [Required]
        public string PaymentType { get; set; } = null!;

        [Required]
        public OrderType OrderType { get; set; }
    }

    public class CustomerPromo : BaseEntity
    {
        [Required]
        public string Type { get; set; } = null!;

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Percent { get; set; } = null!;
    }

    public class CustomerDevice : BaseEntity
    {
        public string DeviceId { get; set; } = null!;

        public bool IsActive { get; set; }
    }

    public class CustomerPassword : BaseEntity
    {
        public string Hash { get; set; } = null!;

        public string Salt { get; set; } = null!;
    }

    public class Preference : BaseEntity
    {
        public List<PreferredCategories> PreferredCategories { get; set; } = new List<PreferredCategories>();

        public List<PreferredSubCategories> PreferredSubCategories { get; set; } = new List<PreferredSubCategories>();
    }

    public class PreferredCategories : BaseEntity
    {
        public Guid CategoryId { get; set; }

        public string CategoryName { get; set; } = null!;
    }

    public class PreferredSubCategories : BaseEntity
    {
        public Guid SubCategoryId { get; set; }

        public string SubCategoryName { get; set; } = null!;
    }

    public class CustomerProductOutline : BaseEntity
    {
        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public string Icon { get; set; } = null!;

        [Required]
        public Guid OutlineId { get; set; }

        [Required]
        public List<CustomerProductInclusion> CustomerProductInclusion { get; set; } = new List<CustomerProductInclusion>();
    }

    public class CustomerProductInclusion : BaseEntity
    {
        public string Name { get; set; } = null!;

        public string Icon { get; set; } = null!;

        public Guid ProductInclusionId { get; set; }
    }
}
