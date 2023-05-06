using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TalkUp.Models;

[Table("Session")]
public partial class Session
{
    [Key]
    [Column("Session_ID")]
    public int SessionId { get; set; }

    [Column("User_ID")]
    public int UserId { get; set; }

    [Column("Rate_ID")]
    public int RateId { get; set; }

    [Column("EXP_ID")]
    public int ExpId { get; set; }

    public string? Status { get; set; }

    [Column(TypeName = "date")]
    public DateTime? Date { get; set; }

    [Column("Creat_at")]
    public string? CreatAt { get; set; }

    [Column("Start_time")]
    public TimeSpan? StartTime { get; set; }

    [Column("End_time")]
    public TimeSpan? EndTime { get; set; }

    [Column("Session_fees", TypeName = "money")]
    public decimal? SessionFees { get; set; }

    public TimeSpan? Duration { get; set; }

    [ForeignKey("RateId")]
    [InverseProperty("Sessions")]
    public virtual Rating Rate { get; set; } = null!;

    [InverseProperty("Session")]
    public virtual ICollection<Rating> Ratings { get; } = new List<Rating>();

    [ForeignKey("SessionId")]
    [InverseProperty("Session")]
    public virtual Exp SessionNavigation { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("Sessions")]
    public virtual User User { get; set; } = null!;
}
