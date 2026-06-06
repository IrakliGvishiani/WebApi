using Ecommerce.API.Data;
using Ecommerce.API.Entities;
using Ecommerce.API.Repository.Base;

namespace Ecommerce.API.Repository.Interfaces
{
    public interface ISupplierRepository : IRepositoryBase<Supplier, ApplicationDbContext>
    {
    }
}
