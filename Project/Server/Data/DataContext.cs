using Microsoft.EntityFrameworkCore;
using Server.Entities.Models;

namespace Server.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<AppUser> AppUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<AppUser>().HasData(
            new AppUser { Id = 1, UserName = "john_doe" },
            new AppUser { Id = 2, UserName = "jane_smith" },
            new AppUser { Id = 3, UserName = "michael_brown" },
            new AppUser { Id = 4, UserName = "emily_jones" },
            new AppUser { Id = 5, UserName = "david_wilson" },
            new AppUser { Id = 6, UserName = "sarah_davis" },
            new AppUser { Id = 7, UserName = "chris_miller" },
            new AppUser { Id = 8, UserName = "laura_garcia" },
            new AppUser { Id = 9, UserName = "daniel_lee" },
            new AppUser { Id = 10, UserName = "olivia_martin" }
        );
    }
}
