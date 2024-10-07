using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Model;
using WebApplication3.Services.Abstract;


namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] Register registerDto)
        {
            var result = _userService.Register(registerDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Login loginDto)
        {
            var result = _userService.Login(loginDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return Unauthorized(result);
        }

    }
}
