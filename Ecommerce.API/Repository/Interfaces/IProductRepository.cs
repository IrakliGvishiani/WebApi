using Ecommerce.API.Entities;

namespace Ecommerce.API.Repository.Interfaces
{
    public interface IProductRepository
    {

        Task<IEnumerable<Product>> GetAllProductsAsync();

        Task<Product> GetProductByIdAsync(Guid id);

        Task AddProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(Guid id);
    }
}
