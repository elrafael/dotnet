using System.ComponentModel;

namespace dotnet.DTOs;
using System.ComponentModel.DataAnnotations;
public class LoginDto
{
  [Required, EmailAddress, DefaultValue("email@admin")]
  public string Email { get; set; } = null!;
  [Required, DefaultValue("teste123")]
  public string Password { get; set; } = null!;
}