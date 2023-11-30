using Newtonsoft.Json;
using static MealzNow.Core.Enum.Enums;

namespace MealzNow.Core
{
    public class MealzNowUsers
    {
        [JsonProperty("id")]
        public Guid? Id { get; set; }

        [JsonProperty("franchiseId")]
        public Guid? FranchiseId { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("emailAddress")]
        public string EmailAddress { get; set; }

        [JsonProperty("password")]
        public string? Password { get; set; }

        [JsonProperty("contactNumber")]
        public string ContactNumber { get; set; }

        [JsonProperty("verificationCode")]
        public string? VerificationCode { get; set; }

        [JsonProperty("userRole")]
        public UserRole? UserRole { get; set; }
    }
}
