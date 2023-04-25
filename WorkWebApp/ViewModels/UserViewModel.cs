using System.ComponentModel.DataAnnotations.Schema;
using WorkWebApp.data;

namespace WorkWebApp.ViewModels;

public class UserViewModel  
{
           
    public _user? viewUser { get; set; }
    public int record_id { get; set; }
    public string firstname { get; set; }
    public string? lastname { get; set; }
    public string? mail { get; set; }
    public string? phonenumber { get; set; }
    public DateTime? birthday { get; set; }
    public string? role { get; set; }
    public string? department { get; set; }
    public string? password { get; set; }
    [NotMapped]
    public Dictionary<DateTime, _shift> ShiftsDictionary { get; set; }

}