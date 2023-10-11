using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupplementStationBLL.Services;
using SupplementStationBLL.Interfaces;
using SupplementStationBLL.DTO;

namespace SupplementStationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthController : ControllerBase
    {
        private IAuthService _authService;
        private IConfiguration _configuration;
        public AuthController(IAuthService authService, IConfiguration configuration)
        {
            _authService = authService;
            _configuration = configuration;
            
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(NewUser request)
        {
            _authService.Register(request);
            return Ok();
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(User request)
        {
            JwtUser jwtUser = _authService.Login(request, _configuration.GetSection("AppSettings:Token").Value);
            if (jwtUser.jwt==string.Empty) 
            { return BadRequest("User not found"); } else { return Ok(jwtUser); }
            
        }
           


    }
}
