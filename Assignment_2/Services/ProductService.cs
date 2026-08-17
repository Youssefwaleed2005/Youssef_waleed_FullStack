using Assignment_2.Repo;
using Assignment_3.Exceptions;
using Assignment_3.Models;



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
        public PagedResult<Product> GetAll(ProductFilterParams param)
        {
            IEnumerable<Product> products = _productRepo.GetAll();
            var  totalcount = products.Count();

            if (!string.IsNullOrEmpty(param.Search))
            {
                products = products.Where(p => p.Title.Contains(param.Search, StringComparison.OrdinalIgnoreCase));
            }

            if (param.IsAvalaible.HasValue)
            {
                products = products.Where(p => p.IsAvaliable == param.IsAvalaible);
            }

            if (param.Price.HasValue)
            {
                products = products.Where(p => p.Price == param.Price);
            }

            var allowedSort =
                new Dictionary<string, Func<Product, object>>
                {
                    ["Title"] = p => p.Title,
                    ["Price"] = p => p.Price,
                    ["IsAvaliable"] = p => p.IsAvaliable
                };

            if (allowedSort.TryGetValue(
                    param.SortBy ?? "Price", out var keySelector))
            {
                products = param.Order == "desc"
                    ? products.OrderByDescending(keySelector)
                    : products.OrderBy(keySelector);
            }

            products = products.OrderByDescending(p => p.Title);

            products = products.Skip((param.Page - 1) * param.PageSize).Take(param.PageSize).ToList();

            return new PagedResult<Product>
            {
                Data = products,
                Page = param.Page,
                PageSize = param.PageSize,
                TotalCount = totalcount
            };

        }

        public bool DeleteProduct(int id)
        {
            return _productRepo.DeleteProduct(id);
        }

    }
}
