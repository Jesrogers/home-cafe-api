using System.ComponentModel.DataAnnotations.Schema;

namespace HomeCafeApi.Models
{
    public class Order
    {
        public long Id { get; set; }
        public long MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; } = null!;
        public required string CustomerName { get; set; }
        public string? Sweetener { get; set; }
        public string? SpecialRequests { get; set; }
        public string Status { get; set; } = "Pending";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}



