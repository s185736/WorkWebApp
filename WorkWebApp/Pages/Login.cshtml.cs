using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WorkWebApp.data;


namespace WorkWebApp.Pages;

public class Login : PageModel
{
    private readonly UserDataContext _context;

    public Login(UserDataContext context)
    {
        _context = context;
    }
    
    [BindProperty]
    public string Email { get; set; }

    [BindProperty]
    public string Password { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var user = await _context._user.SingleOrDefaultAsync(u => u.mail == Email && u.password == Password);

        if (user != null)
        {
            return RedirectToPage("/Index");
        }
        else
        {
            ModelState.AddModelError(string.Empty, "Invalid email or password");
        }

        return Page();
    }
    
    public void OnGet()
    {
        
    }
}
