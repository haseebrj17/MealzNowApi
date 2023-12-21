using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MealzNow.Db.Models
{
    public class ProductDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [JsonProperty("detail")]
        public string Detail { get; set; } = null!;

        [JsonProperty("estimatedDeliveryTime")]
        public string? EstimatedDeliveryTime { get; set; }

        [JsonProperty("sequence")]
        public int Sequence { get; set; }

        [JsonProperty("spiceLevel")]
        public int? SpiceLevel { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("ingredientSummary")]
        public string IngredientSummary { get; set; } = null!;

        [JsonProperty("ingredientDetail")]
        public string IngredientDetail { get; set; } = null!;

        [JsonProperty("image")]
        public string Image { get; set; } = null!;

        [JsonProperty("isActive")]
        public bool IsActive { get; set; }

        [JsonProperty("showExtraTopping")]
        public bool ShowExtraTopping { get; set; }

        [JsonProperty("showExtraDipping")]
        public bool ShowExtraDipping { get; set; }

        [JsonProperty("productAllergy")]
        public List<ProductAllergyDto> ProductAllergy { get; set; } = null!;

        [JsonProperty("productPrice")]
        public List<ProductPriceDto> ProductPrice { get; set; } = null!;

        [JsonProperty("productCategory")]
        public List<ProductCategoryDto> ProductCategory { get; set; } = null!;

        [JsonProperty("categoryId")]
        public Guid CategoryId { get; set; }

        [JsonProperty("productExtraDipping")]
        public List<ProductExtraDippingDto> ProductExtraDipping { get; set; } = null!;

        [JsonProperty("productExtraTopping")]
        public List<ProductExtraToppingDto> ProductExtraTopping { get; set; } = null!;

        [JsonProperty("productItemOutline")]
        public List<ProductItemOutlineDto> ProductItemOutline { get; set; } = null!;

        [JsonProperty("productChoices")]
        public List<ProductChoicesDto> ProductExtra { get; set; } = new List<ProductChoicesDto>();
    }

    public class ProductAllergyDto
    {
        [JsonProperty("allergyName")]
        public string AllergyName { get; set; } = null!;
    }

    public class ProductPriceDto
    {
        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [JsonProperty("description")]
        public string Description { get; set; } = null!;
    }

    public class ProductCategoryDto
    {
        [JsonProperty("categoryId")]
        public Guid CategoryId { get; set; }

        [JsonProperty("categoryName")]
        public string CategoryName { get; set; } = null!;

        [JsonProperty("categoryType")]
        public string CategoryType { get; set; } = null!;
    }

    public class ProductChoicesDto
    {
        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [JsonProperty("detail")]
        public string Detail { get; set; } = null!;
    }

    public class ProductExtraDippingDto
    {
        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [JsonProperty("detail")]
        public string Detail { get; set; } = null!;

        [JsonProperty("productExtraDippingAllergy")]
        public List<ProductExtraDippingAllergyDto> ProductExtraDippingAllergy { get; set; } = null!;

        [JsonProperty("productExtraDippingPrice")]
        public List<ProductExtraDippingPriceDto> ProductExtraDippingPrice { get; set; } = null!;
    }

    public class ProductExtraDippingAllergyDto
    {
        [JsonProperty("allergyName")]
        public string AllergyName { get; set; } = null!;
    }

    public class ProductExtraDippingPriceDto
    {
        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [JsonProperty("description")]
        public string Description { get; set; } = null!;
    }

    public class ProductExtraToppingDto
    {
        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [JsonProperty("detail")]
        public string Detail { get; set; } = null!;

        [JsonProperty("productExtraToppingAllergy")]
        public List<ProductExtraToppingAllergyDto> ProductExtraToppingAllergy { get; set; } = null!;

        [JsonProperty("productExtraToppingPrice")]
        public List<ProductExtraToppingPriceDto> ProductExtraToppingPrice { get; set; } = null!;
    }

    public class ProductExtraToppingAllergyDto
    {
        [JsonProperty("allergyName")]
        public string AllergyName { get; set; } = null!;
    }

    public class ProductExtraToppingPriceDto
    {
        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [JsonProperty("description")]
        public string Description { get; set; } = null!;
    }

    public class ProductItemOutlineDto
    {
        [JsonProperty("name")]
        public string Name { get; set; } = null!;
    }

}
