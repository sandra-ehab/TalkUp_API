using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TalkUp.Models;

public partial class Medium
{
    [Key]
    [Column("Media_ID")]
    public int MediaId { get; set; }

    [StringLength(50)]
    public string? Type { get; set; }

    [Column("URL")]
    public byte[]? Url { get; set; }

    public string? Contant { get; set; }

    [StringLength(50)]
    public string? Books { get; set; }

    public byte[]? Relax { get; set; }

    public byte[]? Music { get; set; }

    public byte[]? Videos { get; set; }
}
