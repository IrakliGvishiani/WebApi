using Ecommerce.API.Data;
using Ecommerce.API.Entities;
using Ecommerce.API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.API.Repository
{
    public class ProductRepository : IProductRepository
    {

        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddProductAsync(Product product)
        {
           await _context.Products.AddAsync(product);
        }

        public async Task DeleteProductAsync(Guid id)
        {
            var result = _context.Products.Find(id);
            if (result != null)
            {
                _context.Products.Remove(result);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
           return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(Guid id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task UpdateProductAsync(Product product)
        {
            var result = _context.Products.Find(product.Id);

            if (result != null)
            {
                _context.Products.Update(product);
                await _context.SaveChangesAsync();
            }
        }
    }
}
