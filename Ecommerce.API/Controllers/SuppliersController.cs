using Ecommerce.API.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/suppliers")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierRepository _supplierRepository;


        public SuppliersController(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }
         
        [HttpGet]
        public async Task<IActionResult> GetAllSuppliers()
        {
            var suppliers = await _supplierRepository.GetAllSupplierAsync();
            if (suppliers == null || !suppliers.Any())
            {
                return NotFound("Suppliers are empty!");
            }
            return Ok(suppliers);
        }

        [HttpGet("single/{Id}")]

        public async Task<IActionResult> GetSupplierById(Guid Id)
        {
             var supplier = await _supplierRepository.GetSupplierByIdAsync(Id);
            if (supplier == null)
            {
                return NotFound("Supplier not found!");
            }
            return Ok(supplier);

        }

    }
}
