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
        public string Name { get; set; }

        [JsonProperty("detail")]
        public string Detail { get; set; }

        [JsonProperty("estimatedDeliveryTime")]
        public string? EstimatedDeliveryTime { get; set; }

        [JsonProperty("sequence")]
        public int Sequence { get; set; }

        [JsonProperty("spiceLevel")]
        public int? SpiceLevel { get; set; }

        [JsonProperty("ingredientSummary")]
        public string IngredientSummary { get; set; }

        [JsonProperty("ingredientDetail")]
        public string IngredientDetail { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("isActive")]
        public bool IsActive { get; set; }

        [JsonProperty("showExtraTropping")]
        public bool ShowExtraTropping { get; set; }

        [JsonProperty("showExtraDipping")]
        public bool ShowExtraDipping { get; set; }

        [JsonProperty("productAllergy")]
        public List<ProductAllergyDto> ProductAllergy { get; set; }

        [JsonProperty("productPrice")]
        public List<ProductPriceDto> ProductPrice { get; set; }

        [JsonProperty("productCategory")]
        public List<ProductCategoryDto> ProductCategory { get; set; }

        [JsonProperty("categoryId")]
        public Guid CategoryId { get; set; }

        [JsonProperty("productExtraDipping")]
        public List<ProductExtraDippingDto> ProductExtraDipping { get; set; }

        [JsonProperty("productExtraTopping")]
        public List<ProductExtraToppingDto> ProductExtraTopping { get; set; }

        [JsonProperty("productItemOutline")]
        public List<ProductItemOutlineDto> ProductItemOutline { get; set; }
    }

    public class ProductAllergyDto
    {
        [JsonProperty("allergyName")]
        public string AllergyName { get; set; }
    }

    public class ProductPriceDto
    {
        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class ProductCategoryDto
    {
        [JsonProperty("categoryId")]
        public Guid CategoryId { get; set; }

        [JsonProperty("categoryName")]
        public string CategoryName { get; set; }

        [JsonProperty("categoryType")]
        public string CategoryType { get; set; }
    }

    public class ProductExtraDippingDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("detail")]
        public string Detail { get; set; }

        [JsonProperty("productExtraDippingAllergy")]
        public List<ProductExtraDippingAllergyDto> ProductExtraDippingAllergy { get; set; }

        [JsonProperty("productExtraDippingPrice")]
        public List<ProductExtraDippingPriceDto> ProductExtraDippingPrice { get; set; }
    }

    public class ProductExtraDippingAllergyDto
    {
        [JsonProperty("allergyName")]
        public string AllergyName { get; set; }
    }

    public class ProductExtraDippingPriceDto
    {
        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class ProductExtraToppingDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("detail")]
        public string Detail { get; set; }

        [JsonProperty("productExtraToppingAllergy")]
        public List<ProductExtraToppingAllergyDto> ProductExtraToppingAllergy { get; set; }

        [JsonProperty("productExtraToppingPrice")]
        public List<ProductExtraToppingPriceDto> ProductExtraToppingPrice { get; set; }
    }

    public class ProductExtraToppingAllergyDto
    {
        [JsonProperty("allergyName")]
        public string AllergyName { get; set; }
    }

    public class ProductExtraToppingPriceDto
    {
        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class ProductItemOutlineDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }

}
