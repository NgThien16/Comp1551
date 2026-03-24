using StudentApplication.Data;
using StudentApplication.Models;
using StudentApplication.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace StudentApplication.Repositories

{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;
        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Student>> GetAllAsync() =>
         await _context.Students.ToListAsync();
        public async Task<Student?> GetByIdAsync(int id) =>
        await _context.Students.FindAsync(id);
        public async Task<Student> AddAsync(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }
        public async Task<Student?> UpdateAsync(Student student)
        {
            var existing = await _context.Students.FindAsync(student.Id);
            if(existing == null) return null;// lỗi ở đây 
            existing.FullName = student.FullName;
            existing.Email = student.Email;
            existing.DateOfBirth = student.DateOfBirth;
            await _context.SaveChangesAsync();
            return existing;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return false;
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
