using Ecommerce.API.Entities;
using Ecommerce.API.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryRepository.GetAllCategoriesAsync();
            if (categories == null || !categories.Any())
            {
                return NotFound("Categories are empty!");
            }
            return Ok(categories);
        }

        [HttpGet("single/{Id}")]

        public async Task<IActionResult> GetCategoryById(Guid Id)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(Id);
            if (category == null)
            {
                return NotFound("Category not found!");
            }
            return Ok(category);
        }

        [HttpPost]

        public async Task<IActionResult> AddCategory([FromBody] Category category)
        {
            await _categoryRepository.AddCategoryAsync(category);

            return Created();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(Guid Id)
        {
            var result = await _categoryRepository.GetCategoryByIdAsync(Id);

            if (result == null)
            {
                return NotFound();
            }

            await _categoryRepository.DeleteCategoryAsync(Id);
            return NoContent();
        }

        [HttpPut]

        public async Task<IActionResult> UpdateCategory([FromBody] Category category)
        {
            var existingCategory = await _categoryRepository.GetCategoryByIdAsync(category.Id);
            if (existingCategory == null)
            {
                return NotFound();
            }
            existingCategory.CategoryName = category.CategoryName;
            await _categoryRepository.UpdateCategoryAsync(existingCategory);
            return Ok($"Category ${category.CategoryName} Updated Successfully!");

        }
    }
}
