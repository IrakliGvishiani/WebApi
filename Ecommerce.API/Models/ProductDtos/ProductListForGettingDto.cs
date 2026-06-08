namespace Ecommerce.API.Models.ProductDtos
{
    public class ProductListForGettingDto
    {
        public Guid Id { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }
    }
}
