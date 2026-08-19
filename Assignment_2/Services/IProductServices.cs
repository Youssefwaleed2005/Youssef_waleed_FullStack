using Assignment_3.Models;

namespace Assignment_2.Services
{
    public interface IProductServices
    {
        public Task<Product> GetProduct(int id);

        public Task<Product> CreateProduct(Product product);

        //public PagedResult<Product> GetAll(ProductFilterParams param);

        //public bool DeleteProduct(int id);
    }
}
