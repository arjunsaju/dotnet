namespace EcomProductAPI.DTO
{
    public class OrderDTO
    {
        //public OrderDTO()
        //{
        //    OrderItemsDTO = new HashSet<OrderItemsDTO>();
        //}
     

        public int order_id { get; set; }
        public DateTime? order_date { get; set; }
        public int? user_id { get; set; }
        public int? order_total { get; set; }
        public string? payment_status { get; set; }
        public string? order_status { get; set; }
        public ICollection<OrderItemDTO> OrderItemsDTO { get; set; }
    }
}
