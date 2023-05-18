using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace WorkWebApp.data;

public class EmployeeDataContext : DbContext
{
    public EmployeeDataContext(DbContextOptions<EmployeeDataContext> options) :
        base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.UseSerialColumns();
        modelBuilder.Entity<_shift>().HasKey(s => s.record_id);
        modelBuilder.Entity<_user>().HasKey(s => s.record_id);
        modelBuilder.Entity<_shiftswaprequest>().HasKey(s => s.record_id);

        // Configure Identity tables
        modelBuilder.Entity<IdentityUser>(b =>
        {
            b.ToTable("AspNetUsers"); // Update the table name as needed
        });

        modelBuilder.Entity<IdentityRole>(b =>
        {
            b.ToTable("AspNetRoles"); // Update the table name as needed
        });

        modelBuilder.Entity<IdentityUserRole<string>>(b =>
        {
            b.ToTable("AspNetUserRoles"); // Update the table name as needed
        });

        modelBuilder.Entity<IdentityUserClaim<string>>(b =>
        {
            b.ToTable("AspNetUserClaims"); // Update the table name as needed
        });

        modelBuilder.Entity<IdentityUserLogin<string>>(b =>
        {
            b.HasNoKey(); // Configure the IdentityUserLogin entity as keyless
            b.ToTable("AspNetUserLogins"); // Update the table name as needed
        });

        modelBuilder.Entity<IdentityUserToken<string>>(b =>
        {
            b.ToTable("AspNetUserTokens"); // Update the table name as needed
        });
    }

    
    public DbSet<Employee> Employees { get; set; }
    
}