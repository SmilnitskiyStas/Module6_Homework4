using Books_Shop.Entities;
using Books_Shop.Interfaces;

namespace Books_Shop.Infrastructura
{
    public class MemoryDataProvider : IDataProvider
    {
        private List<Product> _data = new List<Product>() 
        { 
            new Product() { Id = 1, Title = "Harry", Author = "Tom", DateOfCreate = DateTime.Parse("1999.10.12"), Price = 14.99m },
            new Product() { Id = 2, Title = "Potter", Author = "Tom2", DateOfCreate = DateTime.Parse("2003.10.12"), Price = 18.99m },
        };

        public void CreateProduct(Product product)
        {
            _data.Add(product);
        }

        public void DeleteProductById(int id)
        {
            _data.Remove(GetProductById(id));
        }

        public List<Product> GetAllProducts()
        {
            return _data;
        }

        public Product GetProductById(int id)
        {
            return _data.FirstOrDefault(p => p.Id == id);
        }

        public void UpdateProduct(Product product)
        {
            Product existingProduct = _data.FirstOrDefault(p => p.Id == product.Id);

            if (existingProduct != null)
            {
                existingProduct.Title = product.Title;
                existingProduct.Author = product.Author;
                existingProduct.DateOfCreate = product.DateOfCreate;
                existingProduct.Price = product.Price;
            }
        }
    }
}
