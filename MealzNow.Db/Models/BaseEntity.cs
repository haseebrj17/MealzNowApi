using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace MealzNow.Db.Models
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid().ToString();
            CreatedDateTimeUtc = DateTime.UtcNow;
        }

        [Key]
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("createdDateTimeUtc")]
        public DateTime CreatedDateTimeUtc { get; set; }

        [JsonProperty("updatedDateTimeUtc")]
        public DateTime? UpdatedDateTimeUtc { get; set; }

        [JsonProperty("createdById")]
        public Guid CreatedById { get; set; }

        [JsonProperty("updatedById")]
        public Guid UpdatedById { get; set; }
    }
}