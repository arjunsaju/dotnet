using EcomProductAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcomProductAPI.Models
{
    [Table("tbl_productlist")]
    public class Product
    {
        public Product()
        {

            OrderItems = new HashSet<OrderItem>();
            //Orders = new HashSet<Order>();
            Carts = new HashSet<Cart>();
        }
        [Key]
        public int product_id { get; set; }
        public string product_name { get; set; }
        public string description { get; set; }
        public int stock { get; set; }
        public int price { get; set; }
        public string ? image { get; set; }


        public ICollection<OrderItem> OrderItems { get; set; }
        //public ICollection<Order> Orders { get; set; }
        public ICollection<Cart> Carts { get; set; }
    }
}
