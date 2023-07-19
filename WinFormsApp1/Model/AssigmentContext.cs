using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WinFormsApp1.Model;

public partial class AssigmentContext : DbContext
{
    public AssigmentContext()
    {
    }

    public AssigmentContext(DbContextOptions<AssigmentContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attendance> Attendances { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<Lecture> Lectures { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Session> Sessions { get; set; }

    public virtual DbSet<Slot> Slots { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=TRANQUOCHUNG\\TRQUOCHUNG; database =Assigment ;uid=sa;pwd=123; Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.HasKey(e => e.Aid).HasName("PK_Attendance1");

            entity.ToTable("Attendance");

            entity.Property(e => e.Aid).HasColumnName("aid");
            entity.Property(e => e.Checked).HasColumnName("checked");
            entity.Property(e => e.Sesid).HasColumnName("sesid");
            entity.Property(e => e.Sid).HasColumnName("sid");

            entity.HasOne(d => d.Ses).WithMany(p => p.Attendances)
                .HasForeignKey(d => d.Sesid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Attendance_Session");

            entity.HasOne(d => d.SidNavigation).WithMany(p => p.Attendances)
                .HasForeignKey(d => d.Sid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Attendance_Student");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.ToTable("course");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .HasColumnName("id");
            entity.Property(e => e.Cname)
                .HasMaxLength(50)
                .HasColumnName("cname");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.ToTable("Group");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Courseid)
                .HasMaxLength(50)
                .HasColumnName("courseid");
            entity.Property(e => e.Gname)
                .HasMaxLength(50)
                .HasColumnName("gname");
            entity.Property(e => e.Lectureid).HasColumnName("lectureid");

            entity.HasOne(d => d.Course).WithMany(p => p.Groups)
                .HasForeignKey(d => d.Courseid)
                .HasConstraintName("FK_Group_course");

            entity.HasOne(d => d.Lecture).WithMany(p => p.Groups)
                .HasForeignKey(d => d.Lectureid)
                .HasConstraintName("FK_Group_Lecture");

            entity.HasMany(d => d.Sids).WithMany(p => p.Groups)
                .UsingEntity<Dictionary<string, object>>(
                    "StuGroup",
                    r => r.HasOne<Student>().WithMany()
                        .HasForeignKey("Sid")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_stu_group_Student"),
                    l => l.HasOne<Group>().WithMany()
                        .HasForeignKey("Groupid")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_stu_group_Group"),
                    j =>
                    {
                        j.HasKey("Groupid", "Sid");
                        j.ToTable("stu_group");
                    });
        });

        modelBuilder.Entity<Lecture>(entity =>
        {
            entity.ToTable("Lecture");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Lname)
                .HasMaxLength(50)
                .HasColumnName("lname");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.ToTable("room");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .HasColumnName("id");
        });

        modelBuilder.Entity<Session>(entity =>
        {
            entity.ToTable("Session");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.Gid).HasColumnName("gid");
            entity.Property(e => e.Lid).HasColumnName("lid");
            entity.Property(e => e.Roomid)
                .HasMaxLength(50)
                .HasColumnName("roomid");
            entity.Property(e => e.Timeid).HasColumnName("timeid");

            entity.HasOne(d => d.GidNavigation).WithMany(p => p.Sessions)
                .HasForeignKey(d => d.Gid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Session_Group");

            entity.HasOne(d => d.Room).WithMany(p => p.Sessions)
                .HasForeignKey(d => d.Roomid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Session_room");

            entity.HasOne(d => d.Time).WithMany(p => p.Sessions)
                .HasForeignKey(d => d.Timeid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Session_Slot");
        });

        modelBuilder.Entity<Slot>(entity =>
        {
            entity.ToTable("Slot");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("Student");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Sname)
                .HasMaxLength(50)
                .HasColumnName("sname");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
