using System.ComponentModel.DataAnnotations;

namespace Assignment_3.DTOs
{
    public class CreatedProductRequest
    {
        
        public int Id { get; set; } = 0;
        public string Title { get; set; } = " ";
        public double price { get; set; }

        public bool IsAvailable {  get; set; }

    }
}
