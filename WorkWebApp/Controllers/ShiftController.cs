using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkWebApp.data;
using WorkWebApp.ViewModels;

namespace WorkWebApp.Controllers;


public class ShiftController : Controller
{
    
    private readonly UserDataContext _context;

    public ShiftController(UserDataContext context)
    {
        _context = context;
    }
    
    [BindProperty]
    public ShiftViewModel? ShiftViewModel { get; set; }
    
    /*
    public async Task<IActionResult> Shifts()
    {
        var shifts = await _context._shift.ToListAsync().ConfigureAwait(false);
        return View(shifts);
    }
    */
    public async Task<IActionResult> InfoShift(int? record_id)
    {
        if (record_id != null)
        {
            var shift = await _context._shift.FirstOrDefaultAsync(m => m.record_id == record_id).ConfigureAwait(false);
            return shift == null ? NotFound() : View(shift);
        }

        return NotFound();
    }
    
    
    
    
    
    
}