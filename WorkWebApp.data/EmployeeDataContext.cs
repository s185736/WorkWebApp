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
        modelBuilder.UseSerialColumns();
    }
    
    public DbSet<Employee> Employees { get; set; }
    
}