using System;
using MealzNow.Db.Models;

namespace MealzNow.Core.Dto
{
    public class ProductsDataDto
    {
        public List<PackageDto> Package { get; set; } = new List<PackageDto>();
        public List<ProductDto> Products { get; set; } = new List<ProductDto>();
        public List<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
    }
}

