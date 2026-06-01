using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    // https://localhost:7245
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        //private static List<string> Categories = new List<string>
        //{
        //    "Electronics",
        //    "Books",
        //    "Clothing",
        //    "Home & Kitchen"
        //};



        /// <summary>
        /// Get All Categories
        /// </summary>

        [HttpGet]

        public IActionResult GetAllCategories()
        {
            return Ok(_context.Categories); // 200
        }


        /// <summary>
        /// Get Single Category By Id
        /// </summary>
        [HttpGet("single/{Id}")]
        public Category GetSingleCategoryById(int Id)
        {
            return _context.Categories.Find(Id);
        }

        /// <summary>
        /// Add new category
        /// </summary>
        [HttpPost]

        public IActionResult AddCategory([FromBody]  Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return Created(); // 201
        }

        /// <summary>
        /// Update category name by id
        /// </summary>

        [HttpPut("{categoryId}")]

        public IActionResult UpdateCategory([FromRoute] int categoryId, [FromBody] string newCategoryName)
        {
            var category = _context.Categories.Find(categoryId);

            if(string.IsNullOrWhiteSpace(newCategoryName))
            {
                return BadRequest("Category Name Required!"); // 400
            }

            if (category == null)
            {
                return NotFound($"Category Not Found!"); // 404
            }
            else            {
                category.Name = newCategoryName;
                _context.SaveChanges();
                return Ok(category);
            }
        }

        /// <summary>
        /// Delete category by id
        /// </summary>

        [HttpDelete("{CategoryId}")]

        public IActionResult DeleteCategory([FromRoute] int CategoryId)
        {
            var category = _context.Categories.Find(CategoryId);

            if (category == null)
            {
                return NotFound("Not Found!");
            }
            else
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
                return Ok($"Category ${category} deleted successfully");
            }
        }
    }
}
