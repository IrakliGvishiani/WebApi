using Ecommerce.API.Data;
using Ecommerce.API.Entities;
using Ecommerce.API.Repository.Base;
using Ecommerce.API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.API.Repository
{
    public class CustomerRepository : RepositoryBase<Customer, ApplicationDbContext>, ICustomerRepository
    {
       public CustomerRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
