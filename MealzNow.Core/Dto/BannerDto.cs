﻿using System;
namespace MealzNow.Core.Dto
{
    public class BannerDto
    {
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }
        public int Sequence { get; set; }
        public DateTime Validity { get; set; }
        public Guid? BrandId { get; set; }
        public Guid? ProductId { get; set; }
        public Guid? CategoryId { get; set; }
    }
}