using Newtonsoft.Json;
using static MealzNow.Core.Enum.Enums;

namespace FoodsNow.Core
{
    public class CurrentAppUser
    {
        // Cosmos DB requires an 'id' property (lowercase)
        [JsonProperty("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        // Other properties
        public Guid? FranchiseId { get; set; }
        public string FullName { get; set; }
        public string EmailAdress { get; set; }
        public string? Password { get; set; }
        public string ContactNumber { get; set; }
        public string? VerificationCode { get; set; }
        public UserRole? UserRole { get; set; }

        // Partition key (assuming email address is unique)
        [JsonProperty("partitionKey")]
        public string PartitionKey => EmailAdress;
    }
}
