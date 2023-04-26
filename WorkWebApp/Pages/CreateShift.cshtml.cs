using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkWebApp.data;

namespace WorkWebApp.Pages;

public class CreateShift : PageModel
{
    private readonly UserDataContext _context;
    
    [BindProperty]
    public string record_id { get; set; }
    
    [BindProperty]
    public int UserID { get; set; }
    
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

    public CreateShift(UserDataContext context)
    {
        _context = context;
    }
    /*
    public IActionResult OnDelete(int id)
    {
        // Delete the resource with the specified ID
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    */

    //Bruges til at poste til databasen
    public IActionResult OnPost()
    {
        //var x = DateOfShift.ToString("yyyy-MM-dd");
        var shift = new _shift()
        {
            //Har hardcodet userid 1 hvergang, skal nok fikses så man gennem web kan få liste over users
            userid = UserID,
            start_time = StartTime,
            end_time = EndTime,
            //skal ændres til deres rigtige, er sat til det samme for at teste
            checked_in_time = StartTime,
            checked_out_time = EndTime,
            //
            break_duration = BreakDuration ,
            dateofshift = DateOfShift
            
        };
        _context._shift.Add(shift);
        _context.SaveChanges();
        
        Console.WriteLine("Saved shift");

        return RedirectToPage("/Schedule");
    }
    
}