using Microsoft.AspNetCore.Mvc;
using ProductAPI.Models;
using ProductAPI.Services;

namespace ProductAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        // GET: api/Products
        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _service.GetAll();

            return Ok(products);
        }

        // GET: api/Products/1
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = _service.GetById(id);

            if (product == null)
            {
                return NotFound(new
                {
                    message = "Product not found"
                });
            }

            return Ok(product);
        }

        // POST: api/Products
        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            var createdProduct = _service.Create(product);

            return Ok(createdProduct);
        }

        // PUT: api/Products/1
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(
            int id,
            Product product)
        {
            var updated = _service.Update(id, product);

            if (!updated)
            {
                return NotFound(new
                {
                    message = "Product not found"
                });
            }

            return Ok(new
            {
                message = "Product updated successfully"
            });
        }

        // DELETE: api/Products/1
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var deleted = _service.Delete(id);

            if (!deleted)
            {
                return NotFound(new
                {
                    message = "Product not found"
                });
            }

            return Ok(new
            {
                message = "Product deleted successfully"
            });
        }
    }
}