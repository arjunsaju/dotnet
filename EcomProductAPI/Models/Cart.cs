using EcomProductAPI.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using System.Text.Json.Serialization;

namespace EcomProductAPI.Models
{
    [Table("tbl_cart")]
    public partial class Cart
    {
        [Key]
        public int cart_id   { get; set; }
       
        public int? product_id { get; set; }
        public int? qty { get; set; }
        public int? amount { get; set; }
        public int? user_id { get; set; }
        
        public Product ? product { get; set; }


    }
}
