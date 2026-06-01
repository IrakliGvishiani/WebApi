using Ecommerce.API.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/orderitems")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly IOrderItemRepository _orderItemRepository;

        public OrderItemsController(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }


         [HttpGet]

         public async Task<IActionResult> GetAllOrderItems()
         {
             var orderItems = await _orderItemRepository.GetAllOrderItemsAsync();
             if (orderItems == null || !orderItems.Any())
             {
                 return NotFound("Order items are empty!");
             }
             return Ok(orderItems);
        }

        [HttpGet("single/{Id}")]

        public async Task<IActionResult> GetOrderItemById(Guid Id)
        {
            var orderItem = await _orderItemRepository.GetOrderItemByIdAsync(Id);
            if (orderItem == null)
            {
                return NotFound("Order item not found!");
            }
            return Ok(orderItem);
        }
    }
}
