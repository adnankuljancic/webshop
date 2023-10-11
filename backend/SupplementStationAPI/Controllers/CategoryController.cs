using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupplementStationBLL.DTO;
using SupplementStationBLL.Interfaces;

namespace SupplementStationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;

        }
        [HttpGet]
        public async Task<ActionResult<CategoryDto>> GetAllCategories()
        {
            try 
            {
                return Ok(await _categoryService.GetAllCategories());
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
