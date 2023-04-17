using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkWebApp.data;

public class EmployeesModel : PageModel
{
    private readonly UserDataContext _context;

    public EmployeesModel(UserDataContext context)
    {
        _context = context;
    }

    public IList<_user> Users { get;set; }

    public void OnGet()
    {
        Users = _context._user.ToList();
    }
}