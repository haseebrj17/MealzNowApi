using System;
namespace MealzNow.Core.Dto
{
    public class DishOfDayDto
    {
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }
        public DateTime Validity { get; set; }
        public Guid? ProductId { get; set; }
        public int Sequence { get; set; }
    }
}

