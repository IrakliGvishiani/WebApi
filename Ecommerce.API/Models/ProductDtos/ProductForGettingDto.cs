using Ecommerce.API.Models.CategoryDtos;

namespace Ecommerce.API.Models.ProductDtos
{
    public class ProductForGettingDto
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }

       public CategoryForGettingDto Category { get; set; }
     
    }
}
