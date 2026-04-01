using System.ComponentModel.DataAnnotations;

namespace CourseManagement.Api.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string CourseName { get; set; } = string.Empty;
        [MaxLength(1000)]
        public string? Description { get; set; }
        [Range(1, 5)]
        public int Credits { get; set; }
    }
}
