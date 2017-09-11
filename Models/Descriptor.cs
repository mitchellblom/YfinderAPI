using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YFinder.Models
{
  public class Descriptor
  {
    [Key]
    public int DescriptorId { get; set; }

    [Required]
    [StringLength(100)]
    public string Descriptor { get; set; }
    
  }
}