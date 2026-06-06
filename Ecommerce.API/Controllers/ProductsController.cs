using Ecommerce.API.Entities;
using Ecommerce.API.Models.Product;
using Ecommerce.API.Repository.Interfaces;
using Ecommerce.API.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;
using static Ecommerce.API.Models.Examples;

namespace Ecommerce.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productRepository;

        public ProductsController(IProductService productRepository)
        {
            _productRepository = productRepository;
        }

        //[HttpGet("{pageNumber}/{pageSize}")]

        //public async Task<IActionResult> GetAllProducts([FromRoute] int pageNumber,[FromRoute] int pageSize)
        //{
        //    var products = await _productRepository.GetAllAsync(pageNumber,pageSize,tracking: false);

        //    if (products == null || !products.Any())
        //    {
        //        return NotFound("Products are empty!");
        //    }
        //    return Ok(products);
        //}

        //[HttpGet("single/{Id}")]

        //public async Task<IActionResult> GetProductById(Guid Id)
        //{
        //    var product = await _productRepository.GetByIdAsync(Id);
        //    if (product == null)
        //    {
        //        return NotFound("Product not found!");
        //    }
        //    return Ok(product);
        //}

        [HttpPost]
        [SwaggerRequestExample(typeof(ProductForCreatingDto), typeof(ProductForCreatingDtoExample))]

        public async Task<IActionResult> CreateProduct([FromBody] ProductForCreatingDto request)
        {
            await _productRepository.CreateNewProductAsync(request);
            return Created();
        }

        [HttpGet]

        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productRepository.GetAllProductAsync();
            return Ok(products);
        }


        [HttpDelete("{Id}")]

        public async Task<IActionResult> DeleteProduct([FromRoute]Guid Id)
        {
            var result = await _productRepository.DeleteProductAsync(Id);
            if (result == 0)
                return NotFound("Product not found!");
            return Ok();
        }
    }
}
