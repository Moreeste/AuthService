namespace Application.Auth.DTOs
{
    public class LoginDTO
    {
        public string? Token { get; set; }
        public DateTime TokenExpiration { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiration { get; set; }
    }
}
