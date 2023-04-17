using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkWebApp.data;
using Microsoft.EntityFrameworkCore;


namespace WorkWebApp.Pages;

public class Calendar : PageModel
{
    private readonly UserDataContext _context;
    

    public Calendar(UserDataContext context)
    {
        _context = context;
    }
    
    public IList<User> Users { get;set; }
    public IList<Shift> Shifts { get;set; }

    public void OnGet()
    {
        Users = _context.users.ToList();
        Shifts = _context.shifts.ToList();
    }
    

}