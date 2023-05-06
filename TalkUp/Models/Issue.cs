using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TalkUp.Models;

[Table("Issue")]
public partial class Issue
{
    [Key]
    [Column("Issue_ID")]
    public int IssueId { get; set; }

    [StringLength(10)]
    public string? Name { get; set; }
}
