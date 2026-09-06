using ProductAPI.Models;

namespace ProductAPI.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetAll();

        Product? GetById(int id);

        Product Create(Product product);

        bool Update(Product product);

        bool Delete(int id);
    }
}