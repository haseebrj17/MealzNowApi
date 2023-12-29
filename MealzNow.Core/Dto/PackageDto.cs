using System;
using Newtonsoft.Json;
using static MealzNow.Core.Enum.Enums;

namespace MealzNow.Db.Models
{
    public class PackageDto
    {
        public string Name { get; set; } = null!;

        public PackageType PackageType { get; set; }

        public bool IncludesDrinks { get; set; }

        public bool IncludesSides { get; set; }

        public bool IncludesDessert { get; set; }

        public bool IncludesToppings { get; set; }

        public bool IncludesDippings { get; set; }

        public bool IncludesDelivery { get; set; }

        public decimal Price { get; set; }

        public Guid FranchiseId { get; set; }
    }
}
