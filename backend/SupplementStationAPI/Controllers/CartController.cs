using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupplementStationBLL.DTO;
using SupplementStationBLL.Interfaces;
using SupplementStationBLL.Services;

namespace SupplementStationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private ICartItemService _cartItemService;
        public CartController(ICartItemService cartItemService)
        {
            _cartItemService = cartItemService;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<CartItemDto>>> GetAll(int id)
        {
            var productList = _cartItemService.GetCartItems(id);
            return Ok(productList);
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] CartItemDto cartItem)
        {
            _cartItemService.AddCartItem(cartItem);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCartItem(int id, int quantity)
        {
            _cartItemService.UpdateCartItem(id, quantity);
            return Ok();
        }
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteCartItem(int id)
        {
            _cartItemService.DeleteCartItem(id);
            return Ok();
        }
    }
}
