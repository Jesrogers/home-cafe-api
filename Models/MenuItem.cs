namespace HomeCafeApi.Models
{
    public class MenuItem
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public bool ShouldAllowCaffeine { get; set; } = true;
        public bool ShouldAllowSugar { get; set; } = true;
    }
}