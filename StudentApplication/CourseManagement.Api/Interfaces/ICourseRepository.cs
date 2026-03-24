using CourseManagement.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace CourseManagement.Api.Interfaces
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAllAsync();
        Task<Course?> GetByIdAsync(int id);
        Task<Course> AddAsync(Course course);
        Task<Course?> UpdateAsync(int id, Course course);
        Task<bool> DeleteAsync(int id);
    }
}
