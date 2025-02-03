using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;
using WebApplication1.Services.Impl;
using WebApplication1.Dtos;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly JwtService _jwtService;

        public LoginController(ILoginService loginService, JwtService jwtService)
        {
            _loginService = loginService;
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO request)
        {
            var user = await _loginService.ValidateUserAsync(request.Username, request.Password);
            if (user == null)
                return Unauthorized();

            var token = _jwtService.GenerateToken(user);
            return Ok(new { token });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO request)
        {
            try
            {
                var user = await _loginService.RegisterUserAsync(request.Username, request.Password, request.Email);
                return Ok(user);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
