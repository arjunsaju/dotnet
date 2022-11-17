using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcomProductAPI.Models
{
    [Table("tbl_user")]
    public class UserInfo
    {
        [Key]
        public int Id { get; set; }

        public string username { get; set; }

        public string password { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
    }
        
}
