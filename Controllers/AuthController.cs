using Fringes.Models;
using Fringes.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Fringes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IAuthService _authService;

        public AuthController(IConfiguration config, IAuthService authService)
        {
            _config = config;
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel registerViewModel)
        {

            await _authService.RegisterAsync(registerViewModel);
            return Ok(registerViewModel);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel user)
        {
            if (user == null)
            {
                return BadRequest("User object is null");
            }

            var registeredUser = await _authService.GetUserAsync(user.UserName);

            if (registeredUser == null)
            {
                return BadRequest("User not found");
            }


            var mappedUser = new LoginViewModel
            {
                UserName = registeredUser.UserName,

            };

            var token = GenerateJwtToken(mappedUser);
            return Ok(new { token });
        }


        [AllowAnonymous]
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            // Implement user logout logic here
            return Ok("User logged out successfully");
        }

        private string GenerateJwtToken(LoginViewModel user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            // Generate a secure key with the required size (128 bits)
            var key = new byte[32]; // 16 bytes = 128 bits
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(key);
            }

            var claims = new List<Claim>();

            // Add UserName claim if it's not null
            if (!string.IsNullOrEmpty(user.UserName))
            {
                claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            }

            // Add Email claim if it's not null
            if (!string.IsNullOrEmpty(user.Email))
            {
                claims.Add(new Claim(ClaimTypes.Email, user.Email));
            }

            // Add other claims as needed
            claims.Add(new Claim("UserRole", "Admin"));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
