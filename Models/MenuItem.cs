namespace HomeCafeApi.Models
{
    public class MenuItem
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public bool allowDecafOption { get; set; } = true;
        public bool allowSugarOption { get; set; } = true;
    }
}