using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WorkWebApp.data;

namespace WorkWebApp.Pages;

public class ViewShift : PageModel
{
    private UserDataContext Context
    {
        get;
    }

    public ViewShift(UserDataContext _context) 
    {
        this.Context = _context;
    }

    public _shift Shift { get; set; }

    public void onGet()
    {
        
    }

    public void onPostSubmit(_shift shift)
    {
        _shift updateShift =
            (from c in this.Context._shift 
                where c.record_id == shift.record_id 
                select c).FirstOrDefault();
        
        if (updateShift != null)
        {
            updateShift.userid = 1;
            updateShift.start_time = Shift.start_time;
            updateShift.end_time = Shift.end_time;
            updateShift.checked_in_time = Shift.start_time;
            updateShift.checked_out_time = Shift.end_time;
            this.Context.SaveChanges();
            ViewData["Message"] = "Shift record updated.";
        }
        else
        {
            ViewData["Message"] = "Shift not found.";
        }
    }


    /*
    [BindProperty]
    public string RecordId { get; set; }
    
    [BindProperty]
    public int UserId { get; set; }
    
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
    
    */



}
