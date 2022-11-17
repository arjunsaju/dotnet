using System.ComponentModel.DataAnnotations;

namespace EcomProductAPI.ViewModels
{
    public class RegisterViewModel
    {
        
        [EmailAddress]
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}

