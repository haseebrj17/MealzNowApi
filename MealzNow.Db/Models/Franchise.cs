using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace MealzNow.Db.Models
{
    public class Franchise : BaseEntity
    {
        [Required]
        [JsonProperty("title")]
        public string Title { get; set; } = null!;

        [Required]
        [JsonProperty("address")]
        public string Address { get; set; } = null!;

        [Required]
        [JsonProperty("zipCode")]
        public string ZipCode { get; set; } = null!;

        [Required]
        [JsonProperty("contactNumber")]
        public string ContactNumber { get; set; } = null!;

        [Required]
        [JsonProperty("openingTime")]
        public string OpeningTime { get; set; } = null!;

        [Required]
        [JsonProperty("closingTime")]
        public string ClosingTime { get; set; } = null!;

        [Required]
        [JsonProperty("latitude")]
        public decimal Latitude { get; set; }

        [Required]
        [JsonProperty("longitude")]
        public decimal Longitude { get; set; }

        [Required]
        [JsonProperty("coverageAreaInMeters")]
        public float CoverageAreaInMeters { get; set; }

        [Required]
        [JsonProperty("isActive")]
        public bool IsActive { get; set; } = true;

        [Required]
        [JsonProperty("clientId")]
        public Guid ClientId { get; set; }

        [Required]
        [JsonProperty("cityId")]
        public Guid CityId { get; set; }

        [Required]
        [JsonProperty("cityName")]
        public string CityName { get; set; } = null!;

        [Required]
        [JsonProperty("stateId")]
        public Guid StateId { get; set; }

        [Required]
        [JsonProperty("stateName")]
        public string StateName { get; set; } = null!;

        [JsonProperty("franchiseTimings")]
        public List<FranchiseTiming> FranchiseTimings { get; set; } = new List<FranchiseTiming>();

        [JsonProperty("franchiseHolidays")]
        public List<FranchiseHoliday> FranchiseHolidays { get; set; } = new List<FranchiseHoliday>();

        [JsonProperty("dishOfDay")]
        public List<DishOfDay> DishOfDay { get; set; } = new List<DishOfDay>();

        [JsonProperty("banner")]
        public List<Banner> Banner { get; set; } = new List<Banner>();

        [Required]
        [JsonProperty("franchiseSetting")]
        public List<FranchiseSetting> FranchiseSetting { get; set; } = new List<FranchiseSetting>();

        [Required]
        [JsonProperty("productOutline")]
        public List<ProductOutline> ProductOutline { get; set; } = new List<ProductOutline>();
    }

    public class FranchiseTiming
    {
        [Required]
        [JsonProperty("day")]
        public string Day { get; set; } = null!;

        [Required]
        [JsonProperty("openingTime")]
        public TimeSpan OpeningTime { get; set; }

        [Required]
        [JsonProperty("closingTime")]
        public TimeSpan ClosingTime { get; set; }

        [Required]
        [JsonProperty("open")]
        public bool Open { get; set; } = true;

        [Required]
        [JsonProperty("servingTimings")]
        public List<ServingTimings> ServingTimings { get; set; } = new List<ServingTimings>();
    }

    public class FranchiseHoliday
    {
        [Required]
        [JsonProperty("from")]
        public DateTime From { get; set; }

        [Required]
        [JsonProperty("to")]
        public DateTime To { get; set; }
    }

    public class DishOfDay : BaseEntity
    {
        [Required]
        [JsonProperty("imageUrl")]
        public required string ImageUrl { get; set; }

        [Required]
        [JsonProperty("isActive")]
        public bool IsActive { get; set; }

        [Required]
        [JsonProperty("validity")]
        public DateTime Validity { get; set; }

        [Required]
        [JsonProperty("productId")]
        public Guid? ProductId { get; set; }

        [Required]
        [JsonProperty("sequence")]
        public int Sequence { get; set; } = 0;
    }

    public class Banner : BaseEntity
    {
        [Required]
        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; } = null!;

        [JsonProperty("isActive")]
        public bool IsActive { get; set; } = true;

        [JsonProperty("sequence")]
        public int Sequence { get; set; } = 0;

        [JsonProperty("validity")]
        public DateTime Validity { get; set; }

        [JsonProperty("brandId")]
        public Guid? BrandId { get; set; }

        [JsonProperty("productId")]
        public Guid? ProductId { get; set; }

        [JsonProperty("categoryId")]
        public Guid? CategoryId { get; set; }
    }

    public class FranchiseSetting : BaseEntity
    {
        [Required]
        [JsonProperty("mealsPerDay")]
        public List<MealsPerDay> MealsPerDay { get; set; } = new List<MealsPerDay>();

        [Required]
        [JsonProperty("servingDays")]
        public List<ServingDays> ServingDays { get; set; } = new List<ServingDays>();
    }

    public class MealsPerDay : BaseEntity
    {
        [Required]
        [JsonProperty("title")]
        public string Title { get; set; } = null!;

        [Required]
        [JsonProperty("description")]
        public string Description { get; set; } = null!;

        [JsonProperty("discount")]
        public int Discount { get; set; }
    }

    public class ServingDays : BaseEntity
    {
        [Required]
        [JsonProperty("name")]
        public string Name { get; set; } = null!;
    }

    public class ServingTimings : BaseEntity
    {
        [Required]
        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [Required]
        [JsonProperty("servingTime")]
        public List<ServingTime> ServingTime { get; set; } = new List<ServingTime>();
    }

    public class ServingTime : BaseEntity
    {
        [Required]
        [JsonProperty("slotStart")]
        public TimeSpan SlotStart { get; set; }

        [Required]
        [JsonProperty("slotEnd")]
        public TimeSpan SlotEnd { get; set; }
    }

    public class ProductOutline : BaseEntity
    {
        [Required]
        [JsonProperty("title")]
        public string Title { get; set; } = null!;

        [Required]
        [JsonProperty("description")]
        public string Description { get; set; } = null!;

        [Required]
        [JsonProperty("icon")]
        public string Icon { get; set; } = null!;

        [Required]
        [JsonProperty("productInclusion")]
        public List<ProductInclusion> ProductInclusion { get; set; } = new List<ProductInclusion>();
    }

    public class ProductInclusion : BaseEntity
    {
        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [JsonProperty("icon")]
        public string Icon { get; set; } = null!;
    }
}
