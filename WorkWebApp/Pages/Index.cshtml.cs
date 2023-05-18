using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WorkWebApp.data;

namespace WorkWebApp.Pages;

public class IndexModel : PageModel
{

    [BindProperty(SupportsGet = true)] public int userid { get; set; }

    private readonly ILogger<IndexModel> _logger;
    private readonly UserDataContext _context;

    public IndexModel(UserDataContext context)
    {
        _context = context;
    }

    public IList<_shiftswaprequest> SwapRequests { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        SwapRequests = await _context._shiftswaprequest
            .Where(s => s.requesteduserid == userid && s.status == "Pending")
            .ToListAsync();
        if (SwapRequests == null)
        {
            SwapRequests = new List<_shiftswaprequest>();
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAcceptRequestAsync(int requestId)
    {
        var swapRequest = await _context._shiftswaprequest.FindAsync(requestId);

        if (swapRequest != null)
        {
            var shift = await _context._shift.FindAsync(swapRequest.shiftid);
            var user = await _context._user.FindAsync(swapRequest.requesteduserid);
            
            if (shift != null)
            {
                shift.userid = user.record_id;
                swapRequest.status = "Accepted";

                await _context.SaveChangesAsync();
            }
        }

        return RedirectToPage();
    }


    public async Task<IActionResult> OnPostRejectRequestAsync(int requestId)
    {
        var swapRequest = await _context._shiftswaprequest.FindAsync(requestId);

        if (swapRequest != null)
        {
            swapRequest.status = "Declined";
            await _context.SaveChangesAsync();
        }

        return RedirectToPage();
    }
}







