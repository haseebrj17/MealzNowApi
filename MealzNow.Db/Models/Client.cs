using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace MealzNow.Db.Models
{
    public class Client : BaseEntity
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
        [JsonProperty("address")]
        public string Address { get; set; }

        [Required]
        [JsonProperty("appLogo")]
        public string AppLogo { get; set; }

        [Required]
        [JsonProperty("websiteLogo")]
        public string WebsiteLogo { get; set; }

        [Required]
        [JsonProperty("slogon")]
        public string Slogon { get; set; }

        [Required]
        [JsonProperty("zipCode")]
        public string ZipCode { get; set; }

        [Required]
        [JsonProperty("contactNumber")]
        public string ContactNumber { get; set; }

        [Required]
        [JsonProperty("isActive")]
        public bool IsActive { get; set; }

        [Required]
        [JsonProperty("membershipValidityDate")]
        public DateTime MembershipValidityDate { get; set; }

        [Required]
        [JsonProperty("numberOfFranchisesAllowed")]
        public int NumberOfFranchisesAllowed { get; set; }

        [JsonProperty("clientFranchises")]
        public List<ClientFranchises> ClientFranchises { get; set; } = new List<ClientFranchises>();
    }

    public class ClientFranchises
    {
        [Required]
        [JsonProperty("title")]
        public string Title { get; set; }

        [Required]
        [JsonProperty("address")]
        public string Address { get; set; }

        [Required]
        [JsonProperty("zipCode")]
        public string ZipCode { get; set; }

        [Required]
        [JsonProperty("contactNumber")]
        public string ContactNumber { get; set; }

        [Required]
        [JsonProperty("openingTime")]
        public string OpeningTime { get; set; }

        [Required]
        [JsonProperty("closingTime")]
        public string ClosingTime { get; set; }

        [Required]
        [JsonProperty("latitude")]
        public decimal Latitude { get; set; }

        [Required]
        [JsonProperty("longitude")]
        public decimal Longitude { get; set; }

        [Required]
        [JsonProperty("coverageAreaInMeters")]
        public float CoverageAreaInMeters { get; set; }

        [Required]
        [JsonProperty("isActive")]
        public bool IsActive { get; set; }
    }
}
