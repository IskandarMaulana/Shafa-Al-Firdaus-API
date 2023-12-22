using System.ComponentModel.DataAnnotations;

namespace Shafa_Al_Firdaus_API.Models
{
    public class LoginViewModel
    {
        [Key]
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
