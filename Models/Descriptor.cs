using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YFinderAPI.Models
{
  public class Descriptor
  {
    [Key]
    public int DescriptorId { get; set; }

    [StringLength(100)]
    public string Description { get; set; }

    public virtual ICollection<RatingDescriptor> RatingDescriptor { get; set ; }
    
  }
}