using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkWebApp.data;
using WorkWebApp.ViewModels;

namespace WorkWebApp.Pages;

public class ClockInModel : PageModel
{
    private readonly UserDataContext _context;

    public ClockInModel(UserDataContext context)
    {
        _context = context;
    }

    [BindProperty]
    public ShiftViewModel ShiftViewModel { get; set; }

    public IActionResult OnGet()
    {
        return Page();  
    }
    
    public async Task<IActionResult> OnPostClockInTime()
    {
        TimeSpan clockIn = DateTime.Now.TimeOfDay;
        
        var shift = new _shift()
        {
            checked_out_time = clockIn
        };

        var entry = _context.Add(new _shift()); 
        //_context._shift.Add(shift);
        entry.CurrentValues.SetValues(ShiftViewModel);
        await _context.SaveChangesAsync();

        Console.WriteLine("Saved.");
        Console.WriteLine("Clocked In Registered: "+clockIn+".");
        
        return Redirect("/ClockIn");
    }
 
    public async Task<IActionResult> OnPostClockOutTime()
    {
        TimeSpan clockOut = DateTime.Now.TimeOfDay;
        
        var shift = new _shift()
        {
            checked_out_time = clockOut
        };

        var entry = _context.Add(new _shift());
        entry.CurrentValues.SetValues(ShiftViewModel);
        //_context._shift.Add(shift);
        await _context.SaveChangesAsync();

        Console.WriteLine("Saved.");
        Console.WriteLine("Clocked Out Registered: "+clockOut+".");
        
        return Redirect("/ClockIn");
    }
}