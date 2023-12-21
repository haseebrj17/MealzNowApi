using System;
using Newtonsoft.Json;

namespace MealzNow.Core.Dto
{
    public class CategoryOutlineDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [JsonProperty("logo")]
        public string? Logo { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }
    }
}
