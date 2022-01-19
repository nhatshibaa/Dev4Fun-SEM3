using System.ComponentModel.DataAnnotations;

namespace FoodAPI.Auth
{
    public class LoginAcc
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
