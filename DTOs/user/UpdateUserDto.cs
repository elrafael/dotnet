using System.ComponentModel.DataAnnotations;

namespace dotnet.DTOs.user;

public class UpdateUserDto
{
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;
}