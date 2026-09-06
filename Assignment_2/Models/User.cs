using Assignment_3.Enums;

namespace Assignment_3.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email {  get; set; }

        public Role Role { get; set; } = Role.User;

        public string PasswordHash { get; set; }


        public ICollection<Product> Product{ get; set; } = new List<Product>();
    }
}
