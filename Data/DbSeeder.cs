using dotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet.Data;

public static class DbSeeder
{
  public static async Task SeedAdminUser(IServiceProvider serviceProvider, IConfiguration configuration)
  {
    using var scope = serviceProvider.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    var adminEmail = configuration["AdminUser:Email"];
    var adminPassword = configuration["AdminUser:Password"];

    if (string.IsNullOrEmpty(adminEmail) || string.IsNullOrEmpty(adminPassword))
    {
      return;
    }

    if (!await context.Users.AnyAsync(u => u.Email == adminEmail))
    {
      var adminUser = new User
      {
        Name = "Admin",
        Email = adminEmail,
        Password = BCrypt.Net.BCrypt.HashPassword(adminPassword),
        CreatedAt = DateTime.UtcNow
      };

      context.Users.Add(adminUser);
      await context.SaveChangesAsync();
    }
  }
}