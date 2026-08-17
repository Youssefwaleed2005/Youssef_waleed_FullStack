using Assignment_3.Models;

namespace Assignment_2.Repo
{
    public class ProductRepo:IProductRepos
    {
        private static List<Product> _products = new List<Product>();
        private static int _lastId = 1;

        public Product? GetProduct(int id)
        {
            var product = _products.FirstOrDefault(x => x.Id == id);
            return product;
        }

        public Product CreateProduct(Product product)
        {
            product.Id = _lastId++;
            _products.Add(product);
            return product;
        }
        public List<Product> GetAll()
        {
            return _products;
        }

        public bool DeleteProduct(int id)
        {
            var product = _products.FirstOrDefault(t => t.Id == id);
            if (product == null)
            {
                return false;
            }
            _products.Remove(product);
            _lastId -= 1;
            return true;
        }
        public bool ExistsByTitle(string title)
        {
            return _products.Any(t => t.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        }
    }
}
