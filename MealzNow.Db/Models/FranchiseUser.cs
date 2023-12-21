using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using static MealzNow.Core.Enum.Enums;

namespace MealzNow.Db.Models
{
    public class FranchiseUser : BaseEntity
    {
        [Required]
        [JsonProperty("firstName")]
        [StringLength(100)]
        public string FirstName { get; set; } = null!;

        [Required]
        [JsonProperty("lastName")]
        [StringLength(100)]
        public string LastName { get; set; } = null!;

        [Required]
        [JsonProperty("emailAddress")]
        [EmailAddress]
        public string EmailAddress { get; set; } = null!;

        [Required]
        [JsonProperty("password")]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; } = null!;

        [Required]
        [JsonProperty("userRole")]
        public UserRole UserRole { get; set; }

        [Required]
        [JsonProperty("isActive")]
        public bool IsActive { get; set; }

        [Required]
        [JsonProperty("franchiseId")]
        public Guid FranchiseId { get; set; }

        [Required]
        [JsonProperty("franchiseName")]
        public string FranchiseName { get; set; } = null!;
    }
}
