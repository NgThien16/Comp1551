using System.ComponentModel.DataAnnotations;

namespace StudentApplication.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public String Username { get; set; } = string.Empty;
        [Required]
        public String PasswordHash { get; set; } = string.Empty;
    }
}
