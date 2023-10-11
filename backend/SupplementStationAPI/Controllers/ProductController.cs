using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupplementStationBLL.Interfaces;
using SupplementStationBLL.DTO;
using SupplementStationBLL.Services;

namespace SupplementStationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery]FiltersDto filters)
        {
            var productList = _productService.GetAll(filters);
            return Ok(productList);
        }
        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            
            return Ok(_productService.GetByID(id));
        }
        [HttpPost]
        public IActionResult AddProduct([FromBody]NewProduct product)
        {
            _productService.AddProduct(product);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteById(int id)
        {
            _productService.DeleteById(id);
            return Ok();
        }
    }
}
