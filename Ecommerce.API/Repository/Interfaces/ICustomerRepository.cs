using Ecommerce.API.Data;
using Ecommerce.API.Entities;
using Ecommerce.API.Repository.Base;

namespace Ecommerce.API.Repository.Interfaces
{
    public interface ICustomerRepository : IRepositoryBase<Customer, ApplicationDbContext>
    {

    }
}
