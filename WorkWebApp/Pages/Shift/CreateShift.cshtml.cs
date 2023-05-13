using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkWebApp.data;
using WorkWebApp.ViewModels;

namespace WorkWebApp.Pages.Shift;

public class CreateShift : PageModel
{
    private readonly UserDataContext _context;
    public CreateShift(UserDataContext context)
    {
        _context = context;
    }
    
    [BindProperty]
    public ShiftViewModel ShiftViewModel { get; set; }

    public IActionResult OnGet()
    {
        return Page();  
    }
    
    public async Task<IActionResult> OnPostAsync()
    {
        var entry = _context.Add(new _shift());
        entry.CurrentValues.SetValues(ShiftViewModel);
        await _context.SaveChangesAsync();
        return Redirect("/schedule");
    }
    /*
    <form method="post">
        <div class="form-group">
    <label for="startTime">Start time:</label>
    <input type="time" class="form-control" id="startTime" name="StartTime" required>
        </div>
    <div class="form-group">
    <label for="endTime">End time:</label>
    <input type="time" class="form-control" id="endTime" name="EndTime" required>
        </div>
    <div class="form-group">
    <label for="breakDuration">Break duration:</label>
    <input type="time" class="form-control" id="breakDuration" name="BreakDuration" required>
        </div>
    <button type="submit" class="btn btn-primary">Create Shift</button>
    </form>
    
    
    public string record_id { get; set; }
    
    [BindProperty]
    public int Userid { get; set; }
    
    [BindProperty]
    //[noget med tid]
    public TimeSpan StartTime { get; set; }
    
    [BindProperty]
    //[noget med tid]
    public TimeSpan EndTime { get; set; }
    
    [BindProperty]
    //[Timestamp]
    public TimeSpan CheckedInTime { get; set; }
    
    [BindProperty]
    //[Timestamp]
    public TimeSpan CheckedOutTime { get; set; }
    
    [BindProperty]
    public TimeSpan BreakDuration { get; set; }
    
    [BindProperty]
    //[Noget med dato]
    public DateTime DateOfShift { get; set; }

    

    //Bruges til at poste til databasen
    public IActionResult OnPost()
    {
        var shift = new _shift()
        {
            userid = 1,
            start_time = StartTime,
            end_time = EndTime,
            //skal ændres til deres rigtige, er sat til det samme for at teste
            checked_in_time = StartTime,
            checked_out_time = EndTime,
            //
            break_duration = new TimeSpan(0, 30, 0) ,
            dateofshift = new DateTime(2023,04,20)
            
        };
        _context._shift.Add(shift);
        _context.SaveChanges();
        
        Console.WriteLine("Saved shift");

        return RedirectToPage("/Schedule");
    }
    */
}