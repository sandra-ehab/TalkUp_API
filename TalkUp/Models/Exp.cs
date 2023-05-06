using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TalkUp.Models;

[Table("EXP")]
public partial class Exp
{
    [Key]
    [Column("EXP_ID")]
    public int ExpId { get; set; }

    [Column("User_ID")]
    public int UserId { get; set; }

    public string? Speciality { get; set; }

    public string? Certificate { get; set; }

    [InverseProperty("SessionNavigation")]
    public virtual Session? Session { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Exps")]
    public virtual User User { get; set; } = null!;
}
