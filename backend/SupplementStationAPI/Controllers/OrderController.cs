using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupplementStationBLL.DTO;
using SupplementStationBLL.Interfaces;

namespace SupplementStationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder(OrderDto order) {
            _orderService.AddOrder(order);
            return Ok();
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetAllOrders(int id)
        {
            return Ok(_orderService.GetAllOrders(id));
        }
    }
}
