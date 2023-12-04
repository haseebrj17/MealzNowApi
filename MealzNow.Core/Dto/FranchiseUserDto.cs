using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using static MealzNow.Core.Enum.Enums;

namespace MealzNow.Core.Dto
{
    public class FranchiseUserDto
    {
        [JsonProperty("firstName")]
        [StringLength(100)]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        [StringLength(100)]
        public string LastName { get; set; }

        [JsonProperty("emailAddress")]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [JsonProperty("password")]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; }

        [JsonProperty("userRole")]
        public UserRole UserRole { get; set; }

        [JsonProperty("isActive")]
        public bool IsActive { get; set; }

        [JsonProperty("franchiseId")]
        public Guid FranchiseId { get; set; }

        [JsonProperty("franchiseName")]
        public string FranchiseName { get; set; }
    }
}