using System.ComponentModel.DataAnnotations;
using System.Data;
using Assignment_3.Enums;

namespace Assignment_3.DTOs
{
    public class CreateUserRequest
    {
        public int Id { get; set; } = 0;

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string Password { get; set; }

        public Role Role { get; set; } = Role.User;
    }
}
