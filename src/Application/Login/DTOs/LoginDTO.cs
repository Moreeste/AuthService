namespace Application.Login.DTOs
{
    public class LoginDTO
    {
        public string? Token { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime Expiration { get; set; }
    }
}
