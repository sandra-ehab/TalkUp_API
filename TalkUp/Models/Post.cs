using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TalkUp.Models;

[Table("Post")]
public partial class Post
{
    [Key]
    [Column("Post_ID")]
    public int PostId { get; set; }

    [Column("User_ID")]
    public int UserId { get; set; }

    [Column("Creat_at")]
    [StringLength(10)]
    public string? CreatAt { get; set; }

    [InverseProperty("Post")]
    public virtual ICollection<Community> Communities { get; } = new List<Community>();
}
