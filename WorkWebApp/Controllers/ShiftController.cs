using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkWebApp.data;
using WorkWebApp.Pages.Shared;
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
        
            if(shift == null)
            {
                return NotFound();
            }
        
            var users = await _context._user.ToListAsync();

            var model = new InfoShiftModel(_context)
            {
                Shift = shift,
                Users = users
            };

            return View(model);
        }

        return NotFound();
    }
    
    public IActionResult SwapRequest(int userid, int selectedUser, int record_id)
    {
        var swapRequest = new _shiftswaprequest
        {
            requestinguserid = userid,
            requesteduserid = selectedUser,
            shiftid = record_id,
            status = "Pending"
        };
        Console.WriteLine(swapRequest);

        _context._shiftswaprequest.Add(swapRequest);
        _context.SaveChanges();
        Console.WriteLine("Saved");
        return RedirectToAction("InfoShift", new { record_id = record_id });
    }
    
    
    
    
    
    
}