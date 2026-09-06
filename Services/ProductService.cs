using ProductAPI.Models;
using ProductAPI.Repositories;

namespace ProductAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public List<Product> GetAll()
        {
            return _repository.GetAll();
        }

        public Product? GetById(int id)
        {
            return _repository.GetById(id);
        }

        public Product Create(Product product)
        {
            return _repository.Create(product);
        }

        public bool Update(int id, Product product)
        {
            product.Id = id;

            return _repository.Update(product);
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}