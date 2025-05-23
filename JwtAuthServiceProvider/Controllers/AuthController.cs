using Microsoft.AspNetCore.Mvc;
using JwtAuthServiceProvider.Models;
using JwtAuthService.Services;

namespace JwtAuthServiceProvider.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly TokenService _tokenService;

    public AuthController(TokenService tokenService)
    {
        _tokenService = tokenService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] UserLoginDto dto)
    {
        if (dto.Username == "admin" && dto.Password == "admin123")
        {
            var token = _tokenService.GenerateToken("1", "Admin");
            return Ok(new { token });
        }

        return Unauthorized("Felaktiga inloggningsuppgifter");
    }
}
