using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YFinder.Models
{
  public class User
  {
    [Key]
    public int UserId { get; set; }

    [StringLength(140)]
    public string Bio { get; set; }

    [Required]
    public string Email { get; set; }

    [StringLength(50)]
    public string FullName { get; set; }

    [Required]
    public int Host { get; set; } // int as bool

    [Required]
    public string UserName { get; set; }

    [Required]
    public int Zip { get; set; }

    public User() {
      Host = 0;
    }

  }
}