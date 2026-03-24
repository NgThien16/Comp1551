using System.ComponentModel.DataAnnotations;
namespace CourseManagement.Api.DTOs
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string CourseName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int Credits { get; set; }
    }
    public class CreateCourseDto
    {
        [Required]
        [MaxLength(200)]
        public string CourseName { get; set; } = string.Empty;
        [MaxLength(1000)]
        public string? Description { get; set; }
        [Required]
        [Range(1, 5)]
        public int Credits { get; set; }
    }
    public class UpdateCourseDto
    {
        [Required]
        [MaxLength(200)]
        public string CourseName { get; set; } = string.Empty;
        [MaxLength(1000)]
        public string? Description { get; set; }
        [Required]
        [Range(1, 5)]
        public int Credits { get; set; }
    }
}
