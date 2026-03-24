using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentApplication.DTOs;
using StudentApplication.Models;
using StudentApplication.Repositories.Interfaces;

namespace StudentApplication.Controllers.Api
{
    public class AuthController
    {
        [Route("api/[controller]")]
        [ApiController]
        [Authorize] // <-- Add this attribute to protect all actions in this controller
        public class StudentsController : ControllerBase // Renamed to StudentsController for consistency if it was StudentsApiController
        {
            private readonly IStudentRepository _repository;
            public StudentsController(IStudentRepository repository) // Constructor updated if class name changed
            {
                _repository = repository;
            }
            [HttpGet]
            public async Task<ActionResult<IEnumerable<StudentDto>>> GetAll()
            {
                var students = await _repository.GetAllAsync();
                return Ok(students.Select(s => new StudentDto
                {
                    Id = s.Id,
                    FullName = s.FullName,
                    Email = s.Email,
                    DateOfBirth = s.DateOfBirth
                }));
            }
            [HttpGet("{id}")]
            public async Task<ActionResult<StudentDto>> Get(int id)
            {
                var student = await _repository.GetByIdAsync(id);
                if (student == null) return NotFound();
                return Ok(new StudentDto
                {
                    Id = student.Id,
                    FullName = student.FullName,
                    Email = student.Email,
                    DateOfBirth = student.DateOfBirth
                });
            }
            // Allow anonymous access for specific endpoints if needed
            // For example, if you wanted the GetAll to be public but Create to be secure:
            // [AllowAnonymous]
            // [HttpGet]
            // public async Task<ActionResult<IEnumerable<StudentDto>>> GetAll() { ... }
            [HttpPost]
            // [Authorize(Roles = "Admin")] // You can also specify roles for authorization
            public async Task<ActionResult<StudentDto>> Create(StudentDto dto)
            {
                var student = new Student
                {
                    FullName = dto.FullName,
                    Email = dto.Email,
                    DateOfBirth = dto.DateOfBirth
                };
                var created = await _repository.AddAsync(student);
                dto.Id = created.Id;
                return CreatedAtAction(nameof(Get), new { id = created.Id }, dto);
            }
            [HttpPut("{id}")]
            public async Task<ActionResult> Update(int id, StudentDto dto)
            {
                if (id != dto.Id) return BadRequest();
                var student = new Student
                {
                    Id = dto.Id,
                    FullName = dto.FullName,
                    Email = dto.Email,
                    DateOfBirth = dto.DateOfBirth
                };
                var updated = await _repository.UpdateAsync(student);
                if (updated == null) return NotFound();
                return NoContent();
            }
            [HttpDelete("{id}")]
            public async Task<ActionResult> Delete(int id)
            {
                var deleted = await _repository.DeleteAsync(id);
                if (!deleted) return NotFound();
                return NoContent();
            }
        }
    }
}
