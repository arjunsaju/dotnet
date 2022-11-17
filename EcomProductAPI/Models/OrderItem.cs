using EcomProductAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcomProductAPI.Models
{
    [Table("tbl_order_items")]
    public partial class OrderItem
    {
        [Key]
        public int order_item_id { get; set; }
        
        public int? order_id { get; set; }
        public int? product_id { get; set; }
        public int? quantity { get; set; }

        public Order? order { get; set; }
        public Product? product { get; set; }
    }
}
