namespace HomeCafeApi.Models
{
    public class Order
    {
        public long Id { get; set; }
        public long MenuItemId { get; set; }
        public required MenuItem MenuItem { get; set; }
        public required string CustomerName { get; set; }
        public Sweetener Sweetener { get; set; } = Sweetener.None;
        public string? SpecialRequests { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.InProgress;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }

    public enum Sweetener { None, MapleSyrup, PumpkinSpice }
    public enum OrderStatus { InProgress, Complete }
}



