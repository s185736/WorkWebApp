using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace WorkWebApp.data;

public class Employee
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    
}