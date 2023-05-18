using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WorkWebApp.data;
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
        modelBuilder.Entity<_shift>()
            .HasKey(s => s.record_id);
        modelBuilder.Entity<_user>()
            .HasKey(s => s.record_id);
        modelBuilder.Entity<_shiftswaprequest>()
            .HasKey(s => s.record_id);
    }
    
    public DbSet<_user> _user { get; set; }
    public DbSet<_shift> _shift { get; set; }
    public DbSet<_shiftswaprequest> _shiftswaprequest { get; set; }
}