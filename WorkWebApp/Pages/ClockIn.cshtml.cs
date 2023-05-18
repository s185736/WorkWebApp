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
    public ShiftViewModel? ShiftViewModel { get; set; }

    public IActionResult OnGet()
    {
        return Page();  
    }
    
    public async Task<IActionResult> OnPostClockInTime()
    {
        var clockIn = DateTime.Now.ToString("hh:mm:ss");

        if (ShiftViewModel != null)
        {
            var shift = new _shift()
            {
                userid = ShiftViewModel.userid,
                checked_in_time = TimeSpan.Parse(clockIn)
            };
            ViewData["Message"] = "Clocked In Registered: "+shift.checked_in_time+".";
            _context._shift.Add(shift);
            await _context.SaveChangesAsync();

            Console.WriteLine("Clocked In Registered: "+shift.checked_in_time+".");
        }
        return Redirect("/ClockIn");
    }
 
    public async Task<IActionResult> OnPostClockOutTime()
    {
        var clockOut = DateTime.Now.ToString("hh:mm:ss");
        var clockOutDate = DateTime.Now.ToString("F");
        ViewData["Message"] = "Welcome back, you have now clocked out! " +
                              "Date: "+clockOutDate+". " +
                              "Time Clocked in at: "+clockOut+".";

        if (ShiftViewModel != null)
        {
            var shift = new _shift()
            {
                userid = ShiftViewModel.userid,
                checked_out_time = TimeSpan.Parse(clockOut)
            };
            _context._shift.Add(shift);
            await _context.SaveChangesAsync();

            Console.WriteLine("Clocked Out Registered: "+shift.checked_out_time+".");
        }

        return Redirect("/ClockIn");
    }
}