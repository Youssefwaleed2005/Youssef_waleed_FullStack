using Assignment_2.Repo;
using Assignment_3.Exceptions;



namespace Assignment_2.Services
{
    public class ProductService:IProductServices
    {
        private IProductRepos _productRepo;

        public ProductService(IProductRepos productRepo)
        {
            _productRepo = productRepo;

        }

        public Product? GetProduct(int id)
        {
            var product = _productRepo.GetProduct(id);
            if (product == null)
            {
                throw new NotFoundException("Product not found!");
            }
            else return product;
        }
        public Product CreateProduct(Product product)
        {
            if(_productRepo.ExistsByTitle(product.Title))
            {
                throw new ConflictException("Title already exists");
            }
            return _productRepo.CreateProduct(product);
        }
        public List<Product> GetAll()
        {
            return _productRepo.GetAll();
        }

        public bool DeleteProduct(int id)
        {
            return _productRepo.DeleteProduct(id);
        }

    }
}
