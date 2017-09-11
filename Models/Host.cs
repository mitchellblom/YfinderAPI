using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YFinder.Models
{
  public class Host
  {
    [Key]
    public int HostId { get; set; }

    [Required]
    [StringLength(100)]
    public string Address { get; set; }

    [Required]
    [StringLength(50)]
    public string Title { get; set; }

    [Required]
    public int UserId { get; set; }

    public User? User { get; set; }  // Host user must be Host == 1 (true)

  }
}