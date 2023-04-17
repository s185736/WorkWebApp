using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkWebApp.data;

namespace WorkWebApp.Pages;

public class ClockInModel : PageModel
{
    private readonly ILogger<ScheduleModel> _logger;

    public ClockInModel(ILogger<ScheduleModel> logger, UserDataContext context)
    {
        _logger = logger;
        _context = context;
    }

    private readonly UserDataContext _context;

    public void OnGet()
    {
 
    }
 
    public void OnPostClockInTime()
    {
        TimeSpan clockIn = DateTime.Now.TimeOfDay;
        var clockInDate = DateTime.Now.ToString("MM/dd/yyyy");
        var clockInTime = DateTime.Now.ToString("HH:m:s");
        ViewData["Message"] = "Welcome back, you have now clocked in! " +
                              "Date: "+clockInDate+". " +
                              "Time Clocked in at: "+clockInTime+".";

        var shift = new _shift()
        {
            checked_in_time = clockIn
        };
        
        _context._shift.Add(shift);

        Console.WriteLine("Clocked In (Start Time) Registered: " + clockIn + ".");
    }
 
    public void OnPostClockOutTime()
    {
        TimeSpan clockOut = DateTime.Now.TimeOfDay;
        var clockOutDate = DateTime.Now.ToString("MM/dd/yyyy");
        var clockOutTime = DateTime.Now.ToString("HH:m:s");
        ViewData["Message"] = "Goodbye, you have now clocked out! " +
                              "Date: "+clockOutDate+". " +
                              "Time Clocked out at: "+clockOutTime+".";
        
        var shift = new _shift()
        {
            checked_out_time = clockOut
        };

        _context._shift.Add(shift);
            
        Console.WriteLine("Clocked Out (End Time) Registered: "+clockOut+".");
    }
}