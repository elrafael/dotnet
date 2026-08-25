using dotnet.Data;
using dotnet.DTOs.user;
using dotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet.Services;

public class UserService : IUserService
{
    private readonly AppDbContext _context;

    public UserService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<UserResponseDto>> GetAllAsync()
    {
        return await _context.Users
            .Select(u => new UserResponseDto
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
                CreatedAt = u.CreatedAt
            })
            .ToListAsync();
    }

    public async Task<UserResponseDto?> GetByIdAsync(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null) return null;

        return new UserResponseDto
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            CreatedAt = user.CreatedAt
        };
    }

    public async Task<UserResponseDto?> CreateAsync(CreateUserDto dto)
    {
        if (await _context.Users.AnyAsync(u => u.Email == dto.Email))
            return null; // Trata e-mail duplicado

        var user = new User
        {
            Name = dto.Name,
            Email = dto.Email,
            Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
            CreatedAt = DateTime.UtcNow
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return new UserResponseDto
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            CreatedAt = user.CreatedAt
        };
    }

    public async Task<bool> UpdateAsync(int id, UpdateUserDto dto)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null) return false;

        user.Name = dto.Name;
        user.Email = dto.Email;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null) return false;

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return true;
    }
}