using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TalkUp.Models;

[Table("Community")]
[Index("CommunityId", Name = "IX_Community")]
public partial class Community
{
    [Key]
    [Column("Community_ID")]
    public int CommunityId { get; set; }

    [Column("User_ID")]
    public int UserId { get; set; }

    [Column("Post_ID")]
    public int PostId { get; set; }

    public string? Contant { get; set; }

    public int? Likes { get; set; }

    [ForeignKey("PostId")]
    [InverseProperty("Communities")]
    public virtual Post Post { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("Communities")]
    public virtual User User { get; set; } = null!;
}
