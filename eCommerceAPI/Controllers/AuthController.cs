using eCommerce.Core.DTO;
using eCommerce.Core.UserContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceAPI.Controllers
{
    [Route("api/[controller]")] //api/auth
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsersService _usersService;
        public AuthController(IUsersService usersService)
        {
            _usersService = usersService;
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            if (registerRequest == null)
            {
                return BadRequest("Invalid registration data");
            }
            AuthencationResponse?authencationResponse=await _usersService.Register(registerRequest);
            if (authencationResponse == null || authencationResponse.Sucess == false)
            {
                return BadRequest(authencationResponse);
            }
            return Ok(authencationResponse);

        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult?> Login(LoginRequest loginRequest)
        {
            if (loginRequest == null)
            {
                return BadRequest("Invalid login Data");
            }
            AuthencationResponse?authencationResponse=await _usersService.Login(loginRequest);
            if (authencationResponse == null || authencationResponse.Sucess == false)
            {
                return Unauthorized(authencationResponse);
            }
            return Ok(authencationResponse);
        }
    }
}
