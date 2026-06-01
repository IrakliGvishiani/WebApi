using Ecommerce.API.Entities;

namespace Ecommerce.API.Repository.Interfaces
{
    public interface IOrderItemRepository
    {

        Task<IEnumerable<OrderItem>> GetAllOrderItemsAsync();

        Task<OrderItem> GetOrderItemByIdAsync(Guid id);

        Task AddOrderItemAsync(OrderItem orderItem);

        Task UpdateOrderItemAsync(OrderItem orderItem);

        Task DeleteOrderItemAsync(Guid id);
    }
}
