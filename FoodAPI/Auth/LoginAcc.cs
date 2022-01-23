using System.ComponentModel.DataAnnotations;

namespace FoodAPI.Auth
{
    public class LoginAcc
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
