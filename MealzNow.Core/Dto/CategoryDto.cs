using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MealzNow.Core.Dto
{
    public class CategoryDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("cover")]
        public string Cover { get; set; }

        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }

        [JsonProperty("logo")]
        public string? Logo { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("franchiseId")]
        public Guid FranchiseId { get; set; }

        [JsonProperty("subCategory")]
        public List<SubCategoryDto> SubCategory { get; set; }
    }

    public class SubCategoryDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("cover")]
        public string Cover { get; set; }

        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }
    }
}
