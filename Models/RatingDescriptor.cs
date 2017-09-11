using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YFinder.Models
{
  public class Hotspot
  {
    [Key]
    public int RatingDescriptorId { get; set; }

    [Required]
    public int RatingId { get; set; }

    [Required]
    public Rating Rating { get; set; }

    [Required]
    public int DescriptorId { get; set; }

    [Required]
    public Descriptor Descriptor { get; set; }

  }
}