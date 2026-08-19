namespace Assignment_3.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public bool IsAvaliable { get; set; }

        public double Price {  get; set; }

        public int UserId {  get; set; }

        public User? User { get; set; }
    }
}
