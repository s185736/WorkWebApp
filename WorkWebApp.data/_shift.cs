using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;
using System.Security.Cryptography;

namespace WorkWebApp.data;

public class _shift
{
    [Key]
    [Required]
    public int record_id { get; set; }
    public int userid { get; set; }
    public TimeSpan start_time { get; set; }
    public TimeSpan end_time { get; set; }
    public TimeSpan checked_in_time { get; set; }
    public TimeSpan checked_out_time { get; set; }
    
    public TimeSpan break_duration { get; set; }
    public DateTime dateofshift { get; set; }
}