using Ecommerce.API.Models.SupplierDtos;
using Ecommerce.API.Repository.Interfaces;
using Ecommerce.API.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/suppliers")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierService _supplierService;


        public SuppliersController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet]

        public async Task<IActionResult> GetAllSuppliers()
        {
            var suppliers = await _supplierService.GetAllSupplierAsync();

            return Ok(suppliers);
        }

        [HttpPost]

        public async Task<IActionResult> CreateNewSupplier([FromBody] SupplierForCreatingDto dto)
        {
            await _supplierService.CreateNewSupplierAsync(dto);

            return Created();
        }

        [HttpPut]

        public async Task<IActionResult> UpdateSupplier([FromBody] SupplierForUpdatingDto dto)
        {

          var result =  await _supplierService.UpdateSupplierAsync(dto);
            if (result == 0)
            {
                return NotFound();
            }

            return Ok("Updated Succesfully");

        }

        [HttpDelete("{Id}")]

        public async Task<IActionResult> DeleteSupplier([FromRoute] Guid Id)
        {
           var result = await _supplierService.DeleteSupplierAsync(Id);
            if(result == 0)
                return NotFound();

            return Ok("Deleted Successfully!");
        }
    }
}
