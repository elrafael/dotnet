namespace dotnet.Controllers;
using dotnet.Services;
using dotnet.DTOs;
using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        var token = await _authService.LoginAsync(dto);
        
        if (token == null)
            return Unauthorized("E-mail ou password incorretos.");

        return Ok(new { Token = token });
    }
}