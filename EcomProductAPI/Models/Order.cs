//using EcomProductAPI.TestModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcomProductAPI.Models
{
    [Table("tbl_Order")]
    public  class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }
        [Key]

        public int order_id { get; set; }
        public DateTime? order_date { get; set; }
        public int? user_id { get; set; }
        public int? order_total { get; set; }
        public string? payment_status { get; set; }
        public string? order_status { get; set; }            
        public  ICollection<OrderItem> OrderItems { get; set; }
    }
}
