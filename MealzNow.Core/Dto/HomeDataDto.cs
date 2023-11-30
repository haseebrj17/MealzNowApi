using MealzNow.Core.Dto;
using MealzNow.Db.Models;
using System;
using System.Collections.Generic;

namespace MealzNow.Core.Dto
{
    public class HomeDataDto
    {
        public Guid ClientId { get; set; }
        public Guid FranchiseId { get; set; }
        public List<BannerDto> Banners { get; set; } = new List<BannerDto>();
        public List<PackageDto> Packages { get; set; } = new List<PackageDto>();
        public List<ProductDto> Products { get; set; } = new List<ProductDto>();
        public List<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
        public List<SubCategoryDto> AllSubCategories { get; set; } = new List<SubCategoryDto>();
    }
}
