﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.JavaScript;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Identity;

namespace WorkWebApp.data;

public class _user
{
    [Key]
    [Required]
    public int record_id { get; set; }
    public string firstname { get; set; }
    public string lastname { get; set; }
    public string mail { get; set; }
    public string phonenumber { get; set; }
    public DateTime birthday { get; set; }
    public string role { get; set; }
    public string department { get; set; }
    public string password { get; set; }
    public string color { get; set; }
    [NotMapped]
    public Dictionary<DateTime, _shift> ShiftsDictionary { get; set; }
    

    
}