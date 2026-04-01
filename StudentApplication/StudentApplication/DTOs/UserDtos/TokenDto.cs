namespace StudentApplication.DTOs.UserDtos
{
    public class TokenDto
    {
        public string Token { get; set; } = string.Empty;
        public DateTime Expiration { get; set; }
    }
}
