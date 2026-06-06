using Ecommerce.API.Models.SupplierDtos;

namespace Ecommerce.API.Service.Interfaces
{
    public interface ISupplierService
    {
        Task<IEnumerable<SupplierForGettingDto>> GetAllSupplierAsync();

        Task<int> CreateNewSupplierAsync(SupplierForCreatingDto model);

        Task<int> UpdateSupplierAsync(SupplierForUpdatingDto model);

        Task<int> DeleteSupplierAsync(Guid Id);
    }
}
