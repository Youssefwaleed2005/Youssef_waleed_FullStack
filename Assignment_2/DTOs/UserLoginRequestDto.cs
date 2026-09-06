using System.ComponentModel.DataAnnotations;

namespace Assignment_3.DTOs
{
    public class UserLoginRequestDto
    {
        [Required]
        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
    }
}
