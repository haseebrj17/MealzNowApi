using System;
using Newtonsoft.Json;

namespace MealzNow.Core.Dto
{
    public class CategoryOutlineDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Logo { get; set; }

        public string? Description { get; set; }
    }
}
