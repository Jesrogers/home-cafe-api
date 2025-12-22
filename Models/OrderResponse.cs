namespace HomeCafeApi.Models.Responses
{
    public class OrderResponse
    {
        public long Id { get; set; }
        public string MenuItemName { get; set; } = null!;
        public string CustomerName { get; set; } = null!;
        public string? Sweetener { get; set; }
        public string? SpecialRequests { get; set; }
        public string Status { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
