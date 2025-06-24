using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAcecss.Models;

public partial class SmartStudyContext : DbContext
{
    public SmartStudyContext()
    {
    }

    public SmartStudyContext(DbContextOptions<SmartStudyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Exam> Exams { get; set; }

    public virtual DbSet<Progress> Progresses { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<Score> Scores { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("DBDefault");
        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Exam>(entity =>
        {
            entity.HasKey(e => e.ExamId).HasName("PK__Exams__297521C70F73BD79");

            entity.Property(e => e.ExamRoom).HasMaxLength(50);

            entity.HasOne(d => d.Subject).WithMany(p => p.Exams)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("FK__Exams__SubjectId__4E88ABD4");
        });

        modelBuilder.Entity<Progress>(entity =>
        {
            entity.HasKey(e => e.ProgressId).HasName("PK__Progress__BAE29CA5F01CF809");

            entity.Property(e => e.Note).HasMaxLength(255);
            entity.Property(e => e.Topic).HasMaxLength(100);

            entity.HasOne(d => d.Subject).WithMany(p => p.Progresses)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("FK__Progresse__Subje__5165187F");
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.HasKey(e => e.ScheduleId).HasName("PK__Schedule__9C8A5B491147FD42");

            entity.Property(e => e.Location).HasMaxLength(100);
            entity.Property(e => e.WeekDay).HasMaxLength(20);

            entity.HasOne(d => d.Subject).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("FK__Schedules__Subje__4BAC3F29");
        });

        modelBuilder.Entity<Score>(entity =>
        {
            entity.HasKey(e => e.ScoreId).HasName("PK__Scores__7DD229D1958EC2B6");

            entity.Property(e => e.Score1).HasColumnName("Score");
            entity.Property(e => e.TestName).HasMaxLength(100);

            entity.HasOne(d => d.Subject).WithMany(p => p.Scores)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("FK__Scores__SubjectI__5441852A");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.SubjectId).HasName("PK__Subjects__AC1BA3A855631BA4");

            entity.Property(e => e.Lecturer).HasMaxLength(100);
            entity.Property(e => e.Notes).HasMaxLength(255);
            entity.Property(e => e.SubjectName).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
