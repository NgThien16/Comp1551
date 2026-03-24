using Microsoft.AspNetCore.Mvc;
using CourseManagement.Api.Interfaces;
using CourseManagement.Api.Models;
using CourseManagement.Api.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
namespace CourseManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseRepository _repository;
        private readonly ILogger<CoursesController> _logger;
        public CoursesController(ICourseRepository repository, ILogger<CoursesController> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        // GET: api/Courses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDto>>> GetCourses()
        {
            _logger.LogInformation("Getting all courses");
            var courses = await _repository.GetAllAsync();
            return Ok(courses.Select(c => MapToDto(c)));
        }
        // GET: api/Courses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDto>> GetCourse(int id)
        {
            _logger.LogInformation("Getting course with ID: {CourseId}", id);
            var course = await _repository.GetByIdAsync(id);
            if (course == null)
            {
                _logger.LogWarning("Course with ID: {CourseId} not found", id);
                return NotFound();
            }
            return Ok(MapToDto(course));
        }
        // POST: api/Courses
        [HttpPost]
        public async Task<ActionResult<CourseDto>> PostCourse(CreateCourseDto createCourseDto)
        {
            var course = new Course
            {
                CourseName = createCourseDto.CourseName,
                Description = createCourseDto.Description,
                Credits = createCourseDto.Credits,
            };
            var createdCourse = await _repository.AddAsync(course);
            _logger.LogInformation("Created new course with ID: {CourseId}", createdCourse.Id);
            return CreatedAtAction(nameof(GetCourse), new { id = createdCourse.Id }, MapToDto(createdCourse));
        }
        // PUT: api/Courses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(int id, UpdateCourseDto updateCourseDto)
        {
            var courseToUpdate = new Course
            {
                CourseName = updateCourseDto.CourseName,
                Description = updateCourseDto.Description,
                Credits = updateCourseDto.Credits
            };
            var updatedCourse = await _repository.UpdateAsync(id, courseToUpdate);
            if (updatedCourse == null)
            {
                _logger.LogWarning("Update failed. Course with ID: {CourseId} not found", id);
                return NotFound();
            }
            _logger.LogInformation("Updated course with ID: {CourseId}", id);
            return NoContent(); // Or return Ok(MapToDto(updatedCourse));
        }
        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var success = await _repository.DeleteAsync(id);
            if (!success)
            {
                _logger.LogWarning("Delete failed. Course with ID: {CourseId} not found", id);
                return NotFound();
            }
            _logger.LogInformation("Deleted course with ID: {CourseId}", id);
            return NoContent();
        }
        private static CourseDto MapToDto(Course course)
        {
            return new CourseDto
            {
                Id = course.Id,
                CourseName = course.CourseName,
                Description = course.Description,
                Credits = course.Credits
            };
        }
    }
}
