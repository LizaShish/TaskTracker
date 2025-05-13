using Microsoft.EntityFrameworkCore;

namespace TaskTracker.Data;

public class AppDbContext : DbContext
{
    public DbSet<Task> Tasks { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
}