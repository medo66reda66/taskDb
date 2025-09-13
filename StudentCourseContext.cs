using Microsoft.EntityFrameworkCore;
using StudentCourse.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourse.Data
{
    internal class StudentCourseContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Resource> Resources { get; set; } 
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<StudentCourse1> StudentCourse { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Data Source=.;Initial catalog=EFtaskDb;Integrated Security=True;Connect Timeout=30;Encrypt=True;" +
                    "Trust Server Certificate=True;Application Intent=ReadWrite;" +
                    "Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Homework>()
                .HasKey(h => new { h.Id, h.StudentId, h.CourseId });
            modelBuilder.Entity<Resource>()
                .HasKey(r => new { r.ResourceId, r.CourseId });
            modelBuilder.Entity<Student>()
                .Property(s => s.Name)
                .HasMaxLength(100)
                .IsUnicode(true);
            modelBuilder.Entity<Student>()
                .Property(s => s.PhoneNumber)
                .IsRequired(false)
                .IsUnicode(false);
            modelBuilder.Entity<Course>()
                .Property(c => c.Name)
                .HasMaxLength(80)
                .IsUnicode(true);
            modelBuilder.Entity<Course>()
                .Property(c => c.Description)
                .IsRequired(false)
                .IsUnicode(true);
            modelBuilder.Entity<Resource>()
                .Property(r => r.Name)
                .HasMaxLength(50)
                .IsUnicode(true);
            modelBuilder.Entity<Resource>()
                .Property(r => r.Url)
                .IsUnicode(false);
            modelBuilder.Entity<Homework>()
                .Property(h => h.Content)
                .IsUnicode(false);
            modelBuilder.Entity<StudentCourse1>()
                .HasKey(e => new { e.StudentId, e.CourseId });
        }
    }
}
