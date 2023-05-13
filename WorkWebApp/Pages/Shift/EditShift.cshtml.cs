using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WorkWebApp.data;
using WorkWebApp.ViewModels;

namespace WorkWebApp.Pages.Shift;

public class EditShift : PageModel
{
    private readonly UserDataContext _context;
    public EditShift(UserDataContext context)
    {
        _context = context;
    }
    
    [BindProperty]
    public ShiftViewModel? ShiftViewModel { get; set; }

    
    public async Task<IActionResult> OnGetAsync(int id)
    {
        ShiftViewModel = await _context._shift
            .Where(_ => _.record_id == id)
            .Select(_ =>
                new ShiftViewModel
                {
                    userid = _.userid,
                    start_time = _.start_time,
                    end_time = _.end_time
                }).FirstOrDefaultAsync();
 
        if (ShiftViewModel == null)
        {
            return NotFound();
        }
        return Page();
    }
    
    public async Task<IActionResult> OnPostAsync(int id)
    {
        var shiftToUpdate = await _context._shift.FindAsync(id);
 
        if (shiftToUpdate == null)
        {
            return NotFound();
        }
 
        if (await TryUpdateModelAsync<_shift>(
                shiftToUpdate,
                "ShiftViewModel", 
                c => c.userid, c => c.start_time, c => c.end_time
            ))
        {
            await _context.SaveChangesAsync();
            return Redirect("/");
        }
 
        return Page();
    }
}