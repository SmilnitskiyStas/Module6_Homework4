using Books_Shop.Entities;

namespace Books_Shop.Interfaces
{
    public interface IProductService
    {
        public List<Product> GetAll();
        public Product GetById(int id);
        public void Create(Product product);
        public void Update(Product product);
        public void DeleteById(int id);
    }
}
