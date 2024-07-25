using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProgettoSettimanaleBackEndU2W2.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace ProgettoSettimanaleBackEndU2W2.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("api/account/login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim(ClaimTypes.Name, user.Id.ToString())
                        }),
                        Expires = DateTime.UtcNow.AddMinutes(int.Parse(_configuration["Jwt:DurationInMinutes"])),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    return Ok(new
                    {
                        Token = tokenHandler.WriteToken(token),
                        Expiration = token.ValidTo
                    });
                }
                return Unauthorized(new { message = "Invalid credentials" });
            }
            return BadRequest(ModelState);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("api/account/register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim(ClaimTypes.Name, user.Id.ToString())
                        }),
                        Expires = DateTime.UtcNow.AddMinutes(int.Parse(_configuration["Jwt:DurationInMinutes"])),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    return Ok(new
                    {
                        Token = tokenHandler.WriteToken(token),
                        Expiration = token.ValidTo
                    });
                }

                return BadRequest(result.Errors);
            }

            return BadRequest(ModelState);
        }
    }
}
