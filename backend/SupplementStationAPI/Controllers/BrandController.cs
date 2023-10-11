using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupplementStationBLL.Interfaces;

namespace SupplementStationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        IBrandService _brandService;
        public BrandController (IBrandService brandService)
        {
            _brandService = brandService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBrands()
        {
            var categoriesList = _brandService.GetAllBrands();
            return Ok(categoriesList);
        }
    }
}
