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
        public string Name { get; set; } = null!;

        [JsonProperty("cover")]
        public string Cover { get; set; } = null!;

        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; } = null!;

        [JsonProperty("logo")]
        public string? Logo { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("franchiseId")]
        public Guid FranchiseId { get; set; }

        [JsonProperty("subCategory")]
        public List<SubCategoryDto> SubCategory { get; set; } = null!;
    }

    public class SubCategoryDto
    {
        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [JsonProperty("parentId")]
        public Guid ParentId { get; set; }

        [JsonProperty("franchiseId")]
        public Guid FranchiseId { get; set; }

        [JsonProperty("cover")]
        public string Cover { get; set; } = null!;

        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; } = null!;

        [JsonProperty("description")]
        public string? Description { get; set; }
    }
}
