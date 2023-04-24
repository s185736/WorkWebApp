using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace WorkWebApp.Pages
{
    public class ChangePassword : PageModel
    {
        private readonly UserDataContext _context;

        public ChangePassword(UserDataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string NewPassword { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _context._user.SingleOrDefaultAsync(u => u.mail == Email);

            if (user != null)
            {
                user.password = NewPassword;
                _context._user.Update(user);
                await _context.SaveChangesAsync();
                return RedirectToPage("/Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "User not found");
            }

            return Page();
        }

        public void OnGet()
        {

        }
    }
}