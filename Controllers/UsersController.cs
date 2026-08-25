using dotnet.DTOs.user;
using dotnet.Services;
using Microsoft.AspNetCore.Mvc;

namespace dotnet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserResponseDto>>> GetUsers()
    {
        var users = await _userService.GetAllAsync();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserResponseDto>> GetUser(int id)
    {
        var user = await _userService.GetByIdAsync(id);
        if (user == null) return NotFound("Utilizador não encontrado.");

        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult<UserResponseDto>> CreateUser(CreateUserDto dto)
    {
        var user = await _userService.CreateAsync(dto);
        if (user == null) return BadRequest("Este e-mail já está em uso.");

        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, UpdateUserDto dto)
    {
        var updated = await _userService.UpdateAsync(id, dto);
        if (!updated) return NotFound("Utilizador não encontrado.");

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var deleted = await _userService.DeleteAsync(id);
        if (!deleted) return NotFound("Utilizador não encontrado.");

        return NoContent();
    }
}