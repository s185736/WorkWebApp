using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WorkWebApp.Pages;

public class ClockInModel : PageModel
{
    private readonly ILogger<ScheduleModel> _logger;

    public ClockInModel(ILogger<ScheduleModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
 
    }
 
    public void OnPostClockInTime()
    {
        var clockInTime = DateTime.Now;
        ViewData["Message"] = "Welcome back, you have now clocked in! Time Clocked in: "+clockInTime+".";
    }
 
    public void OnPostClockOutTime()
    {
        var clockInTime = DateTime.Now;
        ViewData["Message"] = "Goodbye, you have now clocked out! Time Clocked Out: "+clockInTime+".";
    }
}