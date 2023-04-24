using System.Linq.Expressions;
using System.Runtime.InteropServices.JavaScript;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkWebApp.data;
using Microsoft.EntityFrameworkCore;

namespace WorkWebApp.Pages;

    public class Calendar : PageModel
    {
        private readonly UserDataContext _context;
        
        public Calendar(UserDataContext context)
        {
            _context = context;
        }
        public List<_user> Users { get; set; }
        public List<_shift> Shifts { get; set; }
        public DateTime CurrentDate { get; set; } = DateTime.Today;

        public void OnGet(DateTime? currentDate)
        {
            if (currentDate.HasValue)
            {
                CurrentDate = currentDate.Value;
            }
            
            Users = _context._user.ToList();
            Shifts = _context._shift.ToList();
        }

        public IActionResult OnGetPreviousSeven()
        {
            CurrentDate = CurrentDate.AddDays(-7);
            return RedirectToPage("/Calendar", new { currentDate = CurrentDate });
        }

        public IActionResult OnGetNextSeven()
        {
            CurrentDate = CurrentDate.AddDays(7);
            return RedirectToPage("/Calendar", new { currentDate = CurrentDate });
        }

        public IActionResult OnGetGoToToday()
        {
            CurrentDate = DateTime.Today;
            return RedirectToPage("/Calendar", new { currentDate = CurrentDate });
        }
    }

