using Microsoft.EntityFrameworkCore;

using TheMessenger.Entity.Data;


namespace TheMessenger.Api.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options) {
  public virtual DbSet<User> Users => Set<User>();
}