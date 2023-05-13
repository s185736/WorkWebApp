using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WorkWebApp.data;
using WorkWebApp.ViewModels;

namespace WorkWebApp.Pages.Shift;

public class DeleteShift : PageModel
{
    private readonly UserDataContext _context;
    public DeleteShift(UserDataContext context)
    {
        _context = context;
    }
    
    public string ErrorMessage { get; set; }
    public ShiftViewModel? ShiftViewModel { get; set; }
    public async Task<IActionResult> OnGetAsync(int id, bool? saveChangesError)
    {
        ShiftViewModel = await _context._shift
            .Where(_ => _.record_id == id)
            .Select(_ =>
                new ShiftViewModel
                {
                    userid = _.userid,
                    start_time = _.start_time,
                    end_time = _.end_time
                }).FirstOrDefaultAsync();
 
        if (ShiftViewModel == null)
        {
            return NotFound();
        }
        if (saveChangesError ?? false)
        {
            ErrorMessage = $"Error to delete the record id - {id}";
        }
        return Page();
    }
 
    public async Task<IActionResult> OnPostAsync(int id)
    {
        var recordToDelete = await _context._shift.FindAsync(id);
 
        if (recordToDelete == null)
        {
            return Page();
        }
 
        try
        {
            _context._shift.Remove(recordToDelete);
            await _context.SaveChangesAsync();
            return Redirect("/");
        }
        catch
        {
            return Redirect($"./delete?id={id}&saveChangesError=true");
        }
    }
}