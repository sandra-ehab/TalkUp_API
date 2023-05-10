using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TalkUp.Models;

[Table("User")]
public partial class User
{
    [Key]
    [Column("User_ID")]
    public int UserId { get; set; }

    [StringLength(50)]
    public string? Gender { get; set; }

    [Column("DOB", TypeName = "date")]
    public DateTime? Dob { get; set; }

    public string? Phone { get; set; }

    [StringLength(50)]
    public string? Name { get; set; }

    [Column("Pass_word")]
    [Required]
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }
    [Column(TypeName = "image")]
    public byte[]? Photo { get; set; }

    [StringLength(50)]
    public string? Gmail { get; set; }

    [Column("Creat_at")]
    public string? CreatAt { get; set; }

    [Column("Payment_info", TypeName = "money")]
    public decimal? PaymentInfo { get; set; }

    [MaxLength(50)]
    public byte[]? Role { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<Community> Communities { get; } = new List<Community>();

    [InverseProperty("User")]
    public virtual ICollection<Exp> Exps { get; } = new List<Exp>();

    [InverseProperty("User")]
    public virtual ICollection<Rating> Ratings { get; } = new List<Rating>();

    [InverseProperty("User")]
    public virtual ICollection<Session> Sessions { get; } = new List<Session>();
}
