using ProductAPI.Data;
using ProductAPI.Models;

namespace ProductAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product? GetById(int id)
        {
            return _context.Products
                .FirstOrDefault(p => p.Id == id);
        }

        public Product Create(Product product)
        {
            _context.Products.Add(product);

            _context.SaveChanges();

            return product;
        }

        public bool Update(Product product)
        {
            var existingProduct = _context.Products
                .FirstOrDefault(p => p.Id == product.Id);

            if (existingProduct == null)
            {
                return false;
            }

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.Quantity = product.Quantity;

            _context.SaveChanges();

            return true;
        }

        public bool Delete(int id)
        {
            var product = _context.Products
                .FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return false;
            }

            _context.Products.Remove(product);

            _context.SaveChanges();

            return true;
        }
    }
}