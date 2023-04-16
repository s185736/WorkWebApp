using System.Net.Sockets;
using WorkWebApp.data;

namespace WorkWebApp;

public static class DataSeeder
{
    public static void Seed(this IHost host)
    {
        using var scope = host.Services.CreateScope();
        using var context = scope.ServiceProvider.GetRequiredService<UserDataContext>();
        context.Database.EnsureCreated();
    }

    public static void AddEmployees(EmployeeDataContext context)
    {
        var employee = context.Employees.FirstOrDefault();
        //if statement stopper tilføjelse af data hvis der allerede er noget
        if (employee != null) return;

        context.Employees.Add(new Employee
        {
            Name = "Sammy1"
        });
        context.Employees.Add(new Employee
        {
            Name = "Sammy2"
        });
        context.Employees.Add(new Employee
        {  
            Name = "Sammy3"
        });
        context.Employees.Add(new Employee
        {  
            Name = "Sammy4"
        });
        context.SaveChanges();
    }
}