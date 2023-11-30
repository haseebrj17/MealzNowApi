using static MealzNow.Core.Enum.Enums;

namespace MealzNow.Core.RequestModels
{
    public class CommonRequest
    {
        public Guid? Id { get; set; }
        public List<Guid>? Ids { get; set; }
        public Guid? OrderId { get; set; }
        public OrderStatus? OrderStatus { get; set; }
        public Guid? DayId { get; set; }
        public Guid? ProductByTimingId { get; set; }
    }
}