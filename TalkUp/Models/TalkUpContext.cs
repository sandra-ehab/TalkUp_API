using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TalkUp.Models;

public partial class TalkUpContext : DbContext
{
    public TalkUpContext()
    {
    }

    public TalkUpContext(DbContextOptions<TalkUpContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Community> Communities { get; set; }

    public virtual DbSet<Exp> Exps { get; set; }

    public virtual DbSet<Issue> Issues { get; set; }

    public virtual DbSet<Medium> Media { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Rating> Ratings { get; set; }

    public virtual DbSet<Session> Sessions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-62B5GTO; Database=TalkUp; Trusted_Connection=true; Trust Server Certificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Community>(entity =>
        {
            entity.HasOne(d => d.Post).WithMany(p => p.Communities)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Community_User");

            entity.HasOne(d => d.User).WithMany(p => p.Communities)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Community_Post");
        });

        modelBuilder.Entity<Exp>(entity =>
        {
            entity.HasOne(d => d.User).WithMany(p => p.Exps)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EXP_User");
        });

        modelBuilder.Entity<Issue>(entity =>
        {
            entity.Property(e => e.Name).IsFixedLength();
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.Property(e => e.PostId).ValueGeneratedNever();
            entity.Property(e => e.CreatAt).IsFixedLength();
        });

        modelBuilder.Entity<Rating>(entity =>
        {
            entity.HasOne(d => d.Session).WithMany(p => p.Ratings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rating_Session");

            entity.HasOne(d => d.User).WithMany(p => p.Ratings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rating_User");
        });

        modelBuilder.Entity<Session>(entity =>
        {
            entity.Property(e => e.SessionId).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Rate).WithMany(p => p.Sessions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Session_Rating");

            entity.HasOne(d => d.SessionNavigation).WithOne(p => p.Session)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Session_EXP");

            entity.HasOne(d => d.User).WithMany(p => p.Sessions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Session_User");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Password).IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
