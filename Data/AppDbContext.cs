using Microsoft.EntityFrameworkCore;

namespace PlatformService;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> dbContext)
        : base(dbContext)
    {
    }

    public DbSet<Platform> Platforms { get; set; }
}
