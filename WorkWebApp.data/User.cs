using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace WorkWebApp.data;

public class User
{

    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    [NotMapped]
    public Dictionary<DateTime, Shift> ShiftsDictionary { get; set; }
    

    
}