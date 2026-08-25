using Microsoft.EntityFrameworkCore;

namespace dotnet.Data;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}