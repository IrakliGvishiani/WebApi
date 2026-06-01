using Ecommerce.API.Data;
using Ecommerce.API.Entities;
using Ecommerce.API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.API.Repository
{
    public class SupplierRepository : ISupplierRepository
    {

        private readonly ApplicationDbContext _context;

        public SupplierRepository(ApplicationDbContext context)
        {
            _context = context;
        }



        public async Task AddSupplierAsync(Supplier supplier)
        {
            await _context.Suppliers.AddAsync(supplier);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSupplierAsync(Guid id)
        {
           var supplier = await _context.Suppliers.FindAsync(id);
             if (supplier != null)
             {
                 _context.Suppliers.Remove(supplier);
                 await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Supplier>> GetAllSupplierAsync()
        {
            return await _context.Suppliers.ToListAsync();
        }

        public async Task<Supplier> GetSupplierByIdAsync(Guid id)
        {
            return await _context.Suppliers.FindAsync(id);
        }

        public async Task UpdateSupplierAsync(Supplier supplier)
        {
           var existingSupplier = _context.Suppliers.Find(supplier.Id);
            if (existingSupplier != null)
            {
                _context.Suppliers.Update(supplier);
                await _context.SaveChangesAsync();
            }
        }
    }
}
