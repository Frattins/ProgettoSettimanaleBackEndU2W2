using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ProgettoSettimanaleBackEndU2W2.Models;
using ProgettoSettimanaleBackEndU2W2.Services;

namespace ProgettoSettimanaleBackEndU2W2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Client model)
        {
            var result = await _authService.LoginAsync(model.Email, model.Password);
            if (result)
            {
                return Ok(new { message = "Login successful" });
            }
            return Unauthorized(new { message = "Invalid credentials" });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Client model)
        {
            if (model.Password != model.ConfirmPassword)
            {
                return BadRequest(new { message = "Passwords do not match" });
            }

            var result = await _authService.RegisterAsync(model);
            if (result)
            {
                return Ok(new { message = "Registration successful" });
            }
            return BadRequest(new { message = "Registration failed" });
        }
    }
}
