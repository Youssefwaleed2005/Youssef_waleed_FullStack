using Assignment_3.Models;

namespace Assignment_2.Repo
{
    public interface IProductRepos
    {
        public Task<Product> GetProduct(int id);

        public Task<Product> CreateProduct(Product product);

        public IQueryable<Product> GetAll();

        //public List<Product> GetAll();

        //public bool DeleteProduct(int id);
        //public bool ExistsByTitle(string title);
    }
}
