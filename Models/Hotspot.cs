using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YFinder.Models
{
  public class Hotspot
  {
    [Key]
    public int HotspotId { get; set; }

    [Required]
    public int HostId { get; set; }

    [Required]
    [StringLength(100)]
    public string Title { get; set; }
    
  }
}