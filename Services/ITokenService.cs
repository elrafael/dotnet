using dotnet.Models;

namespace dotnet.Services;

public interface ITokenService
{
    string GenerateToken(User user);
}