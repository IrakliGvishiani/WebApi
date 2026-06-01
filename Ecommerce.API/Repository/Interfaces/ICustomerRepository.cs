using Ecommerce.API.Entities;

namespace Ecommerce.API.Repository.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllCustomersAsync();

        Task<Customer> GetCustomerById(Guid id);

        Task AddCustomerAsync(Customer customer);

        Task UpdateCustomerAsync(Customer customer);

        Task DeleteCustomerAsync(Guid id);

    }
}
