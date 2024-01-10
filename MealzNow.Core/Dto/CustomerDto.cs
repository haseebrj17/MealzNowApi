using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using static MealzNow.Core.Enum.Enums;

namespace MealzNow.Core.Dto
{
    public class CustomerDto
    {
        [JsonProperty("id")]
        public Guid? Id { get; set; }

        public string FullName { get; set; } = null!;

        public string EmailAddress { get; set; } = null!;

        public string ContactNumber { get; set; } = null!;

        public bool IsNumberVerified { get; set; }

        public bool IsEmailVerified { get; set; }

        public List<CustomerAddressDto> CustomerAddresses { get; set; } = null!;

        public PreferenceDto Preference { get; set; } = null!;

        public List<CustomerProductOutlineDto> CustomerProductOutline { get; set; } = null!;

        public CustomerPackageDto CustomerPackageDto { get; set; } = null!;

        public CustomerPromoDto CustomerPromo { get; set; } = null!;

        public CustomerPromoDto CustomerPayment { get; set; } = null!;

        public string Code { get; set; } = null!;

        public UserRole UserRole { get; set; }

        public Guid CityId { get; set; }

        public CustomerPasswordDto CustomerPassword { get; set; } = null!;

        public List<CustomerDeviceDto> CustomerDevice { get; set; } = new List<CustomerDeviceDto>();
    }

    public class CustomerAddressDto
    {
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

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public Guid CityId { get; set; }

        public Guid CustomerId { get; set; }
    }

    public class PreferenceDto
    {
        public List<PreferredCategoriesDto> PreferredCategories { get; set; } = null!;

        public List<PreferredSubCategoriesDto> PreferredSubCategories { get; set; } = null!;
    }

    public class PreferredCategoriesDto
    {
        public Guid CategoryId { get; set; }

        public string CategoryName { get; set; } = null!;
    }

    public class PreferredSubCategoriesDto
    {
        public Guid SubCategoryId { get; set; }

        public string SubCategoryName { get; set; } = null!;
    }

    public class CustomerDeviceDto
    {
        public string DeviceId { get; set; } = null!;

        public bool IsActive { get; set; }
    }

    public class CustomerPasswordDto
    {
        public string Hash { get; set; } = null!;

        public string Salt { get; set; } = null!;
    }

    public class CustomerProductOutlineDto
    {
        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Icon { get; set; } = null!;

        public Guid OutlineId { get; set; }

        public List<CustomerProductInclusionDto> CustomerProductInclusion { get; set; } = new List<CustomerProductInclusionDto>();
    }

    public class CustomerProductInclusionDto
    {
        public string Name { get; set; } = null!;

        public string Icon { get; set; } = null!;

        public Guid ProductInclusionId { get; set; }
    }

    public class CustomerPackageDto
    {
        public Guid PackageId { get; set; }

        public string PackageName { get; set; } = null!;

        public int TotalNumberOfMeals { get; set; }

        public int NumberOfDays { get; set; }

        public Timings Timings { get; set; }

        public string MealzPerDay { get; set; } = null!;

        public int NumberOfWeeks { get; set; }
    }

    public class CustomerPaymentDto
    {
        public string PaymentType { get; set; } = null!;

        public OrderType OrderType { get; set; }
    }

    public class CustomerPromoDto
    {
        public string Type { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Percent { get; set; } = null!;
    }
}
