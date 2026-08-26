namespace dotnet.Services;
using dotnet.DTOs;
public interface IAuthService
{
    Task<string?> LoginAsync(LoginDto dto);
}