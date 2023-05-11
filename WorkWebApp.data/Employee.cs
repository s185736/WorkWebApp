using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace WorkWebApp.data;

public class Employee : _user
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    
}
