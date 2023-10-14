using Books_Shop.Entities;

namespace Books_Shop.Interfaces
{
    public interface IDataProvider
    {
        public List<Product> GetAllProducts();
        public Product GetProductById(int id);
        public void CreateProduct(Product product);
        public void UpdateProduct(Product product);
        public void DeleteProductById(int id);
    }
}
