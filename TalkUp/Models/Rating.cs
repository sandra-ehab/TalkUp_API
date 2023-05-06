using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TalkUp.Models;

[Table("Rating")]
public partial class Rating
{
    [Key]
    [Column("Rateing_ID")]
    public int RateingId { get; set; }

    [Column("User_ID")]
    public int UserId { get; set; }

    [Column("Session_ID")]
    public int SessionId { get; set; }

    [Column(TypeName = "date")]
    public DateTime? Date { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? Value { get; set; }

    public string? Massage { get; set; }

    [ForeignKey("SessionId")]
    [InverseProperty("Ratings")]
    public virtual Session Session { get; set; } = null!;

    [InverseProperty("Rate")]
    public virtual ICollection<Session> Sessions { get; } = new List<Session>();

    [ForeignKey("UserId")]
    [InverseProperty("Ratings")]
    public virtual User User { get; set; } = null!;
}
