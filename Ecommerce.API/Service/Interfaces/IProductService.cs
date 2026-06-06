using Ecommerce.API.Entities;
using Ecommerce.API.Models.Product;
using Ecommerce.API.Models.ProductDtos;

namespace Ecommerce.API.Service.Interfaces
{
    public interface IProductService
    {
        Task<int> CreateNewProductAsync(ProductForCreatingDto model);

        Task<IEnumerable<ProductForGettingDto>> GetAllProductAsync();

        Task<int> DeleteProductAsync(Guid ProductId);

        Task<int> UpdateProductAsync(ProductForUpdatingDto request);
    }
}
