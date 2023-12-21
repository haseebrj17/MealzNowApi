using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace MealzNow.Db.Models
{
    public class SuperAdmin : BaseEntity
    {
        [Required]
        [JsonProperty("firstName")]
        [StringLength(100)]
        public string FirstName { get; set; } = "";

        [Required]
        [JsonProperty("lastName")]
        [StringLength(100)]
        public required string LastName { get; set; }

        [Required]
        [JsonProperty("emailAddress")]
        [EmailAddress]
        public string EmailAddress { get; set; } = null!;

        [Required]
        [JsonProperty("password")]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; } = null!;
    }
}

