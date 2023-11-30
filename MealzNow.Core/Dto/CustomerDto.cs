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
        public Guid Id { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("emailAddress")]
        public string EmailAddress { get; set; }

        [JsonProperty("contactNumber")]
        public string ContactNumber { get; set; }

        [JsonProperty("isNumberVerified")]
        public bool IsNumberVerified { get; set; }

        [JsonProperty("isEmailVerified")]
        public bool IsEmailVerified { get; set; }

        [JsonProperty("customerAddress")]
        public List<CustomerAddressDto> CustomerAddress { get; set; }

        [JsonProperty("preference")]
        public PreferenceDto Preference { get; set; }

        [JsonProperty("customerProductOutline")]
        public List<CustomerProductOutlineDto> CustomerProductOutline { get; set; }

        [JsonProperty("customerPackageDto")]
        public CustomerPackageDto CustomerPackageDto { get; set; }

        [JsonProperty("customerPromo")]
        public CustomerPromoDto CustomerPromo { get; set; }

        [JsonProperty("customerPayment")]
        public CustomerPromoDto CustomerPayment { get; set; }
    }

    public class CustomerAddressDto
    {
        [JsonProperty("streetAddress")]
        public string? StreetAddress { get; set; }

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

        [JsonProperty("latitude")]
        public decimal Latitude { get; set; }

        [JsonProperty("longitude")]
        public decimal Longitude { get; set; }

        [JsonProperty("cityId")]
        public Guid CityId { get; set; }

        [JsonProperty("customerId")]
        public Guid CustomerId { get; set; }
    }

    public class PreferenceDto
    {
        [JsonProperty("preferredCategories")]
        public List<PreferredCategoriesDto> PreferredCategories { get; set; }

        [JsonProperty("preferredSubCategories")]
        public List<PreferredSubCategoriesDto> PreferredSubCategories { get; set; }
    }

    public class PreferredCategoriesDto
    {
        [JsonProperty("categoryId")]
        public Guid CategoryId { get; set; }

        [JsonProperty("categoryName")]
        public string CategoryName { get; set; }
    }

    public class PreferredSubCategoriesDto
    {
        [JsonProperty("subCategoryId")]
        public Guid SubCategoryId { get; set; }

        [JsonProperty("subCategoryName")]
        public string SubCategoryName { get; set; }
    }

    public class CustomerProductOutlineDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("outlineId")]
        public Guid OutlineId { get; set; }
    }

    public class CustomerProductOutline
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("outlineId")]
        public Guid OutlineId { get; set; }

        [JsonProperty("customerProductInclusion")]
        public List<CustomerProductInclusion> CustomerProductInclusion { get; set; } = new List<CustomerProductInclusion>();
    }

    public class CustomerProductInclusion
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("productInclusionId")]
        public Guid ProductInclusionId { get; set; }
    }

    public class CustomerPackageDto
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

    public class CustomerPaymentDto
    {
        [JsonProperty("paymentType")]
        public string PaymentType { get; set; }

        [JsonProperty("orderType")]
        public OrderType OrderType { get; set; }
    }

    public class CustomerPromoDto
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("percent")]
        public string Percent { get; set; }
    }
}
