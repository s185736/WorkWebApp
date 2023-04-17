using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;
using System.Security.Cryptography;

namespace WorkWebApp.data;

public class Shift
{

    public int id { get; set; }
    public int employee_id { get; set; }
    public DateTime start_time { get; set; }
    public DateTime end_time { get; set; }
}