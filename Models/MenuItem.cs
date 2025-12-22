namespace HomeCafeApi.Models
{
    public class MenuItem
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public bool AllowDecafOption { get; set; } = true;
        public bool AllowSugarOption { get; set; } = true;
        public bool IsItemOutOfStock { get; set; } = false;
    }
}