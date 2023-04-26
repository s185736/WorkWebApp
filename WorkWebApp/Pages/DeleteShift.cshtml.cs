using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WorkWebApp.data;

namespace WorkWebApp.Pages;

public class DeleteShift : PageModel
{
    private readonly UserDataContext _context;
    
    [BindProperty]
    public int RecordId { get; set; }
    

    public DeleteShift(UserDataContext context)
    {
        _context = context;
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult OnDelete()
    {
        var id = 16;
        var deleteShift = _context._shift.Find(RecordId);
        
        if (deleteShift == null)
        {
            // giver fejl hvis det ikke er fundet i db 
            return NotFound();
        }
        // Sletter rækken fra databasen
        _context._shift.Remove(deleteShift);
        _context.SaveChanges();
        return RedirectToPage("/CreateShift");
    }
    
    
    /*
    _context._shift.Remove(temp);
    _context.SaveChanges();
    return RedirectToPage("/CreateShift");
    */

}