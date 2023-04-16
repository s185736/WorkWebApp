using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Query;
using WorkWebApp.data;
using WorkWebApp.ViewModels;

namespace WorkWebApp.Pages
{
    public class CreateProfileModel : PageModel
    {
        private readonly UserDataContext _context;
        
        [BindProperty]
        public string Id { get; set; }

        [BindProperty]
        public string FullName { get; set; }

        [BindProperty]
        [EmailAddress]
        public string Email { get; set; }

        [BindProperty]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public CreateProfileModel(UserDataContext context)
        {
            _context = context;
        }

        public IActionResult OnPost()
        {

            var user = new User()
            {
                Id = FullName.Length,
                FullName = FullName,
                Email = Email,
                Password = Password
            };

            _context.users.Add(user);
            _context.SaveChanges();
            
            Console.WriteLine("Saved");


            return RedirectToPage("/Employees");
        }
    }
}