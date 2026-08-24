namespace Assignment_3.DTOs
{
    public class ProductItemDto
    {
        public int Id { get; set; }

        public string Title {  get; set; }

        public DateTime CreatedAt {  get; set; }

        public double price {  get; set; }
        
        public bool IsAvailable {  get; set; }

    }
}
