using Ecommerce.API.Entities;
using Ecommerce.API.Models.CategoryDtos;
using Ecommerce.API.Repository.Interfaces;
using Ecommerce.API.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;
using static Ecommerce.API.Models.Examples;

namespace Ecommerce.API.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var result = await _categoryService.GetAllCategoryAsync();

            return Ok(result);
        }

        [HttpPost]
        [SwaggerRequestExample(typeof(CategoryForCreatingDto), typeof(CategoryForCreatingDtoExample))]

        public async Task<IActionResult> CreateNewCategory([FromBody] CategoryForCreatingDto dto)
        {
            var result = await _categoryService.CreateNewCategoryAsync(dto);

            return Created();
        }

        [HttpPut]
        [SwaggerRequestExample(typeof(CategoryForUpdatingDto), typeof(CategoryForUpdatingDtoExample))]
        public async Task<IActionResult> UpdateCategory([FromBody] CategoryForUpdatingDto dto)
        {
            var result = await _categoryService.UpdateCategoryAsync(dto);

            if(result == null)
                return NotFound();

            return Ok("Updated Successfully!");
        }

        [HttpDelete("{Id}")]

        public async Task<IActionResult> DeleteCategory([FromRoute] Guid Id)
        {
            var result =await _categoryService.DeleteCategoryAsync(Id);
            if (result == 0)
            {
                return NotFound();
            }
            return Ok("Category Deleted!");
        }
    }
}
