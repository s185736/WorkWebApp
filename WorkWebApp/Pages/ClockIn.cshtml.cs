using System.Globalization;
using Microsoft.AspNetCore.Mvc;
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
        var clockIn = DateTime.Now;
        var clockInDate = DateTime.Now.ToString("MM/dd/yyyy");
        var clockInTime = DateTime.Now.ToString("HH:m:s");
        ViewData["Message"] = "Welcome back, you have now clocked in! " +
                              "Date: "+clockInDate+". " +
                              "Time Clocked in at: "+clockInTime+".";

        var shift = new Shift()
        {
            start_time = Convert.ToDateTime(clockIn)
        };
        
        _context.shifts.Add(shift);
            
        Console.WriteLine("Clocked In (Start Time) Registered: "+clockIn+".");
    }
 
    public void OnPostClockOutTime()
    {
        var clockOut = DateTime.Now;
        var clockOutDate = DateTime.Now.ToString("MM/dd/yyyy");
        var clockOutTime = DateTime.Now.ToString("HH:m:s");
        ViewData["Message"] = "Goodbye, you have now clocked out! " +
                              "Date: "+clockOutDate+". " +
                              "Time Clocked out at: "+clockOutTime+".";
        
        var shift = new Shift()
        {
            end_time = Convert.ToDateTime(clockOut)
        };

        _context.shifts.Add(shift);
            
        Console.WriteLine("Clocked Out (End Time) Registered: "+clockOut+".");
    }
}