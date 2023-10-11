using Books_Shop.Entities;
using Books_Shop.Interfaces;

namespace Books_Shop.Services
{
    public class ProductService : IProductService
    {
        private readonly IDataProvider _dataProvider;

        public ProductService(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public void Create(Product product)
        {
            product = CreateIdForProduct(product);

            if (_dataProvider.GetProductById(product.Id) != null)
            {
                return;
            }

            _dataProvider.CreateProduct(product);
        }

        public void DeleteById(int id)
        {
            _dataProvider.DeleteProductById(id);
        }

        public List<Product> GetAll()
        {
            return _dataProvider.GetAllProducts();
        }

        public Product GetById(int id)
        {
            return _dataProvider.GetProductById(id);
        }

        public void Update(Product product)
        {
            if (_dataProvider.GetProductById(product.Id) == null)
            {
                return;
            }

            _dataProvider.UpdateProduct(product);
        }

        private Product CreateIdForProduct(Product product)
        {
            List<Product> products = _dataProvider.GetAllProducts();

            product.Id = products.Count + 1;

            return product;
        }
    }
}
