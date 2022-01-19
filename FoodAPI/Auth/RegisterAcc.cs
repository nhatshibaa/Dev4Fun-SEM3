using System.ComponentModel.DataAnnotations;

namespace FoodAPI.Auth
{
    public class RegisterAcc
    {
        [Required]
        [StringLength(100)]
        public string Fullname { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Must be more than 8 characters")]
        public string Password { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Must be more than 10 characters")]
        public int PhoneNum { get; set; }

        [Required]
        public int Gender { get; set; }
    }
}
