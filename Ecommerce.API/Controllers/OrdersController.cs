using Ecommerce.API.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
         [HttpGet]

         public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _orderRepository.GetAllOrdersAsync();

            if (orders == null || !orders.Any())
            {
                return NotFound("Orders are empty!");
            }
            return Ok(orders);
        }

        [HttpGet("single/{id}")]
        public async Task<IActionResult> GetOrderById(Guid Id)
        {
            var order = await _orderRepository.GetOrderByIdAsync(Id);
            if (order == null)
            {
                return NotFound("Order not found!");
            }
            return Ok(order);
        }
    }
}
