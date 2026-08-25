using dotnet.DTOs.user;

namespace dotnet.Services;

public interface IUserService
{
    Task<IEnumerable<UserResponseDto>> GetAllAsync();
    Task<UserResponseDto?> GetByIdAsync(int id);
    Task<UserResponseDto?> CreateAsync(CreateUserDto dto);
    Task<bool> UpdateAsync(int id, UpdateUserDto dto);
    Task<bool> DeleteAsync(int id);
}