using Ecommerce.API.Data;
using Ecommerce.API.Entities;
using Ecommerce.API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.API.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task AddOrderAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
        }

        public async Task DeleteOrderAsync(Guid id)
        {
          var result =  await _context.Orders.FindAsync(id);

            if (result != null)
            {
                _context.Orders.Remove(result);
                await _context.SaveChangesAsync();
            }
               
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order> GetOrderByIdAsync(Guid id)
        {
           return await _context.Orders.FindAsync(id); 
        }

        public async Task UpdateOrderAsync(Order order)
        {
            var result = _context.Orders.Find(order.Id);
            if(result != null)
            {
                _context.Update(result);
                await _context.SaveChangesAsync();
            }
        }
    }
}
