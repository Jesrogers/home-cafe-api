namespace HomeCafeApi.Models
{
    public class UpdateMenuItemRequest
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public bool? ShouldAllowCaffeine { get; set; }
        public bool? ShouldAllowSugar { get; set; }
    }
}
