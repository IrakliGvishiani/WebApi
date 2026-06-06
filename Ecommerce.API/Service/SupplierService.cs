using Ecommerce.API.Entities;
using Ecommerce.API.Models.SupplierDtos;
using Ecommerce.API.Repository.Interfaces;
using Ecommerce.API.Service.Interfaces;
using MapsterMapper;

namespace Ecommerce.API.Service
{
    public class SupplierService(ISupplierRepository supplierRepository, IMapper mapper) : ISupplierService
    {
        public async Task<int> CreateNewSupplierAsync(SupplierForCreatingDto model)
        {
            var newSupplier = mapper.Map<Supplier>(model);
            await supplierRepository.AddAsync(newSupplier);
            return await supplierRepository.SaveAsync();
        }

        public async Task<IEnumerable<SupplierForGettingDto>> GetAllSupplierAsync()
        {
            var suppliers = (await supplierRepository.GetAllAsync()).Items;

            // MAPPER  DIDNT WORK
            //var mapped = mapper.Map<IEnumerable<SupplierForGettingDto>>(suppliers);

            //return mapped;
            ////MANUAL MAPPING WORKED
            return suppliers.Select(c => new SupplierForGettingDto()
            {
                Id = c.Id,
                SuplierName = c.SupplierName
            });
        }

        public async Task<int> UpdateSupplierAsync(SupplierForUpdatingDto model)
        {
            var supplier = await supplierRepository.GetAsync(p => p.Id == model.Id);

            if (supplier is null)
                return 0;

            supplier.SupplierName = model.SupplierName;

            return await supplierRepository.SaveAsync();
        }

        public async Task<int> DeleteSupplierAsync(Guid Id)
        {
            var supplier = await supplierRepository.GetAsync(p => p.Id == Id);

            if (supplier is null)
                return 0;

            supplierRepository.Remove(supplier);
           return await supplierRepository.SaveAsync();
        }
    }
}
