using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YFinder.Models
{
  public class Rating
  {
    [Key]
    public int RatingId { get; set; }

    [Required]
    public string Comment { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime RatingDate { get; set; }

    [Required]
    public int HotspotId { get; set; }

    [Required]
    public Hotspot Hotspot { get; set; }

    [Required]
    public int Public { get; set; } // int as bool

    [Required]
    public int? Rating { get; set; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public User User { get; set; }

  }
}