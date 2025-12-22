namespace HomeCafeApi.Models
{
    public class UpdateMenuItemRequest
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public bool? AllowDecafOption { get; set; }
        public bool? AllowSugarOption { get; set; }
        public bool? IsItemOutOfStock { get; set; }
    }
}
