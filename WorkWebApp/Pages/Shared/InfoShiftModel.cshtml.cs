using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WorkWebApp.data;
using WorkWebApp.ViewModels;

namespace WorkWebApp.Pages.Shared;

public class InfoShiftModel : PageModel
{
    private readonly UserDataContext _context;

    public InfoShiftModel(UserDataContext context)
    {
        _context = context;
    }

    [BindProperty] public _shift Shift { get; set; }

    // Add a property for the list of users
    public IList<_user> Users { get; set; }

    [BindProperty] public int SelectedUser { get; set; } // to keep the selected user from the dropdown

    public bool IsNotFound { get; set; } // To keep the NotFound state

    public async Task OnGetAsync(int? id)
    {
        if (id == null)
        {
            IsNotFound = true;
            return;
        }

        Shift = await _context._shift.FirstOrDefaultAsync(m => m.record_id == id);

        if (Shift == null)
        {
            IsNotFound = true;
            return;
        }

        // Query the list of users
        Users = await _context._user.ToListAsync();
    }

  
}
