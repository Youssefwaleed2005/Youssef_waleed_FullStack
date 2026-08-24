using System.ComponentModel.DataAnnotations;

namespace Assignment_3.DTOs
{
    public class UpdateProductRequest
    {
        [Required]
        [MaxLength(200)]

        public string Title {  get; set; } =" ";

        public double Price { get; set; }

        public bool IsAvailable {  get; set; }
    }
}
