using LearningManagementSystem.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LearningManagementSystem.Infrastructure.Data
{
    public class LearningSystemDbContext : IdentityDbContext
    {
        public LearningSystemDbContext(DbContextOptions<LearningSystemDbContext> options)
            : base(options)
        {
                
        }

        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Discussion> Discussions { get; set; }
        public DbSet<FileMaterial> FileMaterials { get; set; }
        public DbSet<Submission> Submissions { get; set; }

        public DbSet<TextMaterial> TextMaterials { get; set; }
        public DbSet<Topic> Topics { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<StudentCourse>()
                        .HasKey(sc => new { sc.StudentId, sc.CourseId });
            builder.Entity<StudentCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.Courses)
                .HasForeignKey(sc => sc.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.Students)
                .HasForeignKey(sc => sc.CourseId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
