﻿using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace MealzNow.Db.Models
{
    public class Franchise : BaseEntity
    {
        [Required]
        [JsonProperty("title")]
        public string Title { get; set; }

        [Required]
        [JsonProperty("address")]
        public string Address { get; set; }

        [Required]
        [JsonProperty("zipCode")]
        public string ZipCode { get; set; }

        [Required]
        [JsonProperty("contactNumber")]
        public string ContactNumber { get; set; }

        [Required]
        [JsonProperty("openingTime")]
        public string OpeningTime { get; set; }

        [Required]
        [JsonProperty("closingTime")]
        public string ClosingTime { get; set; }

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
        public bool IsActive { get; set; }

        [Required]
        [JsonProperty("clientId")]
        public Guid ClientId { get; set; }

        [Required]
        [JsonProperty("cityId")]
        public Guid CityId { get; set; }

        [Required]
        [JsonProperty("cityName")]
        public string CityName { get; set; }

        [Required]
        [JsonProperty("stateId")]
        public Guid StateId { get; set; }

        [Required]
        [JsonProperty("stateName")]
        public string StateName { get; set; }

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
        public string Day { get; set; }

        [Required]
        [JsonProperty("openingTime")]
        public DateTime OpeningTime { get; set; }

        [Required]
        [JsonProperty("closingTime")]
        public DateTime ClosingTime { get; set; }
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
        public string ImageUrl { get; set; }

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

        [Required]
        [JsonProperty("servingTimings")]
        public List<ServingTimings> ServingTimings { get; set; } = new List<ServingTimings>();
    }

    public class MealsPerDay : BaseEntity
    {
        [Required]
        [JsonProperty("title")]
        public string Title { get; set; }

        [Required]
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("discount")]
        public int Discount { get; set; }
    }

    public class ServingDays : BaseEntity
    {
        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class ServingTimings : BaseEntity
    {
        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Required]
        [JsonProperty("servingTime")]
        public List<ServingTime> ServingTime { get; set; } = new List<ServingTime>();
    }

    public class ServingTime : BaseEntity
    {
        [Required]
        [JsonProperty("slotStart")]
        public DateTime SlotStart { get; set; }

        [Required]
        [JsonProperty("slotEnd")]
        public DateTime SlotEnd { get; set; }
    }

    public class ProductOutline : BaseEntity
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
        [JsonProperty("productInclusion")]
        public List<ProductInclusion> ProductInclusion { get; set; } = new List<ProductInclusion>();
    }

    public class ProductInclusion : BaseEntity
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }
    }
}