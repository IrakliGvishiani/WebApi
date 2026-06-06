using Ecommerce.API.Models.CategoryDtos;
using Ecommerce.API.Models.Product;
using Ecommerce.API.Models.SupplierDtos;
using Swashbuckle.AspNetCore.Filters;

namespace Ecommerce.API.Models;


public class Examples
{
    public sealed record ProductForCreatingDtoExample : IExamplesProvider<ProductForCreatingDto>
    {
        public ProductForCreatingDto GetExamples()
        {
            return new ProductForCreatingDto
            {
                ProductName = "Samsung Galaxy A51",
                Price = 999.99m,
                Quantity = 100,
                CategoryId = Guid.Parse("11111111-0000-0000-0000-000000000001"),
                SupplierId = Guid.Parse("22222222-0000-0000-0000-000000000001")
            };
        }
    }

    public sealed record CategoryForCreatingDtoExample : IExamplesProvider<CategoryForCreatingDto>
    {
        public CategoryForCreatingDto GetExamples()
        {
            return new CategoryForCreatingDto
            {
                CategoryName = "Groceries",
            };
        }
    }

    public sealed record CategoryForUpdatingDtoExample : IExamplesProvider<CategoryForUpdatingDto>
    {
        public CategoryForUpdatingDto GetExamples()
        {
            return new CategoryForUpdatingDto
            {
                Id = Guid.Parse("82670a7a-cc2b-4cb9-5ef6-08dec3ccd780"),
                CategoryName = "Toys"
            }; 
        }
    }

    public sealed record SupplierForCreatingDtoExample : IExamplesProvider<SupplierForCreatingDto>
    {
        public SupplierForCreatingDto GetExamples()
        {
            return new SupplierForCreatingDto
            {
                SupplierName = "Amazon"
            };
        }
    }

    public sealed record SupplierForUpdatingDtoExample : IExamplesProvider<SupplierForUpdatingDto>
    {
        public SupplierForUpdatingDto GetExamples()
        {
            return new SupplierForUpdatingDto
            {
                Id = Guid.Parse("de9095aa-ef9c-4111-6669-08dec3d51b81"),
                SupplierName = "Alibaba"
            };
        }
    }
}