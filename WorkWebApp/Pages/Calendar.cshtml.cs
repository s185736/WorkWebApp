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
    
    public IList<_user> Users { get;set; }
    public IList<_shift> Shifts { get;set; }

    public void OnGet()
    {
        Users = _context._user.ToList();
        Shifts = _context._shift.ToList();
    }
    

}