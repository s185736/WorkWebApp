using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WorkWebApp.data;

namespace WorkWebApp.Pages.Shift;

public class ShiftHandler : PageModel
{
    private readonly UserDataContext _context;
    
    public ShiftHandler(UserDataContext context)
    {
        _context = context;
    }

    public List<_shift> AllShifts = new List<_shift>();

    public async Task<IActionResult> OnGetAsync()
    {
        AllShifts = await _context._shift.ToListAsync();
        return Page();
    }
}