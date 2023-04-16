using Microsoft.EntityFrameworkCore;

namespace WorkWebApp.data;

public class UserDataContext : DbContext
{
    public UserDataContext(DbContextOptions<UserDataContext> options) :
        base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseSerialColumns();
    }
    
    public DbSet<User> users { get; set; }
    public DbSet<Shift> shifts { get; set; }
}