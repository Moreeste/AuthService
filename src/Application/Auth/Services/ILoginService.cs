using Application.Auth.DTOs;

namespace Application.Auth.Services
{
    public interface ILoginService
    {
        Task<LoginDTO> Login(string email, string password);
        Task<LoginDTO> RefreshToken(string expiredToken, string refreshToken);
    }
}
