using System.ComponentModel.DataAnnotations;

namespace FoodAPI.Models

{
    public class Account
    {
        public int Id { get; set; }
        [Required]
        public string Fullname { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public int PhoneNum { get; set; }

        [Required]
        public int Gender { get; set; }
        public int RoleId { get; set; }
        public int Status { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
