using System.ComponentModel.DataAnnotations;

namespace StudentApplication.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
    }
}
