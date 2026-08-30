using Assignment_3.Models;
using Assignment_3.DTOs;

namespace Assignment_2.Services
{
    public interface IProductServices
    {
        public Task<ProductItemDto> GetProduct(int id);

        public Task<ProductItemDto> CreateProduct(CreatedProductRequest product);

        public Task<List<Product>> GetAll(ProductFilterParams param);

        //public PagedResult<Product> GetAll(ProductFilterParams param);

        //public bool DeleteProduct(int id);
    }
}
