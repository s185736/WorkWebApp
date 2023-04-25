using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkWebApp.data;

namespace WorkWebApp.Pages;

public class MyProfileModel : PageModel
{
    private readonly ILogger<MyProfileModel> _logger;
    public readonly _user viewUser ;

    public MyProfileModel(ILogger<MyProfileModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
    
}
