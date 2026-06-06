using Ecommerce.API.Entities;
using Ecommerce.API.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IGeneralRepository<Customer> _customerRepository;

        public CustomersController(IGeneralRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]

        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _customerRepository.GetAllAsync(1,10,tracking: false);
            if (customers == null || !customers.Any())
            {
                return NotFound("Customers are empty!");
            }
            return Ok(customers);
        }

        [HttpGet("single/{Id}")]

        public async Task<IActionResult> GetCustomerById(Guid Id)
        {
            var customer = await _customerRepository.GetByIdAsync(Id);
            if (customer == null)
            {
                return NotFound($"Customer with Id: {Id} not found!");
            }
            return Ok(customer);
        }
    }
}
