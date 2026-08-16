namespace Assignment_2.Services
{
    public interface IProductServices
    {
        public Product GetProduct(int id);

        public Product CreateProduct(Product product);

        public List<Product> GetAll();

        public bool DeleteProduct(int id);
    }
}
