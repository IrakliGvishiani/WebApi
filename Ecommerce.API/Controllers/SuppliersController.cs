using Ecommerce.API.Entities;
using Ecommerce.API.Exceptions;
using Ecommerce.API.Models.SupplierDtos;
using Ecommerce.API.Repository.Interfaces;
using Ecommerce.API.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
            var response = new CommonResponse(CommonResponseMessage.SuccessMessage, suppliers, true, Convert.ToInt32(HttpStatusCode.OK));
            return StatusCode(response.HttpStatusCode, response);
        }

        [HttpPost]

        public async Task<IActionResult> CreateNewSupplier([FromBody] SupplierForCreatingDto dto)
        {
           var result = await _supplierService.CreateNewSupplierAsync(dto);
            var response = new CommonResponse(CommonResponseMessage.SuccessMessage, result, true, Convert.ToInt32(HttpStatusCode.Created));
            return StatusCode(response.HttpStatusCode, response);
        }

        [HttpPut]

        public async Task<IActionResult> UpdateSupplier([FromBody] SupplierForUpdatingDto dto)
        {

          var result =  await _supplierService.UpdateSupplierAsync(dto);
            var response = new CommonResponse(CommonResponseMessage.SuccessMessage, result, true, Convert.ToInt32(HttpStatusCode.OK));

            return StatusCode(response.HttpStatusCode, response);

        }

        [HttpDelete("{Id}")]

        public async Task<IActionResult> DeleteSupplier([FromRoute] Guid Id)
        {
           var result = await _supplierService.DeleteSupplierAsync(Id);
            var response = new CommonResponse(CommonResponseMessage.SuccessMessage, result, true, Convert.ToInt32(HttpStatusCode.NoContent));
            return StatusCode(response.HttpStatusCode, response);
        }
    }
}
