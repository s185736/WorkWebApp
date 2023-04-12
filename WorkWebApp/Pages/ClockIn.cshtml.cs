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
        var clockInDate = DateTime.Now.ToString("MM/dd/yyyy");
        var clockInTime = DateTime.Now.ToString("HH:m:s");
        ViewData["Message"] = "Welcome back, you have now clocked in! " +
                              "Date: "+clockInDate+". " +
                              "Time Clocked in at: "+clockInTime+".";
    }
 
    public void OnPostClockOutTime()
    {
        var clockInDate = DateTime.Now.ToString("MM/dd/yyyy");
        var clockInTime = DateTime.Now.ToString("HH:m:s");
        ViewData["Message"] = "Goodbye, you have now clocked out! " +
                              "Date: "+clockInDate+". " +
                              "Time Clocked out at: "+clockInTime+".";
    }
}