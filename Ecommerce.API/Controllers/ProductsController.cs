using Ecommerce.API.Entities;
using Ecommerce.API.Exceptions;
using Ecommerce.API.Models.Product;
using Ecommerce.API.Models.ProductDtos;
using Ecommerce.API.Repository.Interfaces;
using Ecommerce.API.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;
using System.Net;
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
          var createdProduct =  await _productRepository.CreateNewProductAsync(request);
            var result = new CommonResponse(CommonResponseMessage.SuccessMessage,createdProduct,true,Convert.ToInt32(HttpStatusCode.Created));
            return StatusCode(result.HttpStatusCode, result);
        }

        [HttpGet]

        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productRepository.GetAllProductAsync();
            var response = new CommonResponse(CommonResponseMessage.SuccessMessage, products,true, Convert.ToInt32(HttpStatusCode.OK));
            return StatusCode(response.HttpStatusCode, response);
        }

        [HttpGet("single/{productId}")]

        public async Task<IActionResult> GetProductById([FromRoute] Guid productId)
        {
            var product = await _productRepository.GetProductAsync(productId);
            var response = new CommonResponse(CommonResponseMessage.SuccessMessage, product,true, Convert.ToInt32(HttpStatusCode.OK));

            return StatusCode(response.HttpStatusCode, response);
        }

        [HttpPut]

        public async Task<IActionResult> UpdateProduct([FromBody] ProductForUpdatingDto product) {


            var result = await _productRepository.UpdateProductAsync(product);

            var response = new CommonResponse(CommonResponseMessage.SuccessMessage, result, true, Convert.ToInt32(HttpStatusCode.OK));


            return StatusCode(response.HttpStatusCode, response);
        }

        [HttpDelete("{Id}")]

        public async Task<IActionResult> DeleteProduct([FromRoute]Guid Id)
        {
            var result = await _productRepository.DeleteProductAsync(Id);
            var response = new CommonResponse(CommonResponseMessage.SuccessMessage, result, true, Convert.ToInt32(HttpStatusCode.NoContent));

            return StatusCode(response.HttpStatusCode, response);
        }
    }
}
