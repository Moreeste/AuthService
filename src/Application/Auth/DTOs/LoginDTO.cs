namespace Application.Auth.DTOs
{
    public class LoginDTO
    {
        public string? Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
