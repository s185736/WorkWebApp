using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;
using System.Security.Cryptography;

namespace WorkWebApp.data;

public class _shiftswaprequest
{
    [Key]
    [Required]
    public int record_id { get; set; }
    public int requestinguserid { get; set; }
    public int requesteduserid { get; set; }
    public int shiftid { get; set; }
    public string status { get; set; } // e.g., "Pending", "Accepted", "Declined"
}
