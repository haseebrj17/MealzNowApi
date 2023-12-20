using Newtonsoft.Json;

namespace MealzNow.Core.Dto
{
    public class FranchiseDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; } = null!;

        [JsonProperty("address")]
        public string Address { get; set; } = null!;

        [JsonProperty("zipCode")]
        public string ZipCode { get; set; } = null!;

        [JsonProperty("contactNumber")]
        public string ContactNumber { get; set; } = null!;

        [JsonProperty("openingTime")]
        public string OpeningTime { get; set; } = null!;

        [JsonProperty("closingTime")]
        public string ClosingTime { get; set; } = null!;

        [JsonProperty("latitude")]
        public decimal Latitude { get; set; }

        [JsonProperty("longitude")]
        public decimal Longitude { get; set; }

        [JsonProperty("coverageAreaInMeters")]
        public float CoverageAreaInMeters { get; set; }

        [JsonProperty("isActive")]
        public bool IsActive { get; set; }

        [JsonProperty("clientId")]
        public Guid ClientId { get; set; }

        [JsonProperty("cityId")]
        public Guid CityId { get; set; }

        [JsonProperty("cityName")]
        public string CityName { get; set; } = null!;

        [JsonProperty("stateName")]
        public string StateName { get; set; } = null!;

        [JsonProperty("franchiseTimings")]
        public List<FranchiseTimingDto> FranchiseTimings { get; set; } = null!;

        [JsonProperty("franchiseHolidays")]
        public List<FranchiseHolidayDto> FranchiseHolidays { get; set; } = null!;

        [JsonProperty("franchiseSetting")]
        public List<FranchiseSettingDto> FranchiseSetting { get; set; } = null!;

        [JsonProperty("productOutline")]
        public List<ProductOutlineDto> ProductOutline { get; set; } = null!;
    }

    public class FranchiseTimingDto
    {
        [JsonProperty("day")]
        public string Day { get; set; }

        [JsonProperty("openingTime")]
        public TimeSpan OpeningTime { get; set; }

        [JsonProperty("closingTime")]
        public TimeSpan ClosingTime { get; set; }

        [JsonProperty("open")]
        public bool Open { get; set; }

        [JsonProperty("servingTimings")]
        public List<ServingTimingsDto> ServingTimings { get; set; } = null!;
    }

    public class FranchiseHolidayDto
    {
        [JsonProperty("from")]
        public DateTime From { get; set; }

        [JsonProperty("to")]
        public DateTime To { get; set; }
    }

    public class FranchiseSettingDto
    {
        [JsonProperty("mealsPerDay")]
        public List<MealsPerDayDto> MealsPerDay { get; set; } = null!;

        [JsonProperty("servingDays")]
        public List<ServingDaysDto> ServingDays { get; set; } = null!;
    }

    public class MealsPerDayDto
    {
        [JsonProperty("title")]
        public string Title { get; set; } = null!;

        [JsonProperty("description")]
        public string Description { get; set; } = null!;

        [JsonProperty("discount")]
        public int Discount { get; set; }
    }

    public class ServingDaysDto
    {
        [JsonProperty("name")]
        public string Name { get; set; } = null!;
    }

    public class ServingTimingsDto
    {
        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [JsonProperty("servingTime")]
        public List<ServingTimeDto> ServingTime { get; set; } = null!;
    }

    public class ServingTimeDto
    {
        [JsonProperty("slotStart")]
        public TimeSpan SlotStart { get; set; }

        [JsonProperty("slotEnd")]
        public TimeSpan SlotEnd { get; set; }
    }

    public class ProductOutlineDto
    {
        [JsonProperty("title")]
        public string Title { get; set; } = null!;

        [JsonProperty("description")]
        public string Description { get; set; } = null!;

        [JsonProperty("icon")]
        public string Icon { get; set; } = null!;

        [JsonProperty("productInclusion")]
        public List<ProductInclusionDto> ProductInclusion { get; set; } = null!;
    }

    public class ProductInclusionDto
    {
        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [JsonProperty("icon")]
        public string Icon { get; set; } = null!;
    }

}