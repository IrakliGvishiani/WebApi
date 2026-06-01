using Ecommerce.API.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]

        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productRepository.GetAllProductsAsync();
            if (products == null || !products.Any())
            {
                return NotFound("Products are empty!");
            }
            return Ok(products);
        }

        [HttpGet("single/{Id}")]

        public async Task<IActionResult> GetProductById(Guid Id)
        {
            var product = await _productRepository.GetProductByIdAsync(Id);
            if (product == null)
            {
                return NotFound("Product not found!");
            }
            return Ok(product);
        }
    }
}
