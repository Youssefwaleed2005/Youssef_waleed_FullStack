using Assignment_3.Models;

namespace Assignment_2.Services
{
    public interface IProductServices
    {
        public Product GetProduct(int id);

        public Product CreateProduct(Product product);

        public PagedResult<Product> GetAll(ProductFilterParams param);

        public bool DeleteProduct(int id);
    }
}
