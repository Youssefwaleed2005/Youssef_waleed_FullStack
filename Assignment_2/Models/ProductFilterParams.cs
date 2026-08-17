namespace Assignment_3.Models
{
    public class ProductFilterParams:PaginationParams
    {
        public string? Search { get; set; }
        public double? Price { get; set; }
        public bool? IsAvalaible { get; set; }

        public string? SortBy { get; set; }
        public string? Order { get; set; } = "asc";
    }
}
