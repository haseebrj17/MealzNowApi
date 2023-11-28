using System;
using Newtonsoft.Json;
using static MealzNow.Core.Enum.Enums;

namespace MealzNow.Db.Models
{
    public class PackageDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("packageType")]
        public PackageType PackageType { get; set; }

        [JsonProperty("includesDrinks")]
        public bool IncludesDrinks { get; set; }

        [JsonProperty("includesSides")]
        public bool IncludesSides { get; set; }

        [JsonProperty("includesDessert")]
        public bool IncludesDessert { get; set; }

        [JsonProperty("includesToppings")]
        public bool IncludesToppings { get; set; }

        [JsonProperty("includesDippings")]
        public bool IncludesDippings { get; set; }

        [JsonProperty("includesDelivery")]
        public bool IncludesDelivery { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }
    }
}
