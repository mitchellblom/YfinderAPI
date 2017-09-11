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

    [StringLength(100)]
    public string? Descriptor { get; set; }

    public virtual ICollection<RatingDescriptor> RatingDescriptor { get; set ; }
    
  }
}