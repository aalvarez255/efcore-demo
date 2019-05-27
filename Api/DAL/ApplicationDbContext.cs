using Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Api.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base (options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<OnlineCourse> OnlineCourses { get; set; }
        public DbSet<ClassRoomCourse> ClassRoomCourses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<CourseStudent> CourseStudents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseStudent>()
                .HasKey(x => new { x.CourseId, x.StudentId });
        }

        private void ConfigureCourseStudent(EntityTypeBuilder<CourseStudent> builder)
        {
            builder.HasKey(x => new { x.CourseId, x.StudentId });
        }
    }
}
