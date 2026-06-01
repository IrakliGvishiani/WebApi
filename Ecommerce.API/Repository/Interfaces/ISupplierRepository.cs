using Ecommerce.API.Entities;

namespace Ecommerce.API.Repository.Interfaces
{
    public interface ISupplierRepository
    {
        Task<IEnumerable<Supplier>> GetAllSupplierAsync();
        Task<Supplier> GetSupplierByIdAsync(Guid id);

        Task AddSupplierAsync(Supplier supplier);
        Task UpdateSupplierAsync(Supplier supplier);

        Task DeleteSupplierAsync(Guid id);
    }
}
