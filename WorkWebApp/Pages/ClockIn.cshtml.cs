using Microsoft.AspNetCore.Mvc;
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
}