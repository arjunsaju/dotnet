namespace EcomProductAPI.DTO
{
    public class ProductDTO
    {
        public int product_id { get; set; }
        public string product_name { get; set; }
        public string description { get; set; }
        public int stock { get; set; }
        public int price { get; set; }
        public string? image { get; set; }
    }
}
