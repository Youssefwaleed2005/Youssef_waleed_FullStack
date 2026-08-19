namespace Assignment_3.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public ICollection<Product> Product{ get; set; } = new List<Product>();
    }
}
