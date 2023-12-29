using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using static MealzNow.Core.Enum.Enums;

namespace MealzNow.Db.Models
{
    public class Packages : BaseEntity
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public PackageType PackageType { get; set; }

        [Required]
        public bool IncludesDrinks { get; set; }

        [Required]
        public bool IncludesSides { get; set; }

        [Required]
        public bool IncludesDessert { get; set; }

        [Required]
        public bool IncludesToppings { get; set; }

        [Required]
        public bool IncludesDippings { get; set; }

        [Required]
        public bool IncludesDelivery { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        [Required]
        public Guid FranchiseId { get; set; }
    }
}
