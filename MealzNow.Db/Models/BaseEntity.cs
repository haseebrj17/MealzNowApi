using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace MealzNow.Db.Models
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid();
            CreatedDateTimeUtc = DateTime.UtcNow;
        }

        [Key]
        [Required]
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [Required]
        [JsonProperty("createdDateTimeUtc")]
        public DateTime CreatedDateTimeUtc { get; set; }

        [Required]
        [JsonProperty("updatedDateTimeUtc")]
        public DateTime? UpdatedDateTimeUtc { get; set; }

        [Required]
        [JsonProperty("createdById")]
        public Guid CreatedById { get; set; }

        [Required]
        [JsonProperty("updatedById")]
        public Guid UpdatedById { get; set; }
    }
}