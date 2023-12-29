using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace MealzNow.Db.Models
{
    public abstract class BaseEntity
    {
        public BaseEntity() => Id = Guid.NewGuid();

        [Key]
        [Required]
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [Required]
        public DateTime CreatedDateTimeUtc { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedDateTimeUtc { get; set; }

        [Required]
        public Guid CreatedById { get; set; }

        [Required]
        public Guid UpdatedById { get; set; }
    }
}