namespace HomeCafeApi.Models
{
    public class UpdateMenuItemRequest
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public bool? allowDecafOption { get; set; }
        public bool? allowSugarOption { get; set; }
    }
}
