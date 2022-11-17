namespace EcomProductAPI.DTO
{
    public class CartDTO
    {
        public int cart_id { get; set; }

        public int? product_id { get; set; }
        public int? qty { get; set; }
        public int? amount { get; set; }
        public int? user_id { get; set; }

        
    }
}
