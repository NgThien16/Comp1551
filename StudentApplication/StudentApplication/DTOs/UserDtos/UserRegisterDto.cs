using System.ComponentModel.DataAnnotations;

namespace StudentApplication.DTOs.UserDtos
{
    public class UserRegisterDto
    {
        [Required]
        [MaxLength(100)]
        public string Username { get; set; } = string.Empty;
        [Required]
        [MinLength(6)]
        public string Password { get; set; } = string.Empty;
    }
}
