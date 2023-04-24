using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WorkWebApp.Pages;

public class MyProfileModel : PageModel
{
    private readonly ILogger<MyProfileModel> _logger;

    public MyProfileModel(ILogger<MyProfileModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
    
}
