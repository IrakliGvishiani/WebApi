using Ecommerce.API.Entities;

namespace Ecommerce.API.Repository.Interfaces
{
    public interface IOrderRepository
    {

        Task<IEnumerable<Order>> GetAllOrdersAsync();

        Task<Order> GetOrderByIdAsync(Guid id);

        Task AddOrderAsync(Order order);
        Task UpdateOrderAsync(Order order);
        Task DeleteOrderAsync(Guid id);
    }
}
