using Ecommerce.API.Data;
using Ecommerce.API.Entities;
using Ecommerce.API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.API.Repository
{
    public class OrderItemRepository : IOrderItemRepository
    {

        private readonly ApplicationDbContext _context;

        public OrderItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddOrderItemAsync(OrderItem orderItem)
        {
            await _context.OrderItems.AddAsync(orderItem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrderItemAsync(Guid id)
        {
            var result = await _context.OrderItems.FindAsync(id);
            if (result != null)
            {
                _context.OrderItems.Remove(result);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<OrderItem>> GetAllOrderItemsAsync()
        {
            return await _context.OrderItems.ToListAsync();
        }

        public async Task<OrderItem> GetOrderItemByIdAsync(Guid id)
        {
            return await _context.OrderItems.FindAsync(id);
        }

        public async Task UpdateOrderItemAsync(OrderItem orderItem)
        {
            var result = _context.OrderItems.Find(orderItem.Id);
            if (result != null)
            {
                _context.OrderItems.Update(orderItem);
                await _context.SaveChangesAsync();
            }
        }
    }
}
