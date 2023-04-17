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
        public string record_id { get; set; }

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
            var fullnSplitame = FullName.Split(" ");
            var firstname = fullnSplitame[0];
            var lastname = fullnSplitame[1];

            var user = new _user()
            {
                firstname = firstname,
                lastname = lastname,
                mail = Email,
                phonenumber = "testerter",
                birthday = default,
                role = "testerter",
                department = "testerter",
                password = Password
            };

            _context._user.Add(user);
            _context.SaveChanges();
            
            Console.WriteLine("Saved");


            return RedirectToPage("/Employees");
        }
    }
}