using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using static MealzNow.Core.Enum.Enums;

namespace MealzNow.Db.Models
{
    public class FranchiseUser : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string LastName { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; } = null!;

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; } = null!;

        [Required]
        public UserRole UserRole { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public Guid FranchiseId { get; set; }

        [Required]
        public string FranchiseName { get; set; } = null!;
    }
}
