using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using static MealzNow.Core.Enum.Enums;

namespace MealzNow.Db.Models
{
	public class Packages : BaseEntity
	{
		[Required]
		[JsonProperty("name")]
		public string Name { get; set; }

		[Required]
		[JsonProperty("packageType")]
		public PackageType PackageType { get; set; }

        [Required]
        [JsonProperty("includesDrinks")]
        public bool IncludesDrinks { get; set; }

        [Required]
        [JsonProperty("includesSides")]
        public bool IncludesSides { get; set; }

        [Required]
        [JsonProperty("includesDessert")]
        public bool IncludesDessert { get; set; }

        [Required]
        [JsonProperty("includesToppings")]
        public bool IncludesToppings { get; set; }

        [Required]
        [JsonProperty("includesDippings")]
        public bool IncludesDippings { get; set; }

        [Required]
        [JsonProperty("includesDelivery")]
        public bool IncludesDelivery { get; set; }

        [Required]
        [JsonProperty("price")]
        public decimal Price { get; set; }

        [Required]
        [JsonProperty("isActive")]
        public bool IsActive { get; set; } = true;
    }
}
