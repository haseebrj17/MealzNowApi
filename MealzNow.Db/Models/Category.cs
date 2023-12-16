using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;

namespace MealzNow.Db.Models
{
	public class Category : BaseEntity
	{
		[Required]
		[JsonProperty("name")]
		public string Name { get; set; }

		[Required]
		[JsonProperty("cover")]
		public string Cover { get; set; }

        [Required]
        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }

        [Required]
        [JsonProperty("sequence")]
        public int Sequence { get; set; } = 0;

        [JsonProperty("logo")]
        public string? Logo { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("color")]
        public string? Color { get; set; }

        [JsonProperty("isVisibleOnDashboard")]
        public bool IsVisibleOnDashboard { get; set; }

        [JsonProperty("isVisibleOnCheckOut")]
        public bool IsVisibleOnCheckOut { get; set; }

        [JsonProperty("isVisibleOnCart")]
        public bool IsVisibleOnCart { get; set; }

        [JsonProperty("isBrand")]
        public bool IsBrand { get; set; }

        [JsonProperty("isActive")]
        public bool IsActive { get; set; }

        [Required]
        [JsonProperty("franchiseId")]
        public Guid FranchiseId { get; set; }

        [JsonProperty("subCategory")]
        public List<SubCategory> SubCategory { get; set; } = new List<SubCategory>();
    }

    public class SubCategory : BaseEntity
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("parentId")]
        public Guid ParentId { get; set; }

        [JsonProperty("cover")]
        public string Cover { get; set; }

        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }

        [JsonProperty("sequence")]
        public int Sequence { get; set; } = 0;

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("color")]
        public string? Color { get; set; }

        [JsonProperty("isVisibleOnDashboard")]
        public bool IsVisibleOnDashboard { get; set; }

        [JsonProperty("isVisibleOnCheckOut")]
        public bool IsVisibleOnCheckOut { get; set; }

        [JsonProperty("isVisibleOnCart")]
        public bool IsVisibleOnCart { get; set; }

        [JsonProperty("isActive")]
        public bool IsActive { get; set; }
    }
}
