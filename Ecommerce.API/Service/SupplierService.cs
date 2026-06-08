using Ecommerce.API.Entities;
using Ecommerce.API.Exceptions;
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
            if (model is null) throw new BadRequestException("Request model required!");

            if (model.SupplierName.Length > 100) throw new BadRequestException("Product Name Length Can't Exceed 100!");

            var newSupplier = mapper.Map<Supplier>(model);
            await supplierRepository.AddAsync(newSupplier);
            return await supplierRepository.SaveAsync();
        }

        public async Task<IEnumerable<SupplierForGettingDto>> GetAllSupplierAsync()
        {
            var suppliers = (await supplierRepository.GetAllAsync()).Items;

            
            var mapped = mapper.Map<IEnumerable<SupplierForGettingDto>>(suppliers);

            return mapped;
            ////MANUAL MAPPING
            //return suppliers.Select(c => new SupplierForGettingDto()
            //{
            //    Id = c.Id,
            //    SuplierName = c.SupplierName
            //});
        }

        public async Task<int> UpdateSupplierAsync(SupplierForUpdatingDto model)
        {
            if (model is null) throw new BadRequestException("Request Model Required");

            if (model.Id == Guid.Empty) throw new BadRequestException("Supplier Id Required!");

            var supplier = await supplierRepository.GetAsync(p => p.Id == model.Id);

            if (supplier is null)
                throw new NotFoundException($"Supplier With Id {model.Id} Not Found!");

            supplier.SupplierName = model.SupplierName;

            return await supplierRepository.SaveAsync();
        }

        public async Task<int> DeleteSupplierAsync(Guid Id)
        {
            if (Id == Guid.Empty) throw new BadRequestException("Supplier Id Required");
            var supplier = await supplierRepository.GetAsync(p => p.Id == Id);

            if (supplier is null)
                throw new NotFoundException($"Supplier With Id {Id} Not Found!");

            supplierRepository.Remove(supplier);
           return await supplierRepository.SaveAsync();
        }
    }
}
