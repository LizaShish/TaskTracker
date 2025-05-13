using Core.Entities;
using Microsoft.EntityFrameworkCore;


namespace infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<TaskEntity> Tasks { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaskEntity>().ToTable("Tasks");
    }
}