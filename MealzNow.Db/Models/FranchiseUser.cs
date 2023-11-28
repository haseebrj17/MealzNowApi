using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using static FoodsNow.Core.Enum.Enums;

namespace MealzNow.Db.Models
{
    public class FranchiseUser : BaseEntity
    {
        [Required]
        [JsonProperty("firstName")]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [JsonProperty("lastName")]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [JsonProperty("emailAddress")]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        [JsonProperty("password")]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        [JsonProperty("kind")]
        public string Kind { get; set; }

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
        public string FranchiseName { get; set; }
    }
}
