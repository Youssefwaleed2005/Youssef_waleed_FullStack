using Assignment_3.Data;
using Assignment_3.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment_2.Repo
{
    public class ProductRepo:IProductRepos
    {
        private readonly AppDbContext _dbContext;
        public ProductRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Product>? GetProduct(int id)
        {
            var query = _dbContext.Products.AsQueryable();

            query= query.Include(p=>p.User).Where(p=>p.Id == id);
            var product = await query.SingleAsync();
            return product;
        }

        public async Task<Product> CreateProduct(Product newProduct)
        {
            _dbContext.Products.Add(newProduct);
            await _dbContext.SaveChangesAsync();


            return newProduct;
        }
        //public List<Product> GetAll()
        //{
        //    return _products;
        //}

        //public bool DeleteProduct(int id)
        //{
        //    var product = _products.FirstOrDefault(t => t.Id == id);
        //    if (product == null)
        //    {
        //        return false;
        //    }
        //    _products.Remove(product);
        //    _lastId -= 1;
        //    return true;
        //}
        //public bool ExistsByTitle(string title)
        //{
        //    return _products.Any(t => t.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        //}
    }
}
