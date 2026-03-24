using CourseManagement.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
namespace CourseManagement.Api.Data
{
    public class CourseDbContext : DbContext
    {
        public CourseDbContext(DbContextOptions<CourseDbContext> options)
        : base(options)
        {
        }
        public DbSet<Course> Courses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // You can add initial data seeding here if needed
            modelBuilder.Entity<Course>().HasData(
            new Course
            {
                Id = 1,
                CourseName = "Introduction to Programming",
                Description = "Basics of C#",
                Credits = 3
            },
            new Course
            {
                Id = 2,
                CourseName = "Web Development Fundamentals",
                Description = "HTML, CSS, JavaScrit", Credits = 4 },
           
            new Course { Id = 3, CourseName = "Database Design", Description = "SQL and NoSQL", Credits = 3 }
            );
        }
    }
}