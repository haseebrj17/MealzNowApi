using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace MealzNow.Db.Models
{
    public class Product : BaseEntity
    {
        [Required]
        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [Required]
        [JsonProperty("detail")]
        public string Detail { get; set; } = null!;

        [JsonProperty("estimatedDeliveryTime")]
        public string? EstimatedDeliveryTime { get; set; }

        [JsonProperty("sequence")]
        public int Sequence { get; set; } = 0;

        [JsonProperty("spiceLevel")]
        public int? SpiceLevel { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; } = null!;

        [Required]
        [JsonProperty("ingredientSummary")]
        public string IngredientSummary { get; set; } = null!;

        [Required]
        [JsonProperty("ingredientDetail")]
        public string IngredientDetail { get; set; } = null!;

        [Required]
        [JsonProperty("image")]
        public string Image { get; set; } = null!;

        [JsonProperty("isActive")]
        public bool IsActive { get; set; }

        [JsonProperty("franchiseId")]
        public Guid Franchiseid { get; set; }

        [JsonProperty("showExtraTopping")]
        public bool ShowExtraTopping { get; set; }

        [JsonProperty("showExtraDipping")]
        public bool ShowExtraDipping { get; set; }

        [JsonProperty("productAllergy")]
        public List<ProductAllergy> ProductAllergy { get; set; } = new List<ProductAllergy>();

        [JsonProperty("productPrice")]
        public List<ProductPrice> ProductPrice { get; set; } = new List<ProductPrice>();

        [JsonProperty("productCategory")]
        public List<ProductCategory> ProductCategory { get; set; } = new List<ProductCategory>();

        [JsonProperty("categoryId")]
        public Guid CategoryId { get; set; }

        [JsonProperty("productExtraDipping")]
        public List<ProductExtraDipping> ProductExtraDipping { get; set; } = new List<ProductExtraDipping>();

        [JsonProperty("productExtraTopping")]
        public List<ProductExtraTopping> ProductExtraTopping { get; set; } = new List<ProductExtraTopping>();

        [JsonProperty("productItemOutline")]
        public List<ProductItemOutline> ProductItemOutline { get; set; } = new List<ProductItemOutline>();

        [JsonProperty("productChoices")]
        public List<ProductChoices> ProductChoices { get; set; } = new List<ProductChoices>();
    }

    public class ProductAllergy : BaseEntity
    {
        [JsonProperty("allergyName")]
        public string AllergyName { get; set; } = null!;
    }

    public class ProductPrice : BaseEntity
    {
        [Required]
        [JsonProperty("price")]
        public decimal Price { get; set; }

        [Required]
        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [Required]
        [JsonProperty("description")]
        public string Description { get; set; } = null!;
    }

    public class ProductCategory : BaseEntity
    {
        [Required]
        [JsonProperty("categoryId")]
        public Guid CategoryId { get; set; }

        [Required]
        [JsonProperty("categoryName")]
        public string CategoryName { get; set; } = null!;

        [Required]
        [JsonProperty("categoryType")]
        public string CategoryType { get; set; } = null!;
    }

    public class ProductChoices : BaseEntity
    {
        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [JsonProperty("detail")]
        public string Detail { get; set; } = null!;
    }

    public class ProductExtraDipping : BaseEntity
    {
        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [JsonProperty("detail")]
        public string Detail { get; set; } = null!;

        [JsonProperty("productExtraDippingAllergy")]
        public List<ProductExtraDippingAllergy> ProductExtraDippingAllergy { get; set; } = new List<ProductExtraDippingAllergy>();

        [JsonProperty("productExtraDippingPrice")]
        public List<ProductExtraDippingPrice> ProductExtraDippingPrice { get; set; } = new List<ProductExtraDippingPrice>();
    }

    public class ProductExtraDippingAllergy : BaseEntity
    {
        [JsonProperty("allergyName")]
        public string AllergyName { get; set; } = null!;
    }

    public class ProductExtraDippingPrice : BaseEntity
    {
        [Required]
        [JsonProperty("price")]
        public decimal Price { get; set; }

        [Required]
        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [Required]
        [JsonProperty("description")]
        public string Description { get; set; } = null!;
    }

    public class ProductExtraTopping : BaseEntity
    {
        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [JsonProperty("detail")]
        public string Detail { get; set; } = null!;

        [JsonProperty("productExtraToppingAllergy")]
        public List<ProductExtraToppingAllergy> ProductExtraToppingAllergy { get; set; } = new List<ProductExtraToppingAllergy>();

        [JsonProperty("productExtraToppingPrice")]
        public List<ProductExtraToppingPrice> ProductExtraToppingPrice { get; set; } = new List<ProductExtraToppingPrice>();
    }

    public class ProductExtraToppingAllergy : BaseEntity
    {
        [JsonProperty("allergyName")]
        public string AllergyName { get; set; } = null!;
    }

    public class ProductExtraToppingPrice : BaseEntity
    {
        [Required]
        [JsonProperty("price")]
        public decimal Price { get; set; }

        [Required]
        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [Required]
        [JsonProperty("description")]
        public string Description { get; set; } = null!;
    }

    public class ProductItemOutline : BaseEntity
    {
        [Required]
        [JsonProperty("name")]
        public string Name { get; set; } = null!;
    }
}
