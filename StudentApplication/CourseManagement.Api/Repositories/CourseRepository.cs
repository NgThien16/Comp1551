using Microsoft.EntityFrameworkCore;
using CourseManagement.Api.Data;
using CourseManagement.Api.Models;
using CourseManagement.Api.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace CourseManagement.Api.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly CourseDbContext _context;
        public CourseRepository(CourseDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await _context.Courses.ToListAsync();
        }
        public async Task<Course?> GetByIdAsync(int id)
        {
            return await _context.Courses.FindAsync(id);
        }
        public async Task<Course> AddAsync(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return course;
        }
        public async Task<Course?> UpdateAsync(int id, Course course)
        {
            var existingCourse = await _context.Courses.FindAsync(id);
            if (existingCourse == null)
            {
                return null;
            }
            existingCourse.CourseName = course.CourseName;
            existingCourse.Description = course.Description;
            existingCourse.Credits = course.Credits;
            // _context.Entry(existingCourse).State = EntityState.Modified; // Or set properties manually
            await _context.SaveChangesAsync();
            return existingCourse;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return false;
            }
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
