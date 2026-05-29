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

        [HttpGet]

        public IEnumerable<string> GetAllCategories()
        {
            return _context.Categories.Select(c => c.Name).ToList();
        }

        [HttpGet("single/{Id}")]
        public string GetSingleCategoryById(int Id)
        {
            return _context.Categories.Where(c => c.Id == Id).Select(c => c.Name).FirstOrDefault() ?? $"Category with ID {Id} not found.";
        }

        [HttpPost]

        public string AddCategory([FromBody]  Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return $"Category '{category.Name}' added successfully.";
        }


        [HttpPut("{categoryId}")]

        public string UpdateCategory([FromRoute] int categoryId, [FromBody] string newCategoryName)
        {
            var category = _context.Categories.Find(categoryId);

            if (category == null)
            {
                return $"Category with ID {categoryId} not found.";
            }
            else            {
                category.Name = newCategoryName;
                _context.SaveChanges();
                return $"Category {category.Name} updated successfully to '{newCategoryName}'.";
            }
        }

        [HttpDelete("{CategoryId}")]

        public string DeleteCategory([FromRoute] int CategoryId)
        {
            var category = _context.Categories.Find(CategoryId);

            if (category == null)
            {
                return $"Category with ID {CategoryId} not found.";
            }
            else
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
                return $"Category '{category.Name}' deleted successfully.";
            }
        }
    }
}
