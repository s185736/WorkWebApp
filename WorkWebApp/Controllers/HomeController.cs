using Microsoft.AspNetCore.Mvc;
using WorkWebApp.data;

namespace WorkWebApp.Controllers;

//https://www.youtube.com/watch?v=yGwGLcqcJ6Q til opsætning af databasen.

public class HomeController : Controller
{
    private readonly EmployeeDataContext context;
    
    public HomeController(EmployeeDataContext context)
    {
        this.context = context;
    }

    /*
    public IActionResult Index()
    {
        var employees = this.context.Employees.Include("").ToList();
        return  View(employees)
    }
    */


}